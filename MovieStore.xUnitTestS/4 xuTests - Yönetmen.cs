using AutoMapper;

using MovieStore.Data;
using MovieStore.DbActions;
using MovieStore.UnitTests.TestSetup;


namespace MovieStore.xUnitTestS;


public class xuTestS_Y�netmen : IClassFixture<CommonTextFixture> {

	readonly IMovieStoreDbContext db; readonly IMapper _mapper;
	public xuTestS_Y�netmen(CommonTextFixture textFixture) { db = textFixture.Context; _mapper = textFixture.Mapper; }


	[Fact]
	public void Y�netmen_Testleri_1() {

		// Kay�t Listesine Dair;
		Assert.True(db.Filmler           .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Filmler)}");
		Assert.True(db.M��teriler        .Any(), $"KAYIT OLMALIYDI ! {nameof(db.M��teriler)}");
		Assert.True(db.Oyuncular         .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Oyuncular)}");
		Assert.True(db.Y�netmenler       .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Y�netmenler)}");
		Assert.True(db.Kullan�c�lar      .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Kullan�c�lar)}");
		Assert.True(db.Sipari�ler        .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Sipari�ler)}");
		Assert.True(db.Al��Veri�ler      .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Al��Veri�ler)}");
		Assert.True(db.FilmT�rleri       .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmT�rleri)}");
		// Assert.True(db                .FilmOyuncular�    .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmOyuncular�)}");
		Assert.True(db.MFavoriFilmT�rleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.MFavoriFilmT�rleri)}");
		Assert.True(db.OOynananFilmler   .Any(), $"KAYIT OLMALIYDI ! {nameof(db.OOynananFilmler)}");
		Assert.True(db.Y�netmeninFilmleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Y�netmeninFilmleri)}");



		// CRUD ��lemlerine Dair;

		var dt = DateTime.Now;
		var xY�netmen = new Y�netmen { Ad�Soyad� = $"Y�netmeno BuriO {dt.Second}" };
		db.Y�netmenler.Add(xY�netmen); xY�netmen = new Y�netmen { Ad�Soyad� = $"Y�netmeno BuriO {dt.Second * 3}" };
		db.Y�netmenler.Add(xY�netmen);
		var r = db.SaveChanges();
		Assert.True(r == 02, $"{r} :: 2 Kay�t EKLENMEL�YD� !");


		Y�netmen? Y�netmen2;
		Y�netmen2 = db.Y�netmenler.SingleOrDefault(w => w.Ad�Soyad� == xY�netmen.Ad�Soyad�);
		Assert.False(Y�netmen2 is null, $"{xY�netmen.Ad�Soyad�} BULUNAMADI !");
		Assert.True(Y�netmen2?.Ad�Soyad� == xY�netmen.Ad�Soyad�, $"{Y�netmen2?.Ad�Soyad�} : {xY�netmen.Ad�Soyad�} BULUNAMADI !");


		xY�netmen.Id = Y�netmen2.Id;
		xY�netmen.Ad�Soyad� += " : 100";
		db.SaveChanges();
		Y�netmen2 = db.Y�netmenler.SingleOrDefault(w => w.Ad�Soyad� == xY�netmen.Ad�Soyad�);
		Assert.True(xY�netmen.Id == Y�netmen2.Id, $"Y�netmen Id DE���M�� !");
		Assert.True(xY�netmen.Ad�Soyad� == Y�netmen2.Ad�Soyad�, $"B�Z�M Y�netmen BULUNAMADI ! {xY�netmen.Ad�Soyad�} : {Y�netmen2.Ad�Soyad�} ");

		db.Y�netmenler.Remove(Y�netmen2); db.SaveChanges();
		var Y�netmen3 = db.Y�netmenler.SingleOrDefault(w => w.Ad�Soyad� == Y�netmen2.Ad�Soyad�);
		Assert.True(Y�netmen3 is null, $"Kay�t S�L�NMEM�� ! : {Y�netmen2.Ad�Soyad�}");


		Y�netmen3 = db.Y�netmenler.SingleOrDefault(w => w.Id == Y�netmen2.Id - 1);
		Assert.True(Y�netmen3 is not null, $"KAYIT OLMALIYDI ! {Y�netmen2.Id}");
		if (Y�netmen3 is not null) {
			db.Y�netmenler.Remove(Y�netmen3);
			r = db.SaveChanges();
			Assert.True(r == 1, $"ONULMAYAN ��LEM ADED� ! : {r}");
			}


		Y�netmen3 = db.Y�netmenler.SingleOrDefault(w => w.Ad�Soyad� == xY�netmen.Ad�Soyad�);
		Assert.True(Y�netmen3 is null, $"Kay�t S�L�NMEM�� ! : {xY�netmen.Ad�Soyad�}");


		}

	}