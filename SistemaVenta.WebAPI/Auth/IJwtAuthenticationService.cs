using SistemaVenta.EntidadesDeNegocio;

namespace SistemaVenta.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
