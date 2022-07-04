
using AutoMapper;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

using MovieStore.App.Aksiyonlar.Yönetmenler;
using MovieStore.Data;
using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Yönetmenler;


public class YönetmenGüncelle {


	public YönetmenModel? Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public YönetmenGüncelle ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; }
	public YönetmenGüncelle ( MovieStoreDbContext  pContext, IMapper pMapper, YönetmenModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public bool Handle ( Yönetmen Yönetmen ) {
		new YönetmenValidator().RulesFor_Update().ValidateAndThrow( Yönetmen );

		var record = _DbContext.Yönetmenler.AsNoTracking().SingleOrDefault( s => s.Id == Yönetmen.Id );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Id: {Yönetmen.Id}]" ); }

		_DbContext.Yönetmenler.Update( Yönetmen );
		_DbContext.SaveChanges();
		return true;
		}

	}





