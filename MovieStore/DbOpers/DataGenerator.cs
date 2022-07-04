using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

using MovieStore.Data;
using MovieStore.DbActions;
using Microsoft.Extensions.DependencyInjection;

namespace MovieStore.DbOpers {

	public class DataGenerator {

		public static void Initialize(IServiceProvider serviceProvider) {
			using var dbContext = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>());
			Initialize(dbContext);
			}

		public static void Initialize(MovieStoreDbContext db) {


			//using var dbContext = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>());
			//if (dbContext.Database.IsDbExists()) {				dbContext.Database.EnsureDeleted();				dbContext.Database.EnsureCreated();				}

			if (!db.Kullanıcılar.Any()) {
				db.Kullanıcılar.AddRange(
					new Kullanıcı { EMail = "k1@ms.com", FullName = "Kullanıcı 1", Password = "k1" }
					, new Kullanıcı { EMail = "k2@ms.com", FullName = "Kullanıcı 2", Password = "k2" }
					, new Kullanıcı { EMail = "k3@ms.com", FullName = "Kullanıcı 3", Password = "k3" });
				db.SaveChanges();
				}

			if (!db.Filmler.Any()) {
				db.Filmler.AddRange(new Film { /*Id = 1, */ Adı = "Film 1", Fiyat = 1231, YönetmenId = 100, Yılı = "1901", TürId = 1, /*  Oyuncular = new List<int> { 1, 2, 5, 25 } } */ });
				db.Filmler.AddRange(new Film { /*Id = 2, */ Adı = "Film 2", Fiyat = 233, YönetmenId = 202, Yılı = "1902", TürId = 2, /*  Oyuncular = new List<int> { 1, 2, 5, 25 } } */ });
				db.Filmler.AddRange(new Film { /*Id = 3, */ Adı = "Film 3", Fiyat = 32, YönetmenId = 303, Yılı = "1960", TürId = 3, /*  Oyuncular = new List<int> { 1, 2, 5, 25 } } */ });
				db.Filmler.AddRange(new Film { /*Id = 4, */ Adı = "Film 4", Fiyat = 489, YönetmenId = 404, Yılı = "2004", TürId = 4, /*  Oyuncular = new List<int> { 1, 2, 5, 25 } } */ });
				db.Filmler.AddRange(new Film { /*Id = 15,*/  Adı = "Film 15", Fiyat = 15151, YönetmenId = 1515, Yılı = "2015", TürId = 5, /*  Oyuncular = new List<int> { 1, 2, 5, 25 } } */ });
				db.Filmler.AddRange(new Film { /*Id = 26,*/  Adı = "Film 26", Fiyat = 2626, YönetmenId = 1616, Yılı = "2016", TürId = 6, /*  Oyuncular = new List<int> { 1, 2, 5, 25 } } */ });
				db.SaveChanges();
				}

			if (!db.Müşteriler.Any()) {
				db.Müşteriler.AddRange(new Müşteri {/* Id = 1, */AdıSoyadı = "Müşteri 1", EPosta = "m1@musteri.com", /*, FavoriTürler = new List<string> { "1", "2", "4" } */ });
				db.Müşteriler.AddRange(new Müşteri {/* Id = 2, */AdıSoyadı = "Müşteri 2", EPosta = "m2@musteri.com", /*, FavoriTürler = new List<string> { "2", "4", "5" } */ });
				db.Müşteriler.AddRange(new Müşteri {/* Id = 3, */AdıSoyadı = "Müşteri 3", EPosta = "m3@musteri.com", /*, FavoriTürler = new List<string> { "3", "4", "5" } */ });
				db.Müşteriler.AddRange(new Müşteri {/* Id = 4, */AdıSoyadı = "Müşteri 4", EPosta = "m4@musteri.com", /*, FavoriTürler = new List<string> { "4", "5"		 } */ });
				db.Müşteriler.AddRange(new Müşteri {/* Id = 5, */AdıSoyadı = "Müşteri 5", EPosta = "m5@musteri.com", /*, FavoriTürler = new List<string> { "1", "5"		 } */ });
				db.SaveChanges();
				}

			if (!db.MFavoriFilmTürleri.Any()) {
				db.MFavoriFilmTürleri.AddRange(new MFFT(1, 1), new MFFT(1, 3), new MFFT(1, 4));
				db.MFavoriFilmTürleri.AddRange(new MFFT(2, 1), new MFFT(2, 3), new MFFT(2, 4));
				db.MFavoriFilmTürleri.AddRange(new MFFT(3, 1), new MFFT(3, 2));
				db.MFavoriFilmTürleri.AddRange(new MFFT(4, 1), new MFFT(4, 3));
				db.SaveChanges();
				}


			if (!db.Oyuncular.Any()) {
				db.Oyuncular.AddRange(new Oyuncu {/* Id = 1, */AdıSoyadı = "Oyuncu 1", /* OynadığıFilmler = new List<int> { 1, 2, 3, 4, 15, 26 } }  */ });
				db.Oyuncular.AddRange(new Oyuncu {/* Id = 2, */AdıSoyadı = "Oyuncu 2", /* OynadığıFilmler = new List<int> { 2, 3, 4, 15, 26 } }     */ });
				db.Oyuncular.AddRange(new Oyuncu {/* Id = 3, */AdıSoyadı = "Oyuncu 3", /* OynadığıFilmler = new List<int> { 3, 4, 15, 26 } }        */ });
				db.Oyuncular.AddRange(new Oyuncu {/* Id = 4, */AdıSoyadı = "Oyuncu 4", /* OynadığıFilmler = new List<int> { 4, 15, 26 } }           */ });
				db.Oyuncular.AddRange(new Oyuncu {/* Id = 5, */AdıSoyadı = "Oyuncu 5", /* OynadığıFilmler = new List<int> { 1, 2, 3, 4, 15, 26 } }  */ });
				db.Oyuncular.AddRange(new Oyuncu {/* Id = 6, */AdıSoyadı = "Oyuncu 6", /* OynadığıFilmler = new List<int> { 1, 2, 3, 4, 15, 26 } }  */ });
				db.SaveChanges();
				}

			if (!db.OOynananFilmler.Any()) {
				db.OOynananFilmler.AddRange(new OOF(1, 1), new OOF(1, 2), new OOF(1, 3), new OOF(1, 4), new OOF(1, 15), new OOF(1, 26));
				db.OOynananFilmler.AddRange(new OOF(1, 2), new OOF(1, 3), new OOF(1, 4), new OOF(1, 15), new OOF(1, 26));
				db.OOynananFilmler.AddRange(new OOF(1, 3), new OOF(1, 4), new OOF(1, 15));
				db.OOynananFilmler.AddRange(new OOF(1, 4), new OOF(1, 15), new OOF(1, 26));
				db.OOynananFilmler.AddRange(new OOF(1, 3), new OOF(1, 4), new OOF(1, 15));
				db.SaveChanges();
				}


			if (!db.Siparişler.Any()) {
				db.Siparişler.AddRange(new Sipariş {/* Id = 1, */FilmId = 1, MüşteriId = 1, Tarih = DateTime.Now.AddDays(-1) });
				db.Siparişler.AddRange(new Sipariş {/* Id = 2, */FilmId = 2, MüşteriId = 2, Tarih = DateTime.Now.AddDays(-12) });
				db.Siparişler.AddRange(new Sipariş {/* Id = 3, */FilmId = 3, MüşteriId = 3, Tarih = DateTime.Now.AddDays(-13) });
				db.Siparişler.AddRange(new Sipariş {/* Id = 4, */FilmId = 4, MüşteriId = 4, Tarih = DateTime.Now.AddDays(-14) });
				db.SaveChanges();
				}

			if (!db.FilmTürleri.Any()) {

				db.FilmTürleri.AddRange(new FilmTürü {/* Id = 1, */Tür = "F. Tür 1" });
				db.FilmTürleri.AddRange(new FilmTürü {/* Id = 2, */Tür = "F. Tür 2" });
				db.FilmTürleri.AddRange(new FilmTürü {/* Id = 3, */Tür = "F. Tür 3" });
				db.FilmTürleri.AddRange(new FilmTürü {/* Id = 4, */Tür = "F. Tür 4" });
				db.FilmTürleri.AddRange(new FilmTürü {/* Id = 5, */Tür = "F. Tür 5" });
				db.SaveChanges();
				}

			//if (!db.FilmOyuncuları.Any()) {
			//	db.FilmOyuncuları.AddRange(new Oyuncu {/* Id = 1, */ AdıSoyadı = "1. Oyuncu"  });
			//	db.FilmOyuncuları.AddRange(new Oyuncu {/* Id = 2, */ AdıSoyadı = "2. Oyuncu" });
			//	db.FilmOyuncuları.AddRange(new Oyuncu {/* Id = 3, */ AdıSoyadı = "3. Oyuncu" });
			//	db.FilmOyuncuları.AddRange(new Oyuncu {/* Id = 4, */ AdıSoyadı = "4. Oyuncu" });
			//	db.FilmOyuncuları.AddRange(new Oyuncu {/* Id = 5, */ AdıSoyadı = "5. Oyuncu" });
			//	db.FilmOyuncuları.AddRange(new Oyuncu {/* Id = 6, */ AdıSoyadı = "6. Oyuncu" });
			//	db.SaveChanges();
			//	}
			
			if (!db.Yönetmenler.Any()) {
				db.Yönetmenler.AddRange(new Yönetmen {/* Id = 1, */AdıSoyadı = "Yönetmen 1" });
				db.Yönetmenler.AddRange(new Yönetmen {/* Id = 2, */AdıSoyadı = "Yönetmen 2" });
				db.Yönetmenler.AddRange(new Yönetmen {/* Id = 3, */AdıSoyadı = "Yönetmen 3" });
				db.Yönetmenler.AddRange(new Yönetmen {/* Id = 4, */AdıSoyadı = "Yönetmen 4" });
				db.Yönetmenler.AddRange(new Yönetmen {/* Id = 5, */AdıSoyadı = "Yönetmen 5" });
				db.Yönetmenler.AddRange(new Yönetmen {/* Id = 6, */AdıSoyadı = "Yönetmen 6" });
				db.SaveChanges();
				}

			if (!db.YönetmeninFilmleri.Any()) {
				db.YönetmeninFilmleri.AddRange(new YönetmeninFilmleri { YönetmenId = 1, FilmId = 1 },
					new YönetmeninFilmleri { YönetmenId = 1, FilmId = 2 },
					new YönetmeninFilmleri { YönetmenId = 1, FilmId = 4 },
					new YönetmeninFilmleri { YönetmenId = 1, FilmId = 5, });

				db.YönetmeninFilmleri.AddRange(new YönetmeninFilmleri { YönetmenId = 2, FilmId = 1 },
					new YönetmeninFilmleri { YönetmenId = 2, FilmId = 2 },
					new YönetmeninFilmleri { YönetmenId = 2, FilmId = 4 },
					new YönetmeninFilmleri { YönetmenId = 2, FilmId = 5, });

				db.YönetmeninFilmleri.AddRange(new YönetmeninFilmleri { YönetmenId = 5, FilmId = 1 },
					new YönetmeninFilmleri { YönetmenId = 5, FilmId = 2 },
					new YönetmeninFilmleri { YönetmenId = 5, FilmId = 4 },
					new YönetmeninFilmleri { YönetmenId = 5, FilmId = 5, });

				db.YönetmeninFilmleri.AddRange(new YönetmeninFilmleri { YönetmenId = 6, FilmId = 1 },
					new YönetmeninFilmleri { YönetmenId = 6, FilmId = 2 },
					new YönetmeninFilmleri { YönetmenId = 6, FilmId = 4 },
					new YönetmeninFilmleri { YönetmenId = 6, FilmId = 5, });
				db.SaveChanges();
				}

			// var r = dbContext.YönetmeninFilmleri.Where(w => w.Id == 1);

			db.SaveChanges();


			}

		}
	}