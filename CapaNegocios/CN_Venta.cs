using CapaDatos; // Referencia a tu capa de datos
using Entidades;  // Referencia a tus entidades
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class CN_Venta
    {
        private CD_Venta objcd_venta = new CD_Venta();

        // ==============================================================
        // MÉTODO LISTAR (Este es el que faltaba y arregla el error)
        // ==============================================================
        public List<Ventas> Listar()
        {
            return objcd_venta.Listar();
        }

        // ==============================================================
        // MÉTODO REGISTRAR (El tuyo, intacto)
        // ==============================================================
        public bool Registrar(Ventas obj, List<DetalleVenta> detalle, out string Mensaje)
        {
            Mensaje = string.Empty;

            // --- VALIDACIONES DE SEGURIDAD ---

            if (obj.IdCliente <= 0)
            {
                Mensaje = "Debe seleccionar un cliente para realizar la venta.";
                return false;
            }

            if (obj.IdUsuario <= 0)
            {
                Mensaje = "Error de sesión: No se reconoce el usuario cajero.";
                return false;
            }

            if (detalle == null || detalle.Count == 0)
            {
                Mensaje = "No se puede registrar una venta sin productos.";
                return false;
            }

            // Validación de montos básicos
            if (obj.MontoTotal < 0)
            {
                Mensaje = "El monto total de la venta no puede ser negativo.";
                return false;
            }

            // --- LÓGICA ADICIONAL (Opcional) ---
            // Aquí podrías, por ejemplo, forzar que el Número de Documento 
            // tenga un formato específico antes de guardarlo.
            if (string.IsNullOrEmpty(obj.NumeroDocumento))
            {
                obj.NumeroDocumento = "S/N"; // Sin número si viene vacío
            }

            // Si todo está bien, enviamos a la Capa de Datos
            try
            {
                return objcd_venta.Registrar(obj, detalle, out Mensaje);
            }
            catch (Exception ex)
            {
                Mensaje = "Error en Capa Negocio: " + ex.Message;
                return false;
            }
        }


        public Ventas ObtenerVenta(int idVenta)
        {
            return objcd_venta.ObtenerVenta(idVenta);
        }
        // ==============================================================
        // MÉTODO PARA EL CIERRE DE CAJA
        // ==============================================================
        public DataTable ObtenerTotalesCierreCaja()
        {
            return objcd_venta.ObtenerTotalesDelDiaParaCierre();
        }
    }

}