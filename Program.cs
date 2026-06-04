using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ASEDUPH_V2_Web;
using ASEDUPH_V2_Web.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Handler que agrega el token JWT a todas las peticiones
builder.Services.AddScoped<AuthTokenHandler>();

// Conexión con el backend (con el handler de autenticación)
builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<AuthTokenHandler>();
    handler.InnerHandler = new HttpClientHandler();

    return new HttpClient(handler)
    {
        BaseAddress = new Uri("https://localhost:7194/")
    };
});

// MudBlazor
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = true;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
});

// Servicios de la aplicación
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<EstudianteService>();
builder.Services.AddScoped<EncargadoService>();
builder.Services.AddScoped<SolicitudBecaService>();
builder.Services.AddScoped<BecaService>();
builder.Services.AddScoped<BenefactorService>();
builder.Services.AddScoped<EvaluacionBecaService>();
builder.Services.AddScoped<VisitaFamiliarService>();
builder.Services.AddScoped<SeguimientoAcademicoService>();
builder.Services.AddScoped<RenovacionBecaService>();

await builder.Build().RunAsync();
