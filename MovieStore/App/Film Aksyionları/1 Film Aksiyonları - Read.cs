
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.Filmler;
using MovieStore.App.Aksiyonlar.Oyuncular;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Filmler;


public class FilmBilgileri {

	//public FilmModel Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public FilmBilgileri(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; }
	// public ReadUserCommands ( MovieStoreDbContext  pContext, IMapper pMapper, UserModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public FilmModel Id_İle(int pId) {
		var record = _DbContext.Filmler.SingleOrDefault(s => s.Id == pId);
		return record == null
			? throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Id: {pId}]")
			: _Mapper.Map<FilmModel>(record);
		}

	public FilmModel AdıSoyadı_İle(string pFilmAdı /* , string pSurname */ ) {
		var record = _DbContext.Filmler.SingleOrDefault(s => s.Adı == pFilmAdı /* && s.Surname == record.Surname */  );
		return record == null
			? throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Name: {pFilmAdı}]")
			: _Mapper.Map<FilmModel>(record);
		}

	public List<FilmModel> TümKayıtlar() => TümListe();
	public List<FilmModel> TümListe() {
		var record = _DbContext.Filmler.ToList().OrderByDescending(o => o.Id).ToList();
		return record is null
			? throw new InvalidOperationException($"Kayıt BULUNAMADI !")
			: _Mapper.Map<List<FilmModel>>(record);

		}

	}






