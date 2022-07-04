
using AutoMapper;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

using MovieStore.App.Aksiyonlar.Filmler;
using MovieStore.Data;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Filmler;


public class FilmGüncelle {

	//public FilmModel? Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public FilmGüncelle ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; }
	public FilmGüncelle ( MovieStoreDbContext  pContext, IMapper pMapper, FilmModel pModel ) { _DbContext = pContext; _Mapper = pMapper; }

	public bool Handle (FilmModel Film ) {
		new FilmValidator().RulesFor_Update().ValidateAndThrow( Film );

		var record = _DbContext.Filmler.AsNoTracking().SingleOrDefault( s => s.Id == Film.Id );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Id: {Film.Id}]" ); }

		_DbContext.Filmler.Update( Film );
		_DbContext.SaveChanges();
		return true;
		}

	}





