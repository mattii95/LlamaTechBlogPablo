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
    public class CategoriaBL
    {
        private CategoriaDA _categoriaDA = new CategoriaDA();

        public DataSet buscarCategoriaNombre(string nombre) => _categoriaDA.buscarCategoriaNombre(nombre);
        public DataSet BuscarCategoriaUsadas(int id) => _categoriaDA.BuscarCategoriasUsadas(id);
        public DataSet BuscarPorId(int id) => _categoriaDA.BuscarPorId(id);
        public List<CategoriaBE> getCategoriasAjax() => _categoriaDA.getCategoriasAjax();
        public DataSet categoriaActiva() => _categoriaDA.getCategoryActive();
        public bool agregarCategoria(CategoriaBE categoriaBE) => _categoriaDA.addCategory(categoriaBE);
        public bool modificarCategoria(CategoriaBE categoriaBE) => _categoriaDA.updateCategory(categoriaBE);
        public bool eliminarCategoria(int id) => _categoriaDA.deleteCategory(id);
    }
}
