using ARAINV.Infrastructure.Middleware;
using ARAINV.Infrastructure.Extensions.ApplicationBuilder;
using ARAINV.Infrastructure.Extensions.ServiceCollection;
using ARAINV.Infrastructure.Mappings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
ServiceExtension.AddApplicationLayer(builder.Services, builder.Configuration);

// Añadir controladores y configurar json
CtrlCfg.AddControllersExtend(builder.Services);

/* Contener de las configuración de conexión a BD en los contextos */
DbCtx.AddDbContexts(builder.Services, builder.Configuration);

/* Implementa el tipo Factory */
DBCtxFactory.AddDBFactory(builder.Services);

/* Contenedor de inversion de control (IoC) => Middleware. */
IoC.AddDependency(builder.Services);

builder.Services.AddTransient<ErrorHandleMiddleware>();


var app = builder.Build();

DefaultCfg.InitConfigurationAPI(app, builder.Environment);
app.UseMiddleware<ErrorHandleMiddleware>();

app.Run();