using Microsoft.EntityFrameworkCore;

using MovieStore.Data;

namespace MovieStore.DbActions;

public interface IMovieStoreDbContext {

	public DbSet<Film>                 Filmler            { get; set; }
	public DbSet<M��teri>              M��teriler         { get; set; }
	//
	public DbSet<Oyuncu>               Oyuncular          { get; set; }
	//
	public DbSet<Y�netmen>             Y�netmenler        { get; set; }
	//
	public DbSet<Kullan�c�>            Kullan�c�lar       { get; set; }
	//
	public DbSet<Sipari�>              Sipari�ler         { get; set; }
	public DbSet<Sipari�>              Al��Veri�ler       { get; set; }
	//
	public DbSet<FilmT�r�>             FilmT�rleri        { get; set; }
	//
	//public DbSet<FilminOyuncular�>     FilmOyuncular�     { get; set; }
	public DbSet<MFFT>                 MFavoriFilmT�rleri { get; set; }
	public DbSet<OOF>                  OOynananFilmler    { get; set; }
	public DbSet<Y�netmeninFilmleri>   Y�netmeninFilmleri { get; set; }

	int SaveChanges ();


	}


