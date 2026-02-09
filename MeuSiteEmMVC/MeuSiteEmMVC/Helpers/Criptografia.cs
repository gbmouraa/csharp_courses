using System.Security.Cryptography;
using System.Text;

namespace MeuSiteEmMVC.Helpers
{
    public static class Criptografia
    {   // método de extensão de uma string para gerar hash a partir de uma string,
        // exemplo de uso : string senhaHash = "minhaSenha".GerarHash();
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);

            array = hash.ComputeHash(array);
            var strHex = new StringBuilder();

            foreach (var item in array)
            {
                strHex.Append(item.ToString("X2"));
            }

            return strHex.ToString();
        }
    }
}
