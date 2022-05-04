using System;
using System.Web;

namespace CadeMeuMedico.Repositorios
{
    public class RepositorioCookies
    {
        public static void RegistraCookieAutenticacao(long IDUsuario)
        {
            HttpCookie UserCookie = new HttpCookie("UserCookieAuthentication");
            UserCookie.Values["IDUsuario"] = RepositorioCriptografia.Criptografar(IDUsuario.ToString());
            UserCookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(UserCookie);
        }
    }
}