
using AutoMapper;

using FluentValidation;

using MovieStore.App.Aksiyonlar.AlışVerişler;
using MovieStore.Data;
using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Yönetmenler;


public class AlışVerişSİL {

	//public SiparişModel Model { get; set; }
	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public AlışVerişSİL(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; }

	public void Handle(Sipariş pAlışVeriş) { this.Handle(pAlışVeriş.Id); }

	public bool Handle(int pId) {
		var record = _DbContext.AlışVerişler.SingleOrDefault(s => s.Id == pId);
		if (record == null) { throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Id: {pId}]"); }

		new AlışVerişValidator().RulesFor_Delete().ValidateAndThrow(record);

		_DbContext.AlışVerişler.Remove(record);
		_DbContext.SaveChanges();
		return true;
		}

	}






