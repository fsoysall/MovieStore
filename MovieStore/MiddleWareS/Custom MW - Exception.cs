
using System.Diagnostics;
using System.Net;
using System.Text.Json;

using MovieStore.Services;

namespace MiddleWareS;

public class CustomMWException {

	private readonly RequestDelegate _next;
	private readonly ILoggerService? Logger;

	public CustomMWException ( RequestDelegate pNext, ILoggerService? pLogger = null ) {
		this._next = pNext; Logger = pLogger;
		}

	public async Task Invoke ( HttpContext context ) {
		// _logger.Write( $"									{nameof( CustomMWException )}" );

		Logger?.Write( $"[RQ] HTTP: {context.Request.Method} - {context.Request.Path} " );
		var sw = Stopwatch.StartNew();
		var w1 = sw.ElapsedMilliseconds;
		try {
			await _next.Invoke( context );
			}
		catch ( Exception ex ) { sw.Stop(); await HandleException( context, ex, sw ); }
		var w2 = sw.ElapsedMilliseconds;
		sw.Stop();
		Logger?.Write( $"[RQ] HTTP: {context.Request.Method} - {context.Request.Path} responded {context.Response.StatusCode} in {w2} " );

		}

	private Task HandleException ( HttpContext ctx, Exception ex, Stopwatch sw ) {
		var message = $"[ERR] HTTP {ctx.Request.Method} - {ctx.Response.StatusCode} :: in {sw.ElapsedMilliseconds} {ex.Message}  ";
		Logger?.Write( message );

		ctx.Response.ContentType = "application/json";
		ctx.Response.StatusCode = ( int )HttpStatusCode.InternalServerError;
		var result = JsonSerializer.Serialize( new { error = ex.Message } );
		return ctx.Response.WriteAsync( result );

		}
	}

static public class CustomMWExceptionExtensions {
	public static IApplicationBuilder UseCustomMWExceptionExtensions ( this IApplicationBuilder builder ) => builder.UseMiddleware<CustomMWException>();

	}

