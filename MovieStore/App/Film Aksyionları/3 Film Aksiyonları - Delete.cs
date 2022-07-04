
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.Filmler;
using MovieStore.Data;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Filmler;


public class FilmSİL {

	//public FilmModel Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public FilmSİL ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; }

	public void Handle ( FilmModel pFilm ) { this.Handle( pFilm.Id ); }

	public bool Handle ( int pId ) {
		var record = _DbContext.Filmler.SingleOrDefault( s => s.Id == pId );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Id: {pId}]" ); }

		new FilmValidator().RulesFor_Delete().ValidateAndThrow( record );

		_DbContext.Filmler.Remove( record );
		_DbContext.SaveChanges();
		return true;
		}

	}






