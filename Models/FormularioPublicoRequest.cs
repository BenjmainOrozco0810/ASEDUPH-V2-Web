namespace ASEDUPH_V2_Web.Models
{
    public class FormularioPublicoRequest
    {
        // ── Datos del Estudiante ──────────────────────────────────────
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Municipio { get; set; }
        public string? Departamento { get; set; }

        // ── Datos del Encargado ───────────────────────────────────────
        public string NombreEncargado { get; set; } = string.Empty;
        public string? EstadoCivil { get; set; }
        public string? DPI { get; set; }
        public string? DpiExtendido { get; set; }
        public string? TelefonoDomiciliar { get; set; }
        public string? TelefonoCelular { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? DireccionEncargado { get; set; }
        public string? Ocupacion { get; set; }
        public string? LugarTrabajo { get; set; }
        public string? TelefonoTrabajo { get; set; }

        // ── Datos de la Solicitud ─────────────────────────────────────
        public string? NivelEducativo { get; set; }
        public string? GradoSolicitado { get; set; }
        public string? CentroEducativo { get; set; }
        public decimal? PromedioActual { get; set; }
        public string? MotivoSolicitud { get; set; }

        // ── Tipos de apoyo solicitados ────────────────────────────────
        public bool ApoyoCuotas { get; set; }
        public bool ApoyoUtiles { get; set; }
        public bool ApoyoUniformes { get; set; }
        public string? OtroApoyo { get; set; }
    }
}