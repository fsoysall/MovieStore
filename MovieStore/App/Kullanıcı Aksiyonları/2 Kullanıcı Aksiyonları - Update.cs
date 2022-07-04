
using AutoMapper;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

using MovieStore.App.Aksiyonlar.Kullanıcılar;
using MovieStore.Data;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Kullanıcılar;


public class KullanıcıGüncelle {

	public KullanıcıModel? Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public KullanıcıGüncelle ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; }
	public KullanıcıGüncelle ( MovieStoreDbContext  pContext, IMapper pMapper, KullanıcıModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public bool Handle ( Kullanıcı User ) {
		new KullanıcıValidator().RulesFor_Update().ValidateAndThrow( User );

		var record = _DbContext.Kullanıcılar.AsNoTracking().SingleOrDefault( s => s.Id == User.Id );
		if ( record == null ) { throw new InvalidOperationException( $"Kayıt BULUNAMADI ! [Id: {User.Id}]" ); }

		_DbContext.Kullanıcılar.Update( User );
		_DbContext.SaveChanges();
		return true;
		}

	}


