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

            // Validación Número de Documento (Factura)
            if (string.IsNullOrEmpty(obj.NumeroDocumento))
            {
                obj.NumeroDocumento = "S/N";
            }

            // --- NUEVO: Validación Número de Control ---
            if (string.IsNullOrEmpty(obj.NumeroControl))
            {
                obj.NumeroControl = "S/N";
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
        public DataTable ObtenerHistorial3Meses()
        {
            return objcd_venta.ObtenerHistorial3Meses();
        }

        // ====================================================================
        // MÉTODO PARA CALCULAR EL TOTAL VENDIDO POR RANGO DE FECHAS
        // ====================================================================
        public decimal ObtenerTotalVendidoPorRango(DateTime fechaInicio, DateTime fechaFin)
        {
            // Si por error el usuario pone la fecha de inicio mayor a la de fin, las invertimos
            if (fechaInicio > fechaFin)
            {
                DateTime temp = fechaInicio;
                fechaInicio = fechaFin;
                fechaFin = temp;
            }

            return objcd_venta.ObtenerTotalVendidoPorRango(fechaInicio, fechaFin);
        }
    }
}