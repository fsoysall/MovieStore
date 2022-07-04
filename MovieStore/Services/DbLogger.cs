namespace MovieStore.Services;

public class DbLogger : ILoggerService {

	void ILoggerService.Write ( string message ) {
		Console.WriteLine( "[DbLogger] - " + message );
		}
	}
