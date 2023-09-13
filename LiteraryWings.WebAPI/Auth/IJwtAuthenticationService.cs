using LiteraryWings.EntidadesDeNegocio;

namespace LiteraryWings.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
