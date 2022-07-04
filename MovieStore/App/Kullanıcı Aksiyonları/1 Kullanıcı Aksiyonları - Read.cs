
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.Kullanıcılar;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Kullanıcılar;


public class KullanıcıBilgileri {

	// public UserModel Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public KullanıcıBilgileri(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; }
	// public ReadUserCommands ( MovieStoreDbContext  pContext, IMapper pMapper, UserModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public KullanıcıModel Id_İle(int pId) {
		var record = _DbContext.Kullanıcılar.SingleOrDefault(s => s.Id == pId);
		if (record == null) { throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Id: {pId}]"); }

		new KullanıcıValidator().RulesFor_Read().ValidateAndThrow(record);
		return _Mapper.Map<KullanıcıModel>(record);
		}

	public KullanıcıModel KullAdı_ile(string pName /* , string pSurname */ ) {
		var record = _DbContext.Kullanıcılar.SingleOrDefault(s => s.FullName == pName  /* && s.Surname == record.Surname */  );
		if (record == null) { throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Name: {pName}]"); }

		new KullanıcıValidator().RulesFor_Read().ValidateAndThrow(record);
		return _Mapper.Map<KullanıcıModel>(record);
		}

	public List<KullanıcıModel> TümKayıtlar() => TümListe();
	public List<KullanıcıModel> TümListe() {
		var record = _DbContext.Kullanıcılar.ToList();
		return record != null ? _Mapper.Map<List<KullanıcıModel>>(record) : throw new InvalidOperationException($"Kayıt BULUNAMADI !");

		}

	}


