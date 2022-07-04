using Microsoft.EntityFrameworkCore;

using MovieStore.Data;

namespace MovieStore.DbActions;

public interface IMovieStoreDbContext {

	public DbSet<Film>                 Filmler            { get; set; }
	public DbSet<Müþteri>              Müþteriler         { get; set; }
	//
	public DbSet<Oyuncu>               Oyuncular          { get; set; }
	//
	public DbSet<Yönetmen>             Yönetmenler        { get; set; }
	//
	public DbSet<Kullanýcý>            Kullanýcýlar       { get; set; }
	//
	public DbSet<Sipariþ>              Sipariþler         { get; set; }
	public DbSet<Sipariþ>              AlýþVeriþler       { get; set; }
	//
	public DbSet<FilmTürü>             FilmTürleri        { get; set; }
	//
	//public DbSet<FilminOyuncularý>     FilmOyuncularý     { get; set; }
	public DbSet<MFFT>                 MFavoriFilmTürleri { get; set; }
	public DbSet<OOF>                  OOynananFilmler    { get; set; }
	public DbSet<YönetmeninFilmleri>   YönetmeninFilmleri { get; set; }

	int SaveChanges ();


	}


