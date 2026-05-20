namespace ASEDUPH_V2_Web.Models
{
    public class TipoApoyo
    {
        public int TipoApoyoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}
