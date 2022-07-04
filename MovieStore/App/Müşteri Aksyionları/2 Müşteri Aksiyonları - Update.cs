
using AutoMapper;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

using MovieStore.App.Aksiyonlar.Müşteriler;
using MovieStore.Data;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Müşteriler;


public class MüşteriGüncelle {


	public MüşteriModel? Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public MüşteriGüncelle ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; }
	public MüşteriGüncelle ( MovieStoreDbContext  pContext, IMapper pMapper, MüşteriModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public bool Handle ( Müşteri Müşteri ) {
		new MüşteriValidator().RulesFor_Update().ValidateAndThrow( Müşteri );

		var record = _DbContext.Müşteriler.AsNoTracking().SingleOrDefault( s => s.Id == Müşteri.Id );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Id: {Müşteri.Id}]" ); }

		_DbContext.Müşteriler.Update( Müşteri );
		_DbContext.SaveChanges();
		return true;
		}

	}





