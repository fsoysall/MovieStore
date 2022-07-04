using System;

using AutoMapper;

using MovieStore.Data;
using MovieStore.DbActions;
using MovieStore.UnitTests.TestSetup;


namespace MovieStore.xUnitTestS;


public class xuTestS_Al��Veri� : IClassFixture<CommonTextFixture> {

	readonly IMovieStoreDbContext db; readonly IMapper _mapper;
	public xuTestS_Al��Veri�(CommonTextFixture textFixture) { db = textFixture.Context; _mapper = textFixture.Mapper; }


	[Fact]
	public void Al��Veri�_Testleri_1() {

		// Kay�t Listesine Dair;
		Assert.True(db.Filmler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Filmler)}");
		Assert.True(db.M��teriler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.M��teriler)}");
		Assert.True(db.Oyuncular.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Oyuncular)}");
		Assert.True(db.Y�netmenler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Y�netmenler)}");
		Assert.True(db.Kullan�c�lar.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Kullan�c�lar)}");
		Assert.True(db.Sipari�ler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Sipari�ler)}");
		Assert.True(db.Al��Veri�ler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Al��Veri�ler)}");
		Assert.True(db.FilmT�rleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmT�rleri)}");
		//Assert.True(db.FilmOyuncular�.Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmOyuncular�)}");
		Assert.True(db.MFavoriFilmT�rleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.MFavoriFilmT�rleri)}");
		Assert.True(db.OOynananFilmler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.OOynananFilmler)}");
		Assert.True(db.Y�netmeninFilmleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Y�netmeninFilmleri)}");



		// CRUD ��lemlerine Dair;
		int r = 0;
		var dt = DateTime.Now;
		Sipari�? xSipari�;



		xSipari� = new Sipari� { M��teriId = (int)(dt.Ticks % 55), FilmId = (int)(dt.Ticks % 100), Fiyat = dt.Ticks % 1234, Tarih = dt };
		db.Sipari�ler.Add(xSipari�);

		xSipari� = new Sipari� { M��teriId = (int)(dt.Ticks % 55), FilmId = (int)(dt.Ticks % 100), Fiyat = dt.Ticks % 1234, Tarih = dt };
		db.Sipari�ler.Add(xSipari�);
		r = db.SaveChanges();
		Assert.True(r == 02, $"{r} :: 2 Kay�t EKLENMEL�YD� !");


		Sipari�? Sipari�2;
		Sipari�2 = db.Sipari�ler.SingleOrDefault(w => w.Id == xSipari�.Id);
		Assert.False(Sipari�2 is null, $"B�Z�M Sipari� BULUNAMADI ! {xSipari�.Id} : {xSipari�.M��teriId} : {xSipari�.FilmId} : {xSipari�.Fiyat} : {xSipari�.Tarih} ");
		Assert.True(Sipari�2?.Id == xSipari�.Id, $"{Sipari�2?.Id} : {xSipari�.M��teriId} BULUNAMADI !");

		xSipari�.Id = Sipari�2.Id;
		xSipari�.M��teriId += 3;
		xSipari�.Fiyat+= 100;
		db.SaveChanges();
	
		Sipari�2 = db.Sipari�ler.SingleOrDefault(w => w.M��teriId == xSipari�.M��teriId);
		Assert.True(xSipari�.Id == Sipari�2.Id,               $"Sipari� Id DE���M��        !");
		Assert.True(xSipari�.M��teriId == Sipari�2.M��teriId, $"B�Z�M M��teriId BULUNAMADI ! {xSipari�.Id} : {xSipari�.M��teriId} : {xSipari�.FilmId} : {xSipari�.Fiyat} : {xSipari�.Tarih} ");
		Assert.True(xSipari�.FilmId == Sipari�2.FilmId,       $"B�Z�M FilmId BULUNAMADI    ! {xSipari�.Id} : {xSipari�.M��teriId} : {xSipari�.FilmId} : {xSipari�.Fiyat} : {xSipari�.Tarih} ");

		db.Sipari�ler.Remove(Sipari�2); db.SaveChanges();
		var Sipari�3 = db.Sipari�ler.SingleOrDefault(w => w.Id == Sipari�2.Id);
		Assert.True(Sipari�3 is null, $"Kay�t S�L�NMEM�� ! : {Sipari�2.Id}");

		Sipari�3 = db.Sipari�ler.SingleOrDefault(w => w.Id == xSipari�.Id - 1);
		Assert.True(Sipari�3 is not null, $"KAYIT OLMALIYDI ! {xSipari�.Id}");
		if (Sipari�3 is not null) {
			db.Sipari�ler.Remove(Sipari�3);
			r = db.SaveChanges();
			Assert.True(r == 1, $"ONULMAYAN ��LEM ADED� ! : {r}");
			}


		Sipari�3 = db.Sipari�ler.SingleOrDefault(w => w.Id == xSipari�.Id);
		Assert.True(Sipari�3 is null, $"Kay�t S�L�NMEM�� ! : {xSipari�.Id}");


		}

	}