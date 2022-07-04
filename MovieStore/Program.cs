using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

using MovieStore.DbActions;
using MovieStore.Services;
using MiddleWareS;
using MovieStore.DbOpers;
using Microsoft.Extensions.Options;

//using Autofac.Extensions.DependencyInjection;

IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var builder = WebApplication.CreateBuilder(args);
//var builder = WebApplication.CreateBuilder( new WebApplicationOptions { WebRootPath = "customwwwroot" , ApplicationName = typeof( Program ).Assembly.FullName, ContentRootPath = Directory.GetCurrentDirectory(), EnvironmentName = Environments.Staging, 	} );
Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath: {builder.Environment.WebRootPath}");


builder.Host.ConfigureAppConfiguration((hostingContext, config) => config.AddJsonFile("MyConfig.json", optional: true, reloadOnChange: true));

builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(5)); // Wait 30 seconds for graceful shutdown.
																												 // builder.WebHost.UseHttpSys(); // Change the HTTP server implementation to be HTTP.sys based. // Windows only.
																												 // builder.Configuration.AddIniFile( "appsettings.ini" );


// builder.Host.UseServiceProviderFactory( new AutofacServiceProviderFactory() );
// builder.Host.ConfigureContainer<ContainerBuilder>( builder => builder.RegisterModule( new MyApplicationModule() ) ); // Register services directly with Autofac here. Don't call builder.Populate(), that happens in AutofacServiceProviderFactory.

// builder.Services.AddSingleton<IHelloService, HelloService>();

builder.Logging.AddJsonConsole(); // Configure JSON logging to the console.



builder.Services.AddAuthentication(
													o1 => {
														o1.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
														o1.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
													})
													.AddJwtBearer(oJwt => {
														oJwt.TokenValidationParameters = new TokenValidationParameters {
															ValidateAudience = true, ValidateIssuer = true, ValidateLifetime = true
															, ValidIssuer = Configuration ["Token:Issuer"], ValidAudience = Configuration ["Token:Audience"]
															, IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration ["Token:SecurityKey"]))
															, ClockSkew = TimeSpan.Zero,
															};
														oJwt.Events = oJwt.Events = new JwtBearerEvents {
															OnTokenValidated = ctx => { return Task.CompletedTask;/* Gerekirse burada gelen token içerisindeki çeþitli bilgilere göre doðrulam yapýlabilir. */ },
															OnAuthenticationFailed = ctx => { Console.WriteLine("Exception:{0}", ctx.Exception.Message); return Task.CompletedTask; }
															};
													});





// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//					builder.Build(); //
//					builder.Build(); //
var services = builder.Services;

services.AddAutoMapper(Assembly.GetExecutingAssembly());
services.AddDbContext<MovieStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "MovieStoreDB"));
//services.AddDbContext<MovieStoreDbContext>( o => o.UseSqlServer( Configuration.GetConnectionString( "MovieStoreDB" ) ) );

services.AddScoped<MovieStoreDbContext , MovieStoreDbContext>(); // services.AddScoped<MovieStoreDbContext >( p => p.GetService<MovieStoreDbContext>() );
services.AddSingleton<ILoggerService, ConsoleLogger>();

builder.Services.AddMemoryCache();     // Add the memory cache services.
													//builder.Services.AddScoped<ITodoRepository, TodoRepository>();    // Add a custom scoped service.


var app = builder.Build();
var host = app;

using (var scope = host.Services.CreateScope()) {
	var services2 = scope.ServiceProvider;   //3. Get the instance of BoardGamesDBContext in our services layer
	DataGenerator.Initialize(services2); //4. Call the DataGenerator to create sample data

	// LinqPractices.DataGenerator.Initialize(); //4. Call the DataGenerator to create sample data
	// LinqPractices.LinqDbContext linqDbContext = new LinqPractices.LinqDbContext();
	// var Students= linqDbContext.Students.ToList();
	}

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }

app.UseAuthentication();
Debug.Print($"								it's starts...{DateTime.Now} ");
app.UseCustomMWExceptionExtensions();
app.UseHelloMW();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/zAssist/hw", () => "Hello World!");

// var helloService = app.Services.GetRequiredService<IHelloService>();
// app.MapGet( "/", async context => { await context.Response.WriteAsync( helloService.HelloMessage ); } );


app.Run();
