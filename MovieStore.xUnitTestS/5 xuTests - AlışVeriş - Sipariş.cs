using System;

using AutoMapper;

using MovieStore.Data;
using MovieStore.DbActions;
using MovieStore.UnitTests.TestSetup;


namespace MovieStore.xUnitTestS;


public class xuTestS_AlýþVeriþ : IClassFixture<CommonTextFixture> {

	readonly IMovieStoreDbContext db; readonly IMapper _mapper;
	public xuTestS_AlýþVeriþ(CommonTextFixture textFixture) { db = textFixture.Context; _mapper = textFixture.Mapper; }


	[Fact]
	public void AlýþVeriþ_Testleri_1() {

		// Kayýt Listesine Dair;
		Assert.True(db.Filmler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Filmler)}");
		Assert.True(db.Müþteriler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Müþteriler)}");
		Assert.True(db.Oyuncular.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Oyuncular)}");
		Assert.True(db.Yönetmenler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Yönetmenler)}");
		Assert.True(db.Kullanýcýlar.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Kullanýcýlar)}");
		Assert.True(db.Sipariþler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Sipariþler)}");
		Assert.True(db.AlýþVeriþler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.AlýþVeriþler)}");
		Assert.True(db.FilmTürleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmTürleri)}");
		//Assert.True(db.FilmOyuncularý.Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmOyuncularý)}");
		Assert.True(db.MFavoriFilmTürleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.MFavoriFilmTürleri)}");
		Assert.True(db.OOynananFilmler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.OOynananFilmler)}");
		Assert.True(db.YönetmeninFilmleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.YönetmeninFilmleri)}");



		// CRUD Ýþlemlerine Dair;
		int r = 0;
		var dt = DateTime.Now;
		Sipariþ? xSipariþ;



		xSipariþ = new Sipariþ { MüþteriId = (int)(dt.Ticks % 55), FilmId = (int)(dt.Ticks % 100), Fiyat = dt.Ticks % 1234, Tarih = dt };
		db.Sipariþler.Add(xSipariþ);

		xSipariþ = new Sipariþ { MüþteriId = (int)(dt.Ticks % 55), FilmId = (int)(dt.Ticks % 100), Fiyat = dt.Ticks % 1234, Tarih = dt };
		db.Sipariþler.Add(xSipariþ);
		r = db.SaveChanges();
		Assert.True(r == 02, $"{r} :: 2 Kayýt EKLENMELÝYDÝ !");


		Sipariþ? Sipariþ2;
		Sipariþ2 = db.Sipariþler.SingleOrDefault(w => w.Id == xSipariþ.Id);
		Assert.False(Sipariþ2 is null, $"BÝZÝM Sipariþ BULUNAMADI ! {xSipariþ.Id} : {xSipariþ.MüþteriId} : {xSipariþ.FilmId} : {xSipariþ.Fiyat} : {xSipariþ.Tarih} ");
		Assert.True(Sipariþ2?.Id == xSipariþ.Id, $"{Sipariþ2?.Id} : {xSipariþ.MüþteriId} BULUNAMADI !");

		xSipariþ.Id = Sipariþ2.Id;
		xSipariþ.MüþteriId += 3;
		xSipariþ.Fiyat+= 100;
		db.SaveChanges();
	
		Sipariþ2 = db.Sipariþler.SingleOrDefault(w => w.MüþteriId == xSipariþ.MüþteriId);
		Assert.True(xSipariþ.Id == Sipariþ2.Id,               $"Sipariþ Id DEÐÝÞMÝÞ        !");
		Assert.True(xSipariþ.MüþteriId == Sipariþ2.MüþteriId, $"BÝZÝM MüþteriId BULUNAMADI ! {xSipariþ.Id} : {xSipariþ.MüþteriId} : {xSipariþ.FilmId} : {xSipariþ.Fiyat} : {xSipariþ.Tarih} ");
		Assert.True(xSipariþ.FilmId == Sipariþ2.FilmId,       $"BÝZÝM FilmId BULUNAMADI    ! {xSipariþ.Id} : {xSipariþ.MüþteriId} : {xSipariþ.FilmId} : {xSipariþ.Fiyat} : {xSipariþ.Tarih} ");

		db.Sipariþler.Remove(Sipariþ2); db.SaveChanges();
		var Sipariþ3 = db.Sipariþler.SingleOrDefault(w => w.Id == Sipariþ2.Id);
		Assert.True(Sipariþ3 is null, $"Kayýt SÝLÝNMEMÝÞ ! : {Sipariþ2.Id}");

		Sipariþ3 = db.Sipariþler.SingleOrDefault(w => w.Id == xSipariþ.Id - 1);
		Assert.True(Sipariþ3 is not null, $"KAYIT OLMALIYDI ! {xSipariþ.Id}");
		if (Sipariþ3 is not null) {
			db.Sipariþler.Remove(Sipariþ3);
			r = db.SaveChanges();
			Assert.True(r == 1, $"ONULMAYAN ÝÞLEM ADEDÝ ! : {r}");
			}


		Sipariþ3 = db.Sipariþler.SingleOrDefault(w => w.Id == xSipariþ.Id);
		Assert.True(Sipariþ3 is null, $"Kayýt SÝLÝNMEMÝÞ ! : {xSipariþ.Id}");


		}

	}