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
    public class SubCategoriaBL
    {
        private SubCategoriaDA subCategoriaDA = new SubCategoriaDA();

        public DataSet allSubCategorys() => subCategoriaDA.getSubCategory();

        public DataSet subCategoriaActiva(int id)
        {
           return subCategoriaDA.getSubCategoryActive(id);
        }
        public DataSet subCategoriaId(int id)
        {
            return subCategoriaDA.getSubCategoryId(id);
        }
        public List<SubCategoriaBE> subCategoriaAjax(int id)
        {
            return subCategoriaDA.getSubCategoryAjax(id);
        }
        public bool agregarCategoria(SubCategoriaBE subCategoriaBE) => subCategoriaDA.agregarSub(subCategoriaBE);
        public bool modificarCategoria(SubCategoriaBE subCategoriaBE) => subCategoriaDA.modificarSub(subCategoriaBE);
        public bool eliminarCategoria(int id) => subCategoriaDA.eliminarSub(id);
    }
}
