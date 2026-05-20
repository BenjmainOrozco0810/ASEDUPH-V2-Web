namespace ASEDUPH_V2_Web.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo";
        public DateTime FechaRegistro { get; set; }
        public List<string> Roles { get; set; } = new();
    }

    public class CrearUsuarioRequest
    {
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<int> RolIds { get; set; } = new();
    }

    public class ActualizarUsuarioRequest
    {
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Correo { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo";
    }

    public class CambiarPasswordRequest
    {
        public string NuevaPassword { get; set; } = string.Empty;
    }

    public class Rol
    {
        public int RolId { get; set; }
        public string NombreRol { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}
