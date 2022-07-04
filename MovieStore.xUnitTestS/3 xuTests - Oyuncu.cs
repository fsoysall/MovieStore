using AutoMapper;

using MovieStore.Data;
using MovieStore.DbActions;
using MovieStore.UnitTests.TestSetup;

namespace MovieStore.xUnitTestS;

public class xuTestS_Oyuncu : IClassFixture<CommonTextFixture> {

	readonly IMovieStoreDbContext db; readonly IMapper _mapper;
	public xuTestS_Oyuncu(CommonTextFixture textFixture) { db = textFixture.Context; _mapper = textFixture.Mapper; }


	[Fact]
	public void Oyuncu_Testleri_1() {

		// Kayýt Listesine Dair;
		Assert.True(db.Filmler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Filmler)}");
		Assert.True(db.Müþteriler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Müþteriler)}");
		Assert.True(db.Oyuncular.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Oyuncular)}");
		Assert.True(db.Yönetmenler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Yönetmenler)}");
		Assert.True(db.Kullanýcýlar.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Kullanýcýlar)}");
		Assert.True(db.Sipariþler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Sipariþler)}");
		Assert.True(db.AlýþVeriþler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.AlýþVeriþler)}");
		Assert.True(db.FilmTürleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmTürleri)}");
		//// Assert.True(db.FilmOyuncularý    .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmOyuncularý)}");
		Assert.True(db.MFavoriFilmTürleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.MFavoriFilmTürleri)}");
		Assert.True(db.OOynananFilmler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.OOynananFilmler)}");
		Assert.True(db.YönetmeninFilmleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.YönetmeninFilmleri)}");




		// CRUD Ýþlemlerine Dair;
		int r = 0;
		var dt = DateTime.Now;
		Oyuncu? xOyuncu;



		xOyuncu = new Oyuncu { AdýSoyadý = $"Oyuncu {dt.Second}"  };
		db.Oyuncular.Add(xOyuncu);

		xOyuncu = new Oyuncu { AdýSoyadý = $"Oyuncu {dt.Second * 2}" };
		db.Oyuncular.Add(xOyuncu);
		r = db.SaveChanges();
		Assert.True(r == 02, $"{r} :: 2 Kayýt EKLENMELÝYDÝ !");


		Oyuncu? Oyuncu2;
		Oyuncu2 = db.Oyuncular.SingleOrDefault(w => w.AdýSoyadý == xOyuncu.AdýSoyadý);
		Assert.False(Oyuncu2 is null, $"{xOyuncu.AdýSoyadý} BULUNAMADI !");
		Assert.True(Oyuncu2?.AdýSoyadý == xOyuncu.AdýSoyadý, $"BÝZÝM Oyuncu BULUNAMADI ! {xOyuncu.Id} : {xOyuncu.AdýSoyadý}");

		xOyuncu.Id = Oyuncu2.Id;
		xOyuncu.AdýSoyadý += " : 100";
		db.SaveChanges();
		Oyuncu2 = db.Oyuncular.SingleOrDefault(w => w.AdýSoyadý == xOyuncu.AdýSoyadý);
		Assert.True(xOyuncu.Id == Oyuncu2.Id, $"Oyuncu Id DEÐÝÞMÝÞ !");
		Assert.True(xOyuncu.AdýSoyadý == Oyuncu2.AdýSoyadý, $"BÝZÝM Oyuncu BULUNAMADI ! {xOyuncu.Id} : {xOyuncu.AdýSoyadý}");

		db.Oyuncular.Remove(Oyuncu2); db.SaveChanges();
		var Oyuncu3 = db.Oyuncular.SingleOrDefault(w => w.AdýSoyadý == Oyuncu2.AdýSoyadý);
		Assert.True(Oyuncu3 is null, $"Kayýt SÝLÝNMEMÝÞ ! : {xOyuncu.AdýSoyadý}");

		Oyuncu3 = db.Oyuncular.SingleOrDefault(w => w.Id == Oyuncu2.Id - 1);
		Assert.True(Oyuncu3 is not null, $"KAYIT OLMALIYDI ! {Oyuncu2.Id}");
		if (Oyuncu3 is not null) {
			db.Oyuncular.Remove(Oyuncu3);
			r = db.SaveChanges();
			Assert.True(r == 1, $"ONULMAYAN ÝÞLEM ADEDÝ ! : {r}");
			}


		Oyuncu3 = db.Oyuncular.SingleOrDefault(w => w.AdýSoyadý == xOyuncu.AdýSoyadý);
		Assert.True(Oyuncu3 is null, $"Kayýt SÝLÝNMEMÝÞ ! : {xOyuncu.AdýSoyadý}");


		}

	}