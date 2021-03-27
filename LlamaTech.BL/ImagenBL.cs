using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LlamaTech.BE;
using LlamaTech.DA;

namespace LlamaTech.BL
{
    public class ImagenBL
    {
        private ImagenDA imagenDA = new ImagenDA();

        public DataSet allImages() => imagenDA.getImages();
        public DataSet filter(string text) => imagenDA.filterGridView(text);

        public void addImagen(ImagenBE imagenBE) => imagenDA.addImagen(imagenBE);
        public void updateImage(ImagenBE imagen) => imagenDA.updateImage(imagen);
        public void updateNoImage(ImagenBE imagen) => imagenDA.updateNoImage(imagen);
        public void deleteImage(int id) => imagenDA.deleteImagen(id);
        public List<ImagenBE> getImages(string searchImg) => imagenDA.getImagesByAlt(searchImg);
        public DataSet getImagesPath(string path) => imagenDA.getImagesByPath(path);
        public List<ImagenBE> getImagesPathAjx(string path) => imagenDA.getImagesByPathAjx(path);

    }
}
