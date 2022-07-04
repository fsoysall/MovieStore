
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.Yönetmenler;
using MovieStore.Data;
using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Yönetmenler;

public class YönetmenSİL {

	// public YönetmenModel Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public YönetmenSİL(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; }
	// public DeleteYönetmenCommands ( MovieStoreDbContext  pContext, IMapper pMapper, YönetmenModel pModel ) { _DbContext = pContext; _Mapper = pMapper; Model = pModel; }

	public void Handle(Yönetmen Yönetmen) { this.Handle(Yönetmen.Id); }

	public bool Handle(int pId) {
		var record = _DbContext.Yönetmenler.SingleOrDefault(s => s.Id == pId);
		if (record == null) { throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Id: {pId}]"); }

		new YönetmenValidator().RulesFor_Delete().ValidateAndThrow(record);

		_DbContext.Yönetmenler.Remove(record);
		_DbContext.SaveChanges();
		return true;
		}

	}


