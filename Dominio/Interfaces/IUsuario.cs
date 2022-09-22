using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUsuario
    {
        Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular);

        Task<bool> ExisteUsuario(string email, string senha);
<<<<<<< HEAD
=======

>>>>>>> 37ff0b1c50094726404f8f4ac9e73cb5e694444a
        Task<string> RetornaIdUsuario(string email);
    }
}
