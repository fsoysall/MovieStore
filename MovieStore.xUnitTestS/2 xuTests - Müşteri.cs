using System;

using AutoMapper;

using MovieStore.Data;
using MovieStore.DbActions;
using MovieStore.UnitTests.TestSetup;

namespace MovieStore.xUnitTestS;

public class xuTestS_M��teri : IClassFixture<CommonTextFixture> {

	readonly MovieStoreDbContext db; readonly IMapper _mapper;
	public xuTestS_M��teri(CommonTextFixture textFixture) { db = textFixture.Context; _mapper = textFixture.Mapper; }


	[Fact]
	public void M��teri_Testleri_1() {

		// Kay�t Listesine Dair;
		Assert.True(db.Filmler           .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Filmler                          )}");
		Assert.True(db.M��teriler        .Any(), $"KAYIT OLMALIYDI ! {nameof(db.M��teriler                       )}");
		Assert.True(db.Oyuncular         .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Oyuncular                        )}");
		Assert.True(db.Y�netmenler       .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Y�netmenler                      )}");
		Assert.True(db.Kullan�c�lar      .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Kullan�c�lar                     )}");
		Assert.True(db.Sipari�ler        .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Sipari�ler                       )}");
		Assert.True(db.Al��Veri�ler      .Any(), $"KAYIT OLMALIYDI ! {nameof(db.Al��Veri�ler                     )}");
		Assert.True(db.FilmT�rleri       .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmT�rleri                      )}");
		//Assert.True(db                 .FilmOyuncular�    .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmOyuncular�)}");
		Assert.True(db.MFavoriFilmT�rleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.MFavoriFilmT�rleri               )}");
		Assert.True(db.OOynananFilmler   .Any(), $"KAYIT OLMALIYDI ! {nameof(db.OOynananFilmler                  )}");
		Assert.True(db.Y�netmeninFilmleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Y�netmeninFilmleri               )}");



		// CRUD ��lemlerine Dair;
		int r = 0;
		var dt = DateTime.Now;
		M��teri? xM��teri;



		xM��teri = new M��teri { Ad�Soyad� = $"M��teri {dt.Second}", EPosta = $"M��teri_{dt.Second}@test.com", GSM = dt.Ticks.ToString() [..9] };
		db.M��teriler.Add(xM��teri);

		xM��teri = new M��teri { Ad�Soyad� = $"M��teri {dt.Second * 2}", EPosta = $"M��teri_{dt.Second * 2}@test.com", GSM = dt.Ticks.ToString() [..9] };
		db.M��teriler.Add(xM��teri);
		r = db.SaveChanges();
		Assert.True(r == 02, $"{r} :: 2 Kay�t EKLENMEL�YD� !");


		M��teri? M��teri2;
		M��teri2 = db.M��teriler.SingleOrDefault(w => w.Ad�Soyad� == xM��teri.Ad�Soyad�);
		Assert.False(M��teri2 is null, $"B�Z�M M��teri BULUNAMADI ! {xM��teri.Id} : {xM��teri.Ad�Soyad�} : {xM��teri.GSM} : {xM��teri.EPosta} ");
		Assert.True(M��teri2?.Ad�Soyad� == xM��teri.Ad�Soyad�, $"{M��teri2?.Ad�Soyad�} : {xM��teri.Ad�Soyad�} BULUNAMADI !");

		xM��teri.Id = M��teri2.Id;
		xM��teri.Ad�Soyad� += " : 100";
		xM��teri.GSM += 100;
		db.SaveChanges();

		M��teri2 = db.M��teriler.SingleOrDefault(w => w.Ad�Soyad� == xM��teri.Ad�Soyad�);
		Assert.True(xM��teri.Id == M��teri2.Id, $"M��teri Id DE���M�� !");
		Assert.True(xM��teri.Ad�Soyad� == M��teri2.Ad�Soyad�, $"B�Z�M M��teri BULUNAMADI ! {xM��teri.Id} : {xM��teri.Ad�Soyad�} : {xM��teri.GSM} : {xM��teri.EPosta} ");
		Assert.True(xM��teri.GSM == M��teri2.GSM, $"B�Z�M GSM DE��L ! {xM��teri.Ad�Soyad�} : {M��teri2.GSM} : {M��teri2.EPosta}");

		db.M��teriler.Remove(M��teri2); db.SaveChanges();
		var M��teri3 = db.M��teriler.SingleOrDefault(w => w.Ad�Soyad� == M��teri2.Ad�Soyad�);
		Assert.True(M��teri3 is null, $"Kay�t S�L�NMEM�� ! : {M��teri2.Ad�Soyad�}");

		M��teri3 = db.M��teriler.SingleOrDefault(w => w.Id == M��teri2.Id - 1);
		Assert.True(M��teri3 is not null, $"KAYIT OLMALIYDI ! {M��teri2.Id}");
		if (M��teri3 is not null) {
			db.M��teriler.Remove(M��teri3);
			r = db.SaveChanges();
			Assert.True(r == 1, $"ONULMAYAN ��LEM ADED� ! : {r}");
			}


		M��teri3 = db.M��teriler.SingleOrDefault(w => w.Ad�Soyad� == xM��teri.Ad�Soyad�);
		Assert.True(M��teri3 is null, $"Kay�t S�L�NMEM�� ! : {xM��teri.Ad�Soyad�}");


		}

	}