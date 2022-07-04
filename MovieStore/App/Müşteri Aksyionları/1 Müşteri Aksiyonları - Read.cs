
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.Müşteriler;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Müşteriler;


public class MüşteriBilgileri {

	//public MüşteriModel Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public MüşteriBilgileri ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; }
	// public ReadUserCommands ( MovieStoreDbContext  pContext, IMapper pMapper, UserModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public MüşteriModel Id_İle( int pId ) {
		var record = _DbContext.Müşteriler.SingleOrDefault( s => s.Id == pId );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Id: {pId}]" ); }

		new MüşteriValidator().RulesFor_Read().ValidateAndThrow( record );
		return _Mapper.Map<MüşteriModel>( record );
		}

	public MüşteriModel AdıSoyadı_İle ( string pAdıSoyadı /* , string pSurname */ ) {
		var record = _DbContext.Müşteriler.SingleOrDefault( s => s.AdıSoyadı == pAdıSoyadı  /* && s.Surname == record.Surname */  );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Name: {pAdıSoyadı}]" ); }

		new MüşteriValidator().RulesFor_Read().ValidateAndThrow( record );
		return _Mapper.Map<MüşteriModel>( record );
		}

	public List<MüşteriModel> TümListe () {
		var record = _DbContext.Müşteriler.ToList();
		return record != null ? _Mapper.Map<List<MüşteriModel>>( record ) : throw new InvalidOperationException( $"Kayıt BULUNAMADI !" );

		}

	}






