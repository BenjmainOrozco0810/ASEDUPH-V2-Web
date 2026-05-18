namespace ASEDUPH_V2_Web.Models
{
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public UsuarioInfo Usuario { get; set; } = new();
    }

    public class UsuarioInfo
    {
        public int UsuarioId { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new();
    }
}