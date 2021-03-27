using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaTech.BE
{
    public class UsuarioBE
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string CodVerificacion { get; set; }
        public string FotoPerfil { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaConexion { get; set; }
        public int IdRol { get; set; }
        public bool Status { get; set; }
    }
}
