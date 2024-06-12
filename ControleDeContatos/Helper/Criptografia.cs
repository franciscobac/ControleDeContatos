using System.Security.Cryptography;
using System.Text;

namespace ControleDeContatos.Helper
{
    public static class Criptogrfia
    {
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var enconde = new ASCIIEncoding();
            var array = enconde.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}