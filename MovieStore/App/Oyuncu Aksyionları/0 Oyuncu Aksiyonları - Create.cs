
using AutoMapper;

using FluentValidation;

using MovieStore.Data;
using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Oyuncular;

public class OyuncuOluştur {

	public OyuncuModel Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public OyuncuOluştur(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; Model = new OyuncuModel(); }

	public int Handle(Oyuncu pOyuncu) {
		new OyuncuValidator().RulesFor_Create().ValidateAndThrow(pOyuncu);

		var record = _DbContext.Oyuncular.SingleOrDefault(s => s.AdıSoyadı == pOyuncu.AdıSoyadı);
		if (record != null) { throw new InvalidOperationException($"Kayıt ZATEN VAR ! [ {pOyuncu.Id} : {pOyuncu.AdıSoyadı}] "); }

		_DbContext.Oyuncular.Add(pOyuncu);
		_DbContext.SaveChanges();
		return pOyuncu.Id;
		}

	}



