using MeuSiteEmMVC.Models;
using Newtonsoft.Json;


namespace MeuSiteEmMVC.Helpers
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public  UsuarioModel? BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            // transforma em json
            string usuarioJson = JsonConvert.SerializeObject(usuario);

            // salva na session do sevidor, utiliza cookies
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado",usuarioJson);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
