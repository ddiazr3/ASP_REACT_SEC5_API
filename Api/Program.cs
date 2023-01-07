
using Api.Services;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Init Main");


try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddControllers()
        .AddXmlDataContractSerializerFormatters();
    //.addNewtonsoftJson();

    //Registrar Servicios
    /*
     * Hay varios tipos de servicios
     * AddTransient
     * Crea una nueva instancia de un servicio cada ves que es utilizado
     * 
     * AddScoped
     * Reutiliza la misma instancia de un servicio en el mismo HttpRequest
     * 
     * AddSinglento
     * Rreutiliza la misma instancia no importando si es el HttpRequest
     * **/
    builder.Services.AddTransient<IMailService,LocalMailService>();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();    


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();    

    app.UseAuthorization();

    app.UseEndpoints(endpoint =>
    {
        endpoint.MapControllers();
    });

    app.MapRazorPages();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}


