using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStore.App.Aksiyonlar.Yönetmenler;
using MovieStore.Data;
using MovieStore.Data.Model;
using MovieStore.DbActions;
using MovieStore.Services;


namespace MovieStore.Controllers;


[ApiController]
[Route("Yönetmenler")]
public class YönetmenController : ControllerBase {

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly ILoggerService _logger;

	public YönetmenController(MovieStoreDbContext  pContext, IMapper pMapper, ILoggerService pLogger) { _context = pContext; _mapper = pMapper; _logger = pLogger; }


	[HttpPut()][Route("listesi")]           public IActionResult Yönetmen_Listesi()                                => Ok(new YönetmenBilgileri(_context, _mapper).TümListe());
	[HttpPut()][Route("detay/{Id}")]        public IActionResult Yönetmen_Bilgisi(int Id)                          => Ok(new YönetmenBilgileri(_context, _mapper).Id_Ýle(Id));
	[HttpPut()][Route("detay/{adisoyadi}")] public IActionResult Yönetmen_Bilgisi(string adisoyadi)                => Ok(new YönetmenBilgileri(_context, _mapper).AdýSoyadý_Ýle(adisoyadi));
	//
	[HttpPut()][Route("oluþtur")]           public IActionResult Yönetmen_Oluþtur([FromBody] YönetmenModel pYönetmen)  => Ok(new YönetmenOluþtur(_context, _mapper).Handle(pYönetmen));
	//
	[HttpPut()][Route("güncelle")]          public IActionResult Yönetmen_Güncelle([FromBody] YönetmenModel pYönetmen) => Ok(new YönetmenGüncelle(_context, _mapper).Handle(pYönetmen));
	//
	[HttpPut()][Route("sil")]               public IActionResult Yönetmeni_Sil(int pId)                            => Ok(new YönetmenSÝL(_context, _mapper).Handle(pId));
	[HttpPut()][Route("sil2")]              public IActionResult Yönetmeni_Sil2([FromBody] int pId)                => Ok(new YönetmenSÝL(_context, _mapper).Handle(pId));


	}