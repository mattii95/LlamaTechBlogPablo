using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaTech.BE
{
    public class ImagenBE
    {
        public int IdImagen { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public int IdUsuario { get; set; }
    }
}
