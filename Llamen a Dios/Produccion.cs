using CapaEntidades;
using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data; 
using System.Windows.Forms;

namespace Llamen_a_Dios
{
    public partial class Produccion : Form
    {
        // Instanciamos la capa de negocio para poder usar sus métodos
        private CN_Produccion objCapaNegocio = new CN_Produccion();

        public Produccion()
        {
            InitializeComponent();
        }

        // Evento que se ejecuta automáticamente cuando se abre la pantalla
        private void Produccion_Load(object sender, EventArgs e)
        {
            CargarProductosEnTabla();
            ConfigurarAyudaVisual();

            // Configuramos eventos para los botones
            btnSugerenciaIA.Click += new EventHandler(btnSugerenciaIA_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
        }

        // Método encargado de rellenar las filas del DataGridView
        private void CargarProductosEnTabla()
        {
            try
            {
                // Limpiamos cualquier fila vieja que tenga la tabla
                dgvProduccion.Rows.Clear();

                // Pedimos la lista de panes a la Capa de Negocio
                List<Producto> listaProductos = objCapaNegocio.ObtenerProductosParaProduccion();

                // Recorremos la lista y agregamos una fila por cada pan
                foreach (Producto prod in listaProductos)
                {
                    // Guardamos el índice de la fila que se acaba de crear
                    int rowIndex = dgvProduccion.Rows.Add(new object[] {
                        prod.IdProducto,
                        prod.Nombre,
                        prod.Stock,
                        "0", // Por defecto arranca en cero hasta presionar el botón de IA
                        "0", // Inicializamos en cero para evitar nulos al escribir
                        "0"  // Inicializamos en cero
                    });

                    // Usamos el 'Tag' de la fila como bolsillo secreto para guardar el costo 
                    dgvProduccion.Rows[rowIndex].Tag = prod.CostoProduccion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la pantalla de producción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSugerenciaIA_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. PLAN A: Buscamos el diccionario predictivo (Días de la semana específicos)
                Dictionary<int, int> predicciones = objCapaNegocio.ObtenerSugerenciasIA();

                // 2. PLAN B: Traemos el historial general de 3 meses para tener respaldo
                DataTable historialGeneral = objCapaNegocio.ObtenerHistorial3Meses();

                if (predicciones.Count == 0 && historialGeneral.Rows.Count == 0)
                {
                    MessageBox.Show("No hay ningún historial de ventas registrado en la base de datos. Se usarán valores en cero.",
                                    "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 3. Recorremos cada fila de nuestro DataGridView actual
                foreach (DataGridViewRow fila in dgvProduccion.Rows)
                {
                    int idProducto = Convert.ToInt32(fila.Cells["colId"].Value);
                    int cantidadSugerida = 0;

                    // Verificamos el PLAN A
                    if (predicciones.ContainsKey(idProducto))
                    {
                        // Tiene historial en este día específico
                        cantidadSugerida = predicciones[idProducto];
                    }
                    else
                    {
                        // Verificamos el PLAN B (No se vende hoy, pero evaluamos su promedio general)
                        DataRow[] filaHistorial = historialGeneral.Select($"idproducto = {idProducto}");

                        if (filaHistorial.Length > 0)
                        {
                            // Dividimos el total vendido en 3 meses entre 90 días y redondeamos hacia arriba
                            int totalVendido3Meses = Convert.ToInt32(filaHistorial[0]["TotalUnidades"]);
                            cantidadSugerida = (int)Math.Ceiling(totalVendido3Meses / 90.0);
                        }
                        else
                        {
                            // PLAN C: Es un producto nuevo o no se ha vendido nada en 3 meses
                            cantidadSugerida = 0;
                        }
                    }

                    // 4. Pintamos los resultados en el Grid
                    fila.Cells["colSugerido"].Value = cantidadSugerida.ToString();
                    fila.Cells["colEntrada"].Value = cantidadSugerida.ToString();
                }

                MessageBox.Show("Sugerencia de producción calculada basándose en datos reales de los últimos 3 meses.",
                                "🤖 IA de Producción", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar las sugerencias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Forzar la finalización de cualquier edición activa en las celdas
            dgvProduccion.EndEdit();

            try
            {
                List<ControlProduccion> listaAMandar = new List<ControlProduccion>();

                // 1. Recorremos el DataGridView para recolectar lo que escribió el usuario
                foreach (DataGridViewRow fila in dgvProduccion.Rows)
                {
                    int idProd = Convert.ToInt32(fila.Cells["colId"].Value);
                    int sugerido = int.TryParse(Convert.ToString(fila.Cells["colSugerido"].Value), out int s) ? s : 0;
                    int entrada = int.TryParse(Convert.ToString(fila.Cells["colEntrada"].Value), out int en) ? en : 0;
                    int merma = int.TryParse(Convert.ToString(fila.Cells["colMerma"].Value), out int me) ? me : 0;

                    decimal costoEscondido = fila.Tag != null ? Convert.ToDecimal(fila.Tag) : 0m;

                    // Solo tomamos en cuenta filas que tengan algún movimiento
                    if (entrada > 0 || merma > 0)
                    {
                        listaAMandar.Add(new ControlProduccion()
                        {
                            oProducto = new Producto()
                            {
                                IdProducto = idProd,
                                CostoProduccion = costoEscondido
                            },
                            SugeridoIA = sugerido,
                            EntradaHorno = entrada,
                            Merma = merma
                        });
                    }
                }

                if (listaAMandar.Count == 0)
                {
                    MessageBox.Show("No ha ingresado ninguna cantidad de Horneado o Merma en la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Enviamos la lista a la Capa de Negocio
                string mensajeError;
                bool exito = objCapaNegocio.RegistrarProduccion(listaAMandar, out mensajeError);

                if (exito)
                {
                    MessageBox.Show("¡Producción y Mermas registradas correctamente!\nEl inventario en stock ha sido actualizado, los costos calculados y los ingredientes descontados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Refrescamos la tabla 
                    CargarProductosEnTabla();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro: " + mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al procesar el guardado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================================
        // AYUDA VISUAL (ESTILO GLOBO) PARA EL MÓDULO DE PRODUCCIÓN
        // ==============================================================
        private void ConfigurarAyudaVisual()
        {
            ToolTip toolTipProduccion = new ToolTip();

            // Estilo Globo idéntico al de tu alerta de stock
            toolTipProduccion.IsBalloon = true;
            toolTipProduccion.ToolTipIcon = ToolTipIcon.Info;
            toolTipProduccion.ToolTipTitle = "Módulo de Producción";

            // Tiempos de visualización
            toolTipProduccion.AutoPopDelay = 6000;
            toolTipProduccion.InitialDelay = 400;
            toolTipProduccion.ReshowDelay = 300;
            toolTipProduccion.ShowAlways = true;

            // --- TOOLTIPS PARA LOS CONTROLES DE ESTA PANTALLA ---
            toolTipProduccion.SetToolTip(this.btnSugerenciaIA, "Calcula la cantidad recomendada a hornear hoy\nbasándose en el historial de ventas .");
            toolTipProduccion.SetToolTip(this.btnGuardar, "Registra la producción, actualiza el stock final\ny descuenta automáticamente los ingredientes usados.");
            toolTipProduccion.SetToolTip(this.dgvProduccion, "Modifica las columnas 'Entrada Horno' y 'Merma'\nantes de presionar Guardar.");
        }

    }
}