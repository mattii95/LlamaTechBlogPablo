using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LlamaTech.BL
{
    public class Security
    {
        public string generarHash(string pass)
        {
            SHA256CryptoServiceProvider sHA256 = new SHA256CryptoServiceProvider();
            string salt = "SalYPimienta123";

            //Almacena la cadena ingresada en una matriz de bytes
            byte[] bPassword = UTF8Encoding.UTF8.GetBytes(pass + salt);

            //Crea el hash
            byte[] bHash = sHA256.ComputeHash(bPassword);

            //Retorna una cadena codificada en base64
            return Convert.ToBase64String(bHash);

        }
    }
}
