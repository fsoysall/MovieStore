
using AutoMapper;

using FluentValidation;

using MovieStore.Data;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Kullanıcılar;


public class KullanıcıOluştur {

		public KullanıcıModel Model { get; set; }

		private readonly MovieStoreDbContext  _DbContext;
		private readonly IMapper _Mapper;

		public KullanıcıOluştur ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; Model = new KullanıcıModel(); }

		public int Handle ( Kullanıcı User ) {
			new KullanıcıValidator().RulesFor_Create().ValidateAndThrow( User );

			var record = _DbContext.Kullanıcılar.SingleOrDefault( s => s.EMail == User.EMail );
			if ( record != null ) { throw new InvalidOperationException( $"Kayıt ZATEN VAR ! [ {User.EMail} : {User.FullName}] " ); }

			_DbContext.Kullanıcılar.Add( User );
			_DbContext.SaveChanges();
			return User.Id;
			}

		}



	