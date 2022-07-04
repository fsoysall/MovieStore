
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.Müşteriler;
using MovieStore.Data;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Müşteriler;


public class MüşteriSİL {

	//public MüşteriModel Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public MüşteriSİL ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; }

	public void Handle ( Müşteri pMüşteri ) { this.Handle( pMüşteri.Id ); }

	public bool Handle ( int pId ) {
		var record = _DbContext.Müşteriler.SingleOrDefault( s => s.Id == pId );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Id: {pId}]" ); }

		new MüşteriValidator().RulesFor_Delete().ValidateAndThrow( record );

		_DbContext.Müşteriler.Remove( record );
		_DbContext.SaveChanges();
		return true;
		}

	}


