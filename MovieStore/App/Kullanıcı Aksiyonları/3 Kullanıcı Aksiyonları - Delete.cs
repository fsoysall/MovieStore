
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.Kullanıcılar;
using MovieStore.Data;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.Kullanıcılar;


public class KullanıcıSİL {

	// public UserModel Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public KullanıcıSİL(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; }
	// public DeleteUserCommands ( MovieStoreDbContext  pContext, IMapper pMapper, UserModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public void Handle(Kullanıcı User) { this.Handle(User.Id); }

	public bool Handle(int pId) {
		var record = _DbContext.Kullanıcılar.SingleOrDefault(s => s.Id == pId);
		if (record == null) { throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Id: {pId}]"); }

		new KullanıcıValidator().RulesFor_Delete().ValidateAndThrow(record);

		_DbContext.Kullanıcılar.Remove(record);
		_DbContext.SaveChanges();
		return true;
		}

	}