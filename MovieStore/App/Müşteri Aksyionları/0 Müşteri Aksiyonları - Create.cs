
using AutoMapper;

using FluentValidation;

using MovieStore.Data;
using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Müşteriler;

public class MüşteriOluştur {

	public MüşteriModel Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public MüşteriOluştur(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; Model = new MüşteriModel(); }

	public int Handle(Müşteri pMüşteri) {

		new MüşteriValidator().RulesFor_Create().ValidateAndThrow(pMüşteri);

		var record = _DbContext.Müşteriler.SingleOrDefault(s => s.AdıSoyadı == pMüşteri.AdıSoyadı);
		if (record != null) { throw new InvalidOperationException($"Kayıt ZATEN VAR ! [ {pMüşteri.Id} : {pMüşteri.EPosta} : {pMüşteri.AdıSoyadı}] "); }

		_DbContext.Müşteriler.Add(pMüşteri);
		_DbContext.SaveChanges();
		return pMüşteri.Id;
		}

	}



