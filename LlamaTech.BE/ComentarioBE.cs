using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaTech.BE
{
    public class ComentarioBE
    {
        public int IdComentario { get; set; }
        public int IdPublicacion { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int IdUsuario { get; set; }

    }
}
