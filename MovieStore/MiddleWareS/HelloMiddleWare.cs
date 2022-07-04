namespace MiddleWareS;

public class HelloMiddleWare {

	private readonly RequestDelegate _next;

	public HelloMiddleWare ( RequestDelegate next ) { this._next = next; }

	public async Task Invoke ( HttpContext context ) {
		// Debug.Print( $"{nameof( HelloMiddleWare )}" );
		await _next.Invoke( context );
		// Debug.Print( $"{nameof( HelloMiddleWare )} : END" );
		}

	}

static public class HelloMiddleWareExtensions {
	public static IApplicationBuilder UseHelloMW ( this IApplicationBuilder builder ) => builder.UseMiddleware<HelloMiddleWare>();

	}

