using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStore.App.Aksiyonlar.Y�netmenler;
using MovieStore.Data;
using MovieStore.Data.Model;
using MovieStore.DbActions;
using MovieStore.Services;


namespace MovieStore.Controllers;


[ApiController]
[Route("Y�netmenler")]
public class Y�netmenController : ControllerBase {

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly ILoggerService _logger;

	public Y�netmenController(MovieStoreDbContext  pContext, IMapper pMapper, ILoggerService pLogger) { _context = pContext; _mapper = pMapper; _logger = pLogger; }


	[HttpPut()][Route("listesi")]           public IActionResult Y�netmen_Listesi()                                => Ok(new Y�netmenBilgileri(_context, _mapper).T�mListe());
	[HttpPut()][Route("detay/{Id}")]        public IActionResult Y�netmen_Bilgisi(int Id)                          => Ok(new Y�netmenBilgileri(_context, _mapper).Id_�le(Id));
	[HttpPut()][Route("detay/{adisoyadi}")] public IActionResult Y�netmen_Bilgisi(string adisoyadi)                => Ok(new Y�netmenBilgileri(_context, _mapper).Ad�Soyad�_�le(adisoyadi));
	//
	[HttpPut()][Route("olu�tur")]           public IActionResult Y�netmen_Olu�tur([FromBody] Y�netmenModel pY�netmen)  => Ok(new Y�netmenOlu�tur(_context, _mapper).Handle(pY�netmen));
	//
	[HttpPut()][Route("g�ncelle")]          public IActionResult Y�netmen_G�ncelle([FromBody] Y�netmenModel pY�netmen) => Ok(new Y�netmenG�ncelle(_context, _mapper).Handle(pY�netmen));
	//
	[HttpPut()][Route("sil")]               public IActionResult Y�netmeni_Sil(int pId)                            => Ok(new Y�netmenS�L(_context, _mapper).Handle(pId));
	[HttpPut()][Route("sil2")]              public IActionResult Y�netmeni_Sil2([FromBody] int pId)                => Ok(new Y�netmenS�L(_context, _mapper).Handle(pId));


	}