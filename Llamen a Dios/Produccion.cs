using CapaEntidades;
using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
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
                    // NUEVO: Guardamos el índice de la fila que se acaba de crear
                    int rowIndex = dgvProduccion.Rows.Add(new object[] {
                        prod.IdProducto,
                        prod.Nombre,
                        prod.Stock,
                        "0", // Por defecto arranca en cero hasta presionar el botón de IA
                        "0", // Inicializamos en cero para evitar nulos al escribir
                        "0"  // Inicializamos en cero
                    });

                    // NUEVO: Usamos el 'Tag' de la fila como bolsillo secreto para guardar el costo 
                    // sin necesidad de crear una columna extra en el diseño visual.
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
                // 1. Buscamos el diccionario predictivo en la capa de negocio
                Dictionary<int, int> predicciones = objCapaNegocio.ObtenerSugerenciasIA();

                if (predicciones.Count == 0)
                {
                    MessageBox.Show("No hay suficiente historial de ventas en este día de la semana para generar una predicción. Se usarán valores mínimos predeterminados.",
                                    "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 2. Recorremos cada fila de nuestro DataGridView actual
                foreach (DataGridViewRow fila in dgvProduccion.Rows)
                {
                    int idProducto = Convert.ToInt32(fila.Cells["colId"].Value);

                    // Si la IA tiene una sugerencia para este producto, la colocamos. Si no, ponemos un estimado base (ej: 12 unidades)
                    int cantidadSugerida = predicciones.ContainsKey(idProducto) ? predicciones[idProducto] : 12;

                    // 3. Pintamos los resultados en el Grid
                    fila.Cells["colSugerido"].Value = cantidadSugerida.ToString();

                    // ¡Estrategia UX ágil! Llenamos de una vez la columna "Horneado" con la sugerencia,
                    // así el usuario solo cambia los pocos que difieran.
                    fila.Cells["colEntrada"].Value = cantidadSugerida.ToString();
                }

                MessageBox.Show("Sugerencia de producción calculada con éxito basándose en el historial de ventas.",
                                "🤖 IA de Pan de Paris", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar las sugerencias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Forzar la finalización de cualquier edición activa en las celdas para capturar el último número escrito
            dgvProduccion.EndEdit();

            try
            {
                List<ControlProduccion> listaAMandar = new List<ControlProduccion>();

                // 1. Recorremos el DataGridView para recolectar lo que escribió el usuario
                foreach (DataGridViewRow fila in dgvProduccion.Rows)
                {
                    // Validamos que los valores sean numéricos correctos (si están vacíos o tienen letras, se convierten en 0)
                    int idProd = Convert.ToInt32(fila.Cells["colId"].Value);
                    int sugerido = int.TryParse(Convert.ToString(fila.Cells["colSugerido"].Value), out int s) ? s : 0;
                    int entrada = int.TryParse(Convert.ToString(fila.Cells["colEntrada"].Value), out int en) ? en : 0;
                    int merma = int.TryParse(Convert.ToString(fila.Cells["colMerma"].Value), out int me) ? me : 0;

                    // NUEVO: Recuperamos el costo escondido en el Tag de la fila
                    decimal costoEscondido = fila.Tag != null ? Convert.ToDecimal(fila.Tag) : 0m;

                    // Solo tomamos en cuenta filas que tengan algún movimiento para no saturar la BD
                    if (entrada > 0 || merma > 0)
                    {
                        listaAMandar.Add(new ControlProduccion()
                        {
                            // NUEVO: Adjuntamos el costo al objeto Producto para que viaje a la Base de Datos
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
                    MessageBox.Show("¡Producción y Mermas registradas correctamente!\nEl inventario en stock ha sido actualizado y los costos calculados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Refrescamos la tabla para ver reflejado el nuevo Stock Actualizado desde MySQL
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
    }
}