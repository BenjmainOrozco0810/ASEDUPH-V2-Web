namespace ASEDUPH_V2_Web.Models
{
    public class LogAuditoria
    {
        public int LogAuditoriaId { get; set; }
        public int? UsuarioId { get; set; }
        public string? NombreUsuario { get; set; }
        public string Accion { get; set; } = string.Empty;
        public string Modulo { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string? EntidadAfectada { get; set; }
        public int? EntidadId { get; set; }
        public DateTime FechaHora { get; set; }
        public string? DireccionIP { get; set; }
        public string? Resultado { get; set; }
    }
}
