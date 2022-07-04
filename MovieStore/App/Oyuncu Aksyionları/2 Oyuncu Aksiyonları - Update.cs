
using AutoMapper;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

using MovieStore.App.Aksiyonlar.Oyuncular;
using MovieStore.Data;
using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Oyuncular;

public class OyuncuGüncelle {


	public OyuncuModel? Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public OyuncuGüncelle ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; }
	public OyuncuGüncelle ( MovieStoreDbContext  pContext, IMapper pMapper, OyuncuModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public bool Handle ( Oyuncu Oyuncu ) {
		new OyuncuValidator().RulesFor_Update().ValidateAndThrow( Oyuncu );

		var record = _DbContext.Oyuncular.AsNoTracking().SingleOrDefault( s => s.Id == Oyuncu.Id );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Id: {Oyuncu.Id}]" ); }

		_DbContext.Oyuncular.Update( Oyuncu );
		_DbContext.SaveChanges();
		return true;
		}

	}





