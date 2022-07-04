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

		// Kay�t Listesine Dair;
		Assert.True(db.Filmler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Filmler)}");
		Assert.True(db.M��teriler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.M��teriler)}");
		Assert.True(db.Oyuncular.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Oyuncular)}");
		Assert.True(db.Y�netmenler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Y�netmenler)}");
		Assert.True(db.Kullan�c�lar.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Kullan�c�lar)}");
		Assert.True(db.Sipari�ler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Sipari�ler)}");
		Assert.True(db.Al��Veri�ler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Al��Veri�ler)}");
		Assert.True(db.FilmT�rleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmT�rleri)}");
		//// Assert.True(db.FilmOyuncular�    .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmOyuncular�)}");
		Assert.True(db.MFavoriFilmT�rleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.MFavoriFilmT�rleri)}");
		Assert.True(db.OOynananFilmler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.OOynananFilmler)}");
		Assert.True(db.Y�netmeninFilmleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Y�netmeninFilmleri)}");




		// CRUD ��lemlerine Dair;
		int r = 0;
		var dt = DateTime.Now;
		Oyuncu? xOyuncu;



		xOyuncu = new Oyuncu { Ad�Soyad� = $"Oyuncu {dt.Second}"  };
		db.Oyuncular.Add(xOyuncu);

		xOyuncu = new Oyuncu { Ad�Soyad� = $"Oyuncu {dt.Second * 2}" };
		db.Oyuncular.Add(xOyuncu);
		r = db.SaveChanges();
		Assert.True(r == 02, $"{r} :: 2 Kay�t EKLENMEL�YD� !");


		Oyuncu? Oyuncu2;
		Oyuncu2 = db.Oyuncular.SingleOrDefault(w => w.Ad�Soyad� == xOyuncu.Ad�Soyad�);
		Assert.False(Oyuncu2 is null, $"{xOyuncu.Ad�Soyad�} BULUNAMADI !");
		Assert.True(Oyuncu2?.Ad�Soyad� == xOyuncu.Ad�Soyad�, $"B�Z�M Oyuncu BULUNAMADI ! {xOyuncu.Id} : {xOyuncu.Ad�Soyad�}");

		xOyuncu.Id = Oyuncu2.Id;
		xOyuncu.Ad�Soyad� += " : 100";
		db.SaveChanges();
		Oyuncu2 = db.Oyuncular.SingleOrDefault(w => w.Ad�Soyad� == xOyuncu.Ad�Soyad�);
		Assert.True(xOyuncu.Id == Oyuncu2.Id, $"Oyuncu Id DE���M�� !");
		Assert.True(xOyuncu.Ad�Soyad� == Oyuncu2.Ad�Soyad�, $"B�Z�M Oyuncu BULUNAMADI ! {xOyuncu.Id} : {xOyuncu.Ad�Soyad�}");

		db.Oyuncular.Remove(Oyuncu2); db.SaveChanges();
		var Oyuncu3 = db.Oyuncular.SingleOrDefault(w => w.Ad�Soyad� == Oyuncu2.Ad�Soyad�);
		Assert.True(Oyuncu3 is null, $"Kay�t S�L�NMEM�� ! : {xOyuncu.Ad�Soyad�}");

		Oyuncu3 = db.Oyuncular.SingleOrDefault(w => w.Id == Oyuncu2.Id - 1);
		Assert.True(Oyuncu3 is not null, $"KAYIT OLMALIYDI ! {Oyuncu2.Id}");
		if (Oyuncu3 is not null) {
			db.Oyuncular.Remove(Oyuncu3);
			r = db.SaveChanges();
			Assert.True(r == 1, $"ONULMAYAN ��LEM ADED� ! : {r}");
			}


		Oyuncu3 = db.Oyuncular.SingleOrDefault(w => w.Ad�Soyad� == xOyuncu.Ad�Soyad�);
		Assert.True(Oyuncu3 is null, $"Kay�t S�L�NMEM�� ! : {xOyuncu.Ad�Soyad�}");


		}

	}