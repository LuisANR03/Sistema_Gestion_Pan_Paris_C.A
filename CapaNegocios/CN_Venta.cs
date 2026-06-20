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
            // ... (todo tu código de validaciones que está perfecto) ...
            Mensaje = string.Empty;

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

        public DataTable ObtenerTotalesCierreCaja()
        {
            return objcd_venta.ObtenerTotalesDelDiaParaCierre();
        }

        // --- ¡AQUÍ ESTÁ EL MÉTODO NUEVO PARA LA IA! ---
        public List<string> ResumenVentasParaIA()
        {
            return objcd_venta.ResumenVentasParaIA();
        }
    }
}