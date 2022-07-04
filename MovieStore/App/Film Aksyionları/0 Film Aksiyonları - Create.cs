
using AutoMapper;

using FluentValidation;

using MovieStore.Data;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Filmler;


public class FilmOluştur {

	// public FilmModel Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public FilmOluştur(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; }

	public int Handle(FilmModel pFilm) {
		new FilmValidator().RulesFor_Create().ValidateAndThrow(pFilm);

		var record = _DbContext.Filmler.SingleOrDefault(s => s.Adı == pFilm.Adı);
		if (record != null) { throw new InvalidOperationException($"Kayıt ZATEN VAR ! [ {pFilm.Id} : {pFilm.Adı} : {pFilm.TürId} : {pFilm.Fiyat} : {pFilm.Yılı} ] "); }

		_DbContext.Filmler.Add(pFilm);
		_DbContext.SaveChanges();
		return pFilm.Id;
		}

	}



