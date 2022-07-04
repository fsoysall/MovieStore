using System;

using AutoMapper;

using MovieStore.Data;
using MovieStore.DbActions;
using MovieStore.UnitTests.TestSetup;

namespace MovieStore.xUnitTestS;

public class xuTestS_Müþteri : IClassFixture<CommonTextFixture> {

	readonly MovieStoreDbContext db; readonly IMapper _mapper;
	public xuTestS_Müþteri(CommonTextFixture textFixture) { db = textFixture.Context; _mapper = textFixture.Mapper; }


	[Fact]
	public void Müþteri_Testleri_1() {

		// Kayýt Listesine Dair;
		Assert.True(db.Filmler           .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Filmler                          )}");
		Assert.True(db.Müþteriler        .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Müþteriler                       )}");
		Assert.True(db.Oyuncular         .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Oyuncular                        )}");
		Assert.True(db.Yönetmenler       .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Yönetmenler                      )}");
		Assert.True(db.Kullanýcýlar      .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Kullanýcýlar                     )}");
		Assert.True(db.Sipariþler        .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Sipariþler                       )}");
		Assert.True(db.AlýþVeriþler      .Any(), $"KAYIT OLMALIYDI ! {nameof(db.AlýþVeriþler                     )}");
		Assert.True(db.FilmTürleri       .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmTürleri                      )}");
		//Assert.True(db                 .FilmOyuncularý    .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmOyuncularý)}");
		Assert.True(db.MFavoriFilmTürleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.MFavoriFilmTürleri               )}");
		Assert.True(db.OOynananFilmler   .Any(), $"KAYIT OLMALIYDI ! {nameof(db.OOynananFilmler                  )}");
		Assert.True(db.YönetmeninFilmleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.YönetmeninFilmleri               )}");



		// CRUD Ýþlemlerine Dair;
		int r = 0;
		var dt = DateTime.Now;
		Müþteri? xMüþteri;



		xMüþteri = new Müþteri { AdýSoyadý = $"Müþteri {dt.Second}", EPosta = $"Müþteri_{dt.Second}@test.com", GSM = dt.Ticks.ToString() [..9] };
		db.Müþteriler.Add(xMüþteri);

		xMüþteri = new Müþteri { AdýSoyadý = $"Müþteri {dt.Second * 2}", EPosta = $"Müþteri_{dt.Second * 2}@test.com", GSM = dt.Ticks.ToString() [..9] };
		db.Müþteriler.Add(xMüþteri);
		r = db.SaveChanges();
		Assert.True(r == 02, $"{r} :: 2 Kayýt EKLENMELÝYDÝ !");


		Müþteri? Müþteri2;
		Müþteri2 = db.Müþteriler.SingleOrDefault(w => w.AdýSoyadý == xMüþteri.AdýSoyadý);
		Assert.False(Müþteri2 is null, $"BÝZÝM Müþteri BULUNAMADI ! {xMüþteri.Id} : {xMüþteri.AdýSoyadý} : {xMüþteri.GSM} : {xMüþteri.EPosta} ");
		Assert.True(Müþteri2?.AdýSoyadý == xMüþteri.AdýSoyadý, $"{Müþteri2?.AdýSoyadý} : {xMüþteri.AdýSoyadý} BULUNAMADI !");

		xMüþteri.Id = Müþteri2.Id;
		xMüþteri.AdýSoyadý += " : 100";
		xMüþteri.GSM += 100;
		db.SaveChanges();

		Müþteri2 = db.Müþteriler.SingleOrDefault(w => w.AdýSoyadý == xMüþteri.AdýSoyadý);
		Assert.True(xMüþteri.Id == Müþteri2.Id, $"Müþteri Id DEÐÝÞMÝÞ !");
		Assert.True(xMüþteri.AdýSoyadý == Müþteri2.AdýSoyadý, $"BÝZÝM Müþteri BULUNAMADI ! {xMüþteri.Id} : {xMüþteri.AdýSoyadý} : {xMüþteri.GSM} : {xMüþteri.EPosta} ");
		Assert.True(xMüþteri.GSM == Müþteri2.GSM, $"BÝZÝM GSM DEÐÝL ! {xMüþteri.AdýSoyadý} : {Müþteri2.GSM} : {Müþteri2.EPosta}");

		db.Müþteriler.Remove(Müþteri2); db.SaveChanges();
		var Müþteri3 = db.Müþteriler.SingleOrDefault(w => w.AdýSoyadý == Müþteri2.AdýSoyadý);
		Assert.True(Müþteri3 is null, $"Kayýt SÝLÝNMEMÝÞ ! : {Müþteri2.AdýSoyadý}");

		Müþteri3 = db.Müþteriler.SingleOrDefault(w => w.Id == Müþteri2.Id - 1);
		Assert.True(Müþteri3 is not null, $"KAYIT OLMALIYDI ! {Müþteri2.Id}");
		if (Müþteri3 is not null) {
			db.Müþteriler.Remove(Müþteri3);
			r = db.SaveChanges();
			Assert.True(r == 1, $"ONULMAYAN ÝÞLEM ADEDÝ ! : {r}");
			}


		Müþteri3 = db.Müþteriler.SingleOrDefault(w => w.AdýSoyadý == xMüþteri.AdýSoyadý);
		Assert.True(Müþteri3 is null, $"Kayýt SÝLÝNMEMÝÞ ! : {xMüþteri.AdýSoyadý}");


		}

	}