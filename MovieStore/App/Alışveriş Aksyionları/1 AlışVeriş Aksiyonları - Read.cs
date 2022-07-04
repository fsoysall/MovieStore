
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.AlışVerişler;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.AlışVerişler;


public class AlışVerişListesi {

	//public SiparişModel Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public AlışVerişListesi ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; }
	// public ReadUserCommands ( MovieStoreDbContext  pContext, IMapper pMapper, UserModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public SiparişModel MüşteriId_İle ( int pId ) {
		var record = _DbContext.AlışVerişler.SingleOrDefault( s => s.Id == pId );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Id: {pId}]" ); }

		new AlışVerişValidator().RulesFor_Read().ValidateAndThrow( record );
		return _Mapper.Map<SiparişModel>( record );
		}

	public SiparişModel FilmId_İle ( int pMüşteriId /* , string pSurname */ ) {
		var record = _DbContext.AlışVerişler.SingleOrDefault( s => s.MüşteriId == pMüşteriId );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Name: {pMüşteriId}]" ); }

		new AlışVerişValidator().RulesFor_Read().ValidateAndThrow( record );
		return _Mapper.Map<SiparişModel>( record );
		}

	public List<SiparişModel> HandleAllRecords () {
		var record = _DbContext.AlışVerişler.ToList();
		return record != null ? _Mapper.Map<List<SiparişModel>>( record ) : throw new InvalidOperationException( $"Kayıt BULUNAMADI !" );

		}

	}






