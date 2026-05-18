namespace ASEDUPH_V2_Web.Models
{
    public class Benefactor
    {
        public int BenefactorId { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Direccion { get; set; }
        public string? TipoBenefactor { get; set; }
        public string Estado { get; set; } = "Activo";
        public DateTime FechaRegistro { get; set; }
    }

    public class Aporte
    {
        public int AporteId { get; set; }
        public int BenefactorId { get; set; }
        public int? BecaId { get; set; }
        public DateTime FechaAporte { get; set; }
        public decimal Monto { get; set; }
        public string? TipoAporte { get; set; }
        public string? FormaPago { get; set; }
        public string? Periodo { get; set; }
        public string? NumeroComprobante { get; set; }
        public string? Observaciones { get; set; }

        // Navegación
        public Benefactor? Benefactor { get; set; }
        public Beca? Beca { get; set; }
    }
}
