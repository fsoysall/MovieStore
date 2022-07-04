using AutoMapper;

using MovieStore.Data;
using MovieStore.DbActions;
using MovieStore.UnitTests.TestSetup;


namespace MovieStore.xUnitTestS;


public class xuTestS_Yönetmen : IClassFixture<CommonTextFixture> {

	readonly IMovieStoreDbContext db; readonly IMapper _mapper;
	public xuTestS_Yönetmen(CommonTextFixture textFixture) { db = textFixture.Context; _mapper = textFixture.Mapper; }


	[Fact]
	public void Yönetmen_Testleri_1() {

		// Kayýt Listesine Dair;
		Assert.True(db.Filmler           .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Filmler)}");
		Assert.True(db.Müþteriler        .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Müþteriler)}");
		Assert.True(db.Oyuncular         .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Oyuncular)}");
		Assert.True(db.Yönetmenler       .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Yönetmenler)}");
		Assert.True(db.Kullanýcýlar      .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Kullanýcýlar)}");
		Assert.True(db.Sipariþler        .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Sipariþler)}");
		Assert.True(db.AlýþVeriþler      .Any(), $"KAYIT OLMALIYDI ! {nameof(db.AlýþVeriþler)}");
		Assert.True(db.FilmTürleri       .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmTürleri)}");
		// Assert.True(db                .FilmOyuncularý    .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmOyuncularý)}");
		Assert.True(db.MFavoriFilmTürleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.MFavoriFilmTürleri)}");
		Assert.True(db.OOynananFilmler   .Any(), $"KAYIT OLMALIYDI ! {nameof(db.OOynananFilmler)}");
		Assert.True(db.YönetmeninFilmleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.YönetmeninFilmleri)}");



		// CRUD Ýþlemlerine Dair;

		var dt = DateTime.Now;
		var xYönetmen = new Yönetmen { AdýSoyadý = $"Yönetmeno BuriO {dt.Second}" };
		db.Yönetmenler.Add(xYönetmen); xYönetmen = new Yönetmen { AdýSoyadý = $"Yönetmeno BuriO {dt.Second * 3}" };
		db.Yönetmenler.Add(xYönetmen);
		var r = db.SaveChanges();
		Assert.True(r == 02, $"{r} :: 2 Kayýt EKLENMELÝYDÝ !");


		Yönetmen? Yönetmen2;
		Yönetmen2 = db.Yönetmenler.SingleOrDefault(w => w.AdýSoyadý == xYönetmen.AdýSoyadý);
		Assert.False(Yönetmen2 is null, $"{xYönetmen.AdýSoyadý} BULUNAMADI !");
		Assert.True(Yönetmen2?.AdýSoyadý == xYönetmen.AdýSoyadý, $"{Yönetmen2?.AdýSoyadý} : {xYönetmen.AdýSoyadý} BULUNAMADI !");


		xYönetmen.Id = Yönetmen2.Id;
		xYönetmen.AdýSoyadý += " : 100";
		db.SaveChanges();
		Yönetmen2 = db.Yönetmenler.SingleOrDefault(w => w.AdýSoyadý == xYönetmen.AdýSoyadý);
		Assert.True(xYönetmen.Id == Yönetmen2.Id, $"Yönetmen Id DEÐÝÞMÝÞ !");
		Assert.True(xYönetmen.AdýSoyadý == Yönetmen2.AdýSoyadý, $"BÝZÝM Yönetmen BULUNAMADI ! {xYönetmen.AdýSoyadý} : {Yönetmen2.AdýSoyadý} ");

		db.Yönetmenler.Remove(Yönetmen2); db.SaveChanges();
		var Yönetmen3 = db.Yönetmenler.SingleOrDefault(w => w.AdýSoyadý == Yönetmen2.AdýSoyadý);
		Assert.True(Yönetmen3 is null, $"Kayýt SÝLÝNMEMÝÞ ! : {Yönetmen2.AdýSoyadý}");


		Yönetmen3 = db.Yönetmenler.SingleOrDefault(w => w.Id == Yönetmen2.Id - 1);
		Assert.True(Yönetmen3 is not null, $"KAYIT OLMALIYDI ! {Yönetmen2.Id}");
		if (Yönetmen3 is not null) {
			db.Yönetmenler.Remove(Yönetmen3);
			r = db.SaveChanges();
			Assert.True(r == 1, $"ONULMAYAN ÝÞLEM ADEDÝ ! : {r}");
			}


		Yönetmen3 = db.Yönetmenler.SingleOrDefault(w => w.AdýSoyadý == xYönetmen.AdýSoyadý);
		Assert.True(Yönetmen3 is null, $"Kayýt SÝLÝNMEMÝÞ ! : {xYönetmen.AdýSoyadý}");


		}

	}