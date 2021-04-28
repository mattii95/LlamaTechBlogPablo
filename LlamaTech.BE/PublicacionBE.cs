using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaTech.BE
{
    public class PublicacionBE : PublicacionCategoriaBE
    {
        public new int IdPublicacion { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public string Slug { get; set; }
        public int IdUsuario { get; set; }
        public int idEstado { get; set; }

    }
}
