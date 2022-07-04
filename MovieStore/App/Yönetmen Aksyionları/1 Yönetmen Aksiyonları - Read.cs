
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.Oyuncular;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Yönetmenler;


public class YönetmenBilgileri {

	// public YönetmenModel Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public YönetmenBilgileri(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; }

	public YönetmenModel Id_İle(int pId) {
		var record = _DbContext.Yönetmenler.SingleOrDefault(s => s.Id == pId);
		if (record == null) { throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Id: {pId}]"); }

		new YönetmenValidator().RulesFor_Read().ValidateAndThrow(record);
		return _Mapper.Map<YönetmenModel>(record);
		}

	public YönetmenModel AdıSoyadı_İle(string pAdıSoyadı /* , string pSurname */ ) {
		var record = _DbContext.Yönetmenler.SingleOrDefault(s => s.AdıSoyadı == pAdıSoyadı  /* && s.Surname == record.Surname */  );
		if (record == null) { throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Name: {pAdıSoyadı}]"); }

		new YönetmenValidator().RulesFor_Read().ValidateAndThrow(record);
		return _Mapper.Map<YönetmenModel>(record);
		}

	public List<YönetmenModel> TümKayıtlar() => TümListe();
	public List<YönetmenModel> TümListe() {
		var record = _DbContext.Yönetmenler.ToList();
		return record != null ? _Mapper.Map<List<YönetmenModel>>(record) : throw new InvalidOperationException($"Kayıt BULUNAMADI !");

		}

	}






