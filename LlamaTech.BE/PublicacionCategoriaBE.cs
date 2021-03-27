using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaTech.BE
{
    public class PublicacionCategoriaBE : CategoriaBE
    {
        public int IdPublicacion { get; set; }
        public new int IdCategoria { get; set; }
    }
}
