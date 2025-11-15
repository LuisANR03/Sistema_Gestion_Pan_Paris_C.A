using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dato;

namespace CapaNegocios
{
    public class CN_rol
    {
        private CD_rol objetoCD_Rol = new CD_rol();


        public List<Rol> Listar()
        {
            return objetoCD_Rol.Listar();
        }
    }
}
