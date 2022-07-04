using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovieStore.DbActions;

namespace MovieStore.UnitTests.TestSetup {
	// FilmleriEkle	 	// Filmleri Asist
	// MüşterileriEkle 	// Müşteriler Asist
	// OyuncuEkle		 	// Oyuncu Asist
	// YönetmenEkle	 	// Yönetmen Asist
	// SiparişleriEkle 	// Siparişleri Asist

	internal static class FilmAsist {

		public static void FilmleriEkle(this IMovieStoreDbContext context) {

			//context.FilmleriEkle.AddRange(new Genre { Name = "Personel Growth" }, new Genre { Name = "Science Fiction" }, new Genre { Name = "Romance" });
			//context.SaveChanges();


			}

		}
	}
