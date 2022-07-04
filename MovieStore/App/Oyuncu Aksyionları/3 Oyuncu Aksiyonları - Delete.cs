
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.Oyuncular;
using MovieStore.Data;
using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Oyuncular;


public class OyuncuSİL {

	//public OyuncuModel Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public OyuncuSİL ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; }

	public void Handle ( Oyuncu pOyuncu ) { this.Handle( pOyuncu.Id ); }

	public bool Handle ( int pId ) {
		var record = _DbContext.Oyuncular.SingleOrDefault( s => s.Id == pId );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Id: {pId}]" ); }

		new OyuncuValidator().RulesFor_Delete().ValidateAndThrow( record );

		_DbContext.Oyuncular.Remove( record );
		_DbContext.SaveChanges();
		return true;
		}

	}


