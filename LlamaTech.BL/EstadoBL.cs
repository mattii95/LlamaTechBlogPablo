using LlamaTech.DA;
using System.Data;

namespace LlamaTech.BL
{
    public class EstadoBL
    {
        EstadoDA estadoDA = new EstadoDA();

        public DataSet allEstados() => estadoDA.getEstados();
    }
}
