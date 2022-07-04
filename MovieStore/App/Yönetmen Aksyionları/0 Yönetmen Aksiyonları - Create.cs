
using AutoMapper;

using FluentValidation;

using MovieStore.Data;
using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Yönetmenler;

public class YönetmenOluştur {

		public YönetmenModel Model { get; set; }

		private readonly MovieStoreDbContext  _DbContext;
		private readonly IMapper _Mapper;

		public YönetmenOluştur ( MovieStoreDbContext  pContext, IMapper pMapper ) { _DbContext = pContext; _Mapper = pMapper; Model = new YönetmenModel(); }

		public int Handle ( Yönetmen pYönetmen ) {
			new YönetmenValidator().RulesFor_Create().ValidateAndThrow( pYönetmen );

			var record = _DbContext.Yönetmenler.SingleOrDefault( s => s.AdıSoyadı == pYönetmen.AdıSoyadı);
			if ( record != null ) { throw new InvalidOperationException( $"Kayıt ZATEN VAR ! [ {pYönetmen.Id} : {pYönetmen.AdıSoyadı} ] " ); }

			_DbContext.Yönetmenler.Add( pYönetmen );
			_DbContext.SaveChanges();
			return pYönetmen.Id;
			}

		}


