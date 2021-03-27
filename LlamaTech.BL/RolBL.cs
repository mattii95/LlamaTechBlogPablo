using LlamaTech.BE;
using LlamaTech.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaTech.BL
{
    public class RolBL
    {
        private RolDA rolDA = new RolDA();

        public DataSet allRols() => rolDA.getRoles();
        public DataSet rolActiveId(int idRol) => rolDA.getRolActivoId(idRol);
        public DataSet rolActive() => rolDA.getRolActivo();
        public void agregarRol(RolBE rolBE) => rolDA.addRol(rolBE);
        public void modificarRol(RolBE rolBE) => rolDA.updateRol(rolBE);
        public void eliminarRol(int id) => rolDA.deleteRol(id);
    }
}
