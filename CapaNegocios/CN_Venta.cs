using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class CN_Venta
    {
        private CD_Venta objcd_venta = new CD_Venta();

        public List<Ventas> Listar()
        {
            return objcd_venta.Listar();
        }

        public bool Registrar(Ventas obj, List<DetalleVenta> detalle, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones de negocio
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

            if (obj.MontoTotal < 0)
            {
                Mensaje = "El monto total de la venta no puede ser negativo.";
                return false;
            }

            if (string.IsNullOrEmpty(obj.NumeroDocumento))
            {
                obj.NumeroDocumento = "S/N";
            }

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

        // ====================================================================
        // PUENTES HACIA LA CAPA DE DATOS
        // ====================================================================

        public DataTable ObtenerTotalesCierreCaja()
        {
            return objcd_venta.ObtenerTotalesDelDiaParaCierre();
        }

        public DataTable ObtenerMovimientoProductosDelDia()
        {
            return objcd_venta.ObtenerMovimientoProductosDelDia();
        }

        public List<string> ResumenVentasParaIA()
        {
            return objcd_venta.ResumenVentasParaIA();
        }

        // ====================================================================
        // MÉTODO PARA PROYECCIONES IA (Historial de 3 meses)
        // ====================================================================
        public System.Data.DataTable ObtenerHistorial3Meses()
        {
            return objcd_venta.ObtenerHistorial3Meses();
        }

    }
}