using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MovieStore.Data;
using MovieStore.DbActions;

using MovieStore.UnitTests.TestSetup;


namespace MovieStore.xUnitTestS;


public class xuTestS_Film : IClassFixture<CommonTextFixture> {

	readonly MovieStoreDbContext db; readonly IMapper _mapper;
	public xuTestS_Film(CommonTextFixture textFixture) {
		db = textFixture.Context; _mapper = textFixture.Mapper;
		}


	[Fact]
	public void Film_Testleri_1() {

		// Kayıt Listesine Dair;
		Assert.True(db.Filmler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Filmler)}");
		Assert.True(db.Müşteriler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Müşteriler)}");
		Assert.True(db.Oyuncular.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Oyuncular)}");
		Assert.True(db.Yönetmenler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Yönetmenler)}");
		Assert.True(db.Kullanıcılar.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Kullanıcılar)}");
		Assert.True(db.Siparişler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.Siparişler)}");
		Assert.True(db.AlışVerişler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.AlışVerişler)}");
		Assert.True(db.FilmTürleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmTürleri)}");
		//// Assert.True(db.FilmOyuncuları    .Any(), $"KAYIT OLMALIYDI ! {nameof(db.FilmOyuncuları)}");
		Assert.True(db.MFavoriFilmTürleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.MFavoriFilmTürleri)}");
		Assert.True(db.OOynananFilmler.Any(), $"KAYIT OLMALIYDI ! {nameof(db.OOynananFilmler)}");
		Assert.True(db.YönetmeninFilmleri.Any(), $"KAYIT OLMALIYDI ! {nameof(db.YönetmeninFilmleri)}");



		// CRUD İşlemlerine Dair;
		int r = 0;
		var dt = DateTime.Now;
		Film? xFilm;

		xFilm = new Film { Fiyat = dt.Millisecond, TürId = dt.Millisecond % 11, YönetmenId = 11, Yılı = $"{dt.Year - 50 - 101}", Adı = $"test film 1 : {dt.Millisecond}", };
		db.Filmler.Add(xFilm);

		xFilm = new Film { Fiyat = dt.Millisecond, TürId = dt.Millisecond % 11, YönetmenId = 11, Yılı = $"{dt.Year - 50 - xFilm.TürId}", Adı = $"test film 2 : {xFilm.Fiyat}", };
		db.Filmler.Add(xFilm);
		r = db.SaveChanges();
		Assert.True(r == 02, $"{r} :: 2 Kayıt EKLENMELİYDİ !");


		Film? Film2;
		Film2 = db.Filmler.SingleOrDefault(w => w.Adı == xFilm.Adı);
		Assert.False(Film2 is null, $"{xFilm.Adı} BULUNAMADI !");
		Assert.True(Film2?.Adı == xFilm.Adı, $"{Film2?.Adı} : {xFilm.Adı} BULUNAMADI !");

		xFilm.Id = Film2.Id;
		xFilm.Adı += " : 100";
		xFilm.Fiyat += 100;
		db.SaveChanges();

		Film2 = db.Filmler.SingleOrDefault(w => w.Adı == xFilm.Adı);
		Assert.True(xFilm.Id == Film2.Id, $"Film Id DEĞİŞMİŞ !");
		Assert.True(xFilm.Adı == Film2.Adı, $"BİZİM Müşteri BULUNAMADI ! {xFilm.Id} : {xFilm.Adı} : {xFilm.TürId} : {xFilm.Fiyat} ");
		Assert.True(xFilm.Fiyat == Film2.Fiyat, $"BİZİM Fiyat DEĞİL ! {xFilm.Fiyat} : {Film2.Fiyat} ");

		db.Filmler.Remove(Film2); db.SaveChanges();
		var Film3 = db.Filmler.SingleOrDefault(w => w.Adı == Film2.Adı);
		Assert.True(Film3 is null, $"Kayıt SİLİNMEMİŞ ! : {Film2.Adı}");

		Film3 = db.Filmler.SingleOrDefault(w => w.Id == Film2.Id - 1);
		Assert.True(Film3 is not null, $"KAYIT OLMALIYDI ! {Film2.Id}");
		if (Film3 is not null) {
			db.Filmler.Remove(Film3);
			r = db.SaveChanges();
			Assert.True(r == 1, $"ONULMAYAN İŞLEM ADEDİ ! : {r}");
			}


		Film3 = db.Filmler.SingleOrDefault(w => w.Adı == xFilm.Adı);
		Assert.True(Film3 is null, $"Kayıt SİLİNMEMİŞ ! : {xFilm.Adı}");


		}

	}