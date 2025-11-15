using Dato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;

namespace CapaNegocios
{
    public class CN_permisos
    {
        private CD_permisos objetoCD_Permisos = new CD_permisos();


        public List<Permisos> Listar(int idusuario)
        {
            return objetoCD_Permisos.Listar(idusuario);
        }
       
    }
}
