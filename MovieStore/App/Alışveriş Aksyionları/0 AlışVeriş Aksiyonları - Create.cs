
using AutoMapper;

using FluentValidation;

using MovieStore.Data;
using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.AlışVerişler;

public class AlışVerişOluştur {

	public SiparişModel Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public AlışVerişOluştur ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; Model = new SiparişModel(); }

	public int Handle ( Sipariş pAlışVeriş ) {
		new AlışVerişValidator().RulesFor_Create().ValidateAndThrow( pAlışVeriş );

		// var record = _DbContext.AlışVerişler.SingleOrDefault( s => s.Id == pAlışVeriş.Id );
		// if ( record != null ) { throw new InvalidOperationException( $"Kayıt ZATEN VAR ! [ {pAlışVeriş.Id} / M:{pAlışVeriş.MüşteriId}] / F:{pAlışVeriş.FilmId} " ); }

		_DbContext.AlışVerişler.Add( pAlışVeriş );
		_DbContext.SaveChanges();
		return pAlışVeriş.Id;
		}

	}



