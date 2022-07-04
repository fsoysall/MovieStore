
using System.Text.Json;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using MovieStore.Data;

namespace MovieStore.DbActions;


public class MovieStoreDbContext : DbContext, IMovieStoreDbContext {


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public MovieStoreDbContext() : base() { }
	public MovieStoreDbContext(DbContextOptions options) : base(options) { }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public DbSet<Film> Filmler { get; set; }
	public DbSet<Müşteri> Müşteriler { get; set; }
	//
	public DbSet<Oyuncu> Oyuncular { get; set; }
	//
	public DbSet<Yönetmen> Yönetmenler { get; set; }
	//
	public DbSet<Kullanıcı> Kullanıcılar { get; set; }
	//
	public DbSet<Sipariş> Siparişler { get; set; }
	public DbSet<Sipariş> AlışVerişler { get; set; }
	//
	public DbSet<FilmTürü> FilmTürleri { get; set; }
	//
	//public DbSet<FilminOyuncuları>     FilmOyuncuları     { get; set; }
	public DbSet<MFFT> MFavoriFilmTürleri { get; set; }
	public DbSet<OOF> OOynananFilmler { get; set; }
	public DbSet<YönetmeninFilmleri> YönetmeninFilmleri { get; set; }

	protected override void OnModelCreating(ModelBuilder builder) {
		// base.OnModelCreating( builder );

		//var splitStringConverter = new ValueConverter<IEnumerable<string>, string>( v => string.Join( ";", v ), v => v.Split( new [ ] { ';' } ) );
		//builder.Entity<Müşteri>().Property( nameof( Müşteri.FavoriTürler ) ).HasConversion( splitStringConverter );

		//builder.Entity<Müşteri>().Property( e=>e.FavoriTürler.has )

		//builder.Entity<Müşteri>().Property( e => e.FavoriTürler );
		//v2 => ( eFilmTürleri )Enum.Parse( typeof( eFilmTürleri ), v2 ) );

		//builder.Entity<Müşteri>().Property( e => e.FavoriTürler )
		// .HasConversion(
		//	i => string.Join( ",", i ),
		//	s =>  string.IsNullOrWhiteSpace( s ) ? Array.Empty<int>() : s.Split( ',' ).Select( v => int.Parse( v ) )
		//	);


		}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		//optionsBuilder.LogTo(Console.WriteLine);
		//base.OnConfiguring(optionsBuilder);
		optionsBuilder
			.UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole().AddFilter(level => level >= LogLevel.Debug)))
			.EnableSensitiveDataLogging()
			.EnableDetailedErrors();
		}

	}


	


//public static class DatabaseFacadeExtensions {
//	public static bool IsDbExists(this DatabaseFacade source) {		return source.GetService<IRelationalDatabaseCreator>().Exists();
//		}
//	}