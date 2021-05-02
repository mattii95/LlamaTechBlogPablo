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
    public class UsuarioBL
    {
        private UsuarioDA usuarioDA = new UsuarioDA();

        public DataSet allUsers() => usuarioDA.getUsers();
        public DataSet countUsers() => usuarioDA.countUsers();
        public DataSet login(string email, string pass) => usuarioDA.login(email, pass);
        public List<UsuarioBE> getEmail(string email) => usuarioDA.getEmail(email);
        public void agregarUser(UsuarioBE usuarioBE) => usuarioDA.addUser(usuarioBE);
        public void modificarUser(UsuarioBE usuarioBE) => usuarioDA.updateUser(usuarioBE);
        public bool modificarUserSinFoto(UsuarioBE usuarioBE) => usuarioDA.updateUserSinFoto(usuarioBE);
        public bool modificarUserPass(UsuarioBE usuarioBE) => usuarioDA.updatePass(usuarioBE);
        public bool eliminarUser(int id) => usuarioDA.deleteUser(id);
    }
}
