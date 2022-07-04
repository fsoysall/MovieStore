
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.Kullanıcılar;
using MovieStore.App.Aksiyonlar.Oyuncular;
using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Oyuncular;


public class OyuncuBilgileri {

	//public OyuncuModel Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public OyuncuBilgileri(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; }
	// public ReadUserCommands ( MovieStoreDbContext  pContext, IMapper pMapper, UserModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public OyuncuModel Id_İle(int pId) {
		var record = _DbContext.Oyuncular.SingleOrDefault(s => s.Id == pId);
		if (record == null) { throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Id: {pId}]"); }

		new OyuncuValidator().RulesFor_Read().ValidateAndThrow(record);
		return _Mapper.Map<OyuncuModel>(record);
		}

	public OyuncuModel AdıSoyadı_İle(string pAdıSoyadı /* , string pSurname */ ) {
		var record = _DbContext.Oyuncular.SingleOrDefault(s => s.AdıSoyadı == pAdıSoyadı  /* && s.Surname == record.Surname */  );
		if (record == null) { throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Name: {pAdıSoyadı}]"); }

		new OyuncuValidator().RulesFor_Read().ValidateAndThrow(record);
		return _Mapper.Map<OyuncuModel>(record);
		}

	public List<OyuncuModel> TümKayıtlar() => TümListe(); 
	public List<OyuncuModel> TümListe() {
		var record = _DbContext.Oyuncular.ToList();
		return record != null ? _Mapper.Map<List<OyuncuModel>>(record) : throw new InvalidOperationException($"Kayıt BULUNAMADI !");

		}

	}






