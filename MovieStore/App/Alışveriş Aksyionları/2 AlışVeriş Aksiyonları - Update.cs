
using AutoMapper;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

using MovieStore.App.Aksiyonlar.AlışVerişler;
using MovieStore.Data;
using MovieStore.DbActions;


namespace MovieStore.App.Aksiyonlar.AlışVerişler;


public class AlışVerişGüncelle {


	//public SiparişModel? Model { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;

	public AlışVerişGüncelle(MovieStoreDbContext  pContext, IMapper pMapper) { _DbContext = pContext; _Mapper = pMapper; }
	public AlışVerişGüncelle(MovieStoreDbContext  pContext, IMapper pMapper, SiparişModel pModel) { _DbContext = pContext; _Mapper = pMapper; }

	public bool Handle(Sipariş pAlışVeriş) {
		new AlışVerişValidator().RulesFor_Update().ValidateAndThrow(pAlışVeriş);

		var record = _DbContext.AlışVerişler.AsNoTracking().SingleOrDefault(s => s.Id == pAlışVeriş.Id);
		if (record == null) { throw new InvalidOperationException($"Kayıt BULUNAMADI ! [Id: {pAlışVeriş.Id}]"); }

		_DbContext.AlışVerişler.Update(pAlışVeriş);
		_DbContext.SaveChanges();
		return true;
		}

	}





