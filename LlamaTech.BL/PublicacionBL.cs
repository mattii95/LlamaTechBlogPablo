using LlamaTech.BE;
using LlamaTech.DA;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LlamaTech.BL
{
    public class PublicacionBL
    {
        private PublicacionDA _publicacionDA = new PublicacionDA();

        public readonly StringBuilder stringBuilder = new StringBuilder();

        public DataSet allPost() => _publicacionDA.getPosts();
        public DataTable filter(int id) => _publicacionDA.filetCategorias(id);
        public DataTable allPostAct() => _publicacionDA.getPostsActive();
        public DataSet getPostId(int id) => _publicacionDA.getPostID(id);
        public DataSet getFechaPublicacion(int id) => _publicacionDA.getFechaPublicacion(id);
        public DataSet top9Posts() => _publicacionDA.getTop9Posts();
        public DataSet countEntradas() => _publicacionDA.countEntradas();
        public DataSet verDataGrilla() => _publicacionDA.getEntradas();
        public bool addPost(PublicacionBE publicacionBE, PublicacionCategoriaBE publicacionCategoriaBE)
        {
            return _publicacionDA.addPost(publicacionBE, publicacionCategoriaBE);
        }
        public bool editarPost(PublicacionBE publicacionBE, PublicacionCategoriaBE publicacionCategoriaBE)
        {
            return _publicacionDA.updatePost(publicacionBE, publicacionCategoriaBE);
        }

        public bool deletePost(int id)
        {
            return _publicacionDA.deletePost(id);
        }
    }
}
