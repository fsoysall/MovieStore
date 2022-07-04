using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStore.App.Aksiyonlar.Oyuncular;
using MovieStore.Data;
using MovieStore.Data.Model;
using MovieStore.DbActions;
using MovieStore.Services;


namespace MovieStore.Controllers;


[ApiController]
[Route("Oyuncular")]
public class OyuncuController : ControllerBase {

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly ILoggerService _logger;

	public OyuncuController(MovieStoreDbContext  pContext, IMapper pMapper, ILoggerService pLogger) { _context = pContext; _mapper = pMapper; _logger = pLogger; }



	[HttpPut()][Route("listesi")]           public IActionResult Oyuncu_Listesi()                                => Ok(new OyuncuBilgileri(_context, _mapper).T�mListe());
	[HttpPut()][Route("detay/{Id}")]        public IActionResult Oyuncu_Bilgisi(int Id)                          => Ok(new OyuncuBilgileri(_context, _mapper).Id_�le(Id));
	[HttpPut()][Route("detay/{adisoyadi}")] public IActionResult Oyuncu_Bilgisi(string adisoyadi)                => Ok(new OyuncuBilgileri(_context, _mapper).Ad�Soyad�_�le(adisoyadi));
	//
	[HttpPut()][Route("olu�tur")]           public IActionResult Oyuncu_Olu�tur([FromBody] OyuncuModel pOyuncu)  => Ok(new OyuncuOlu�tur(_context, _mapper).Handle(pOyuncu));
	//
	[HttpPut()][Route("g�ncelle")]          public IActionResult Oyuncu_G�ncelle([FromBody] OyuncuModel pOyuncu) => Ok(new OyuncuG�ncelle(_context, _mapper).Handle(pOyuncu));
	//
	[HttpPut()][Route("sil")]               public IActionResult Oyuncui_Sil(int pId)                            => Ok(new OyuncuS�L(_context, _mapper).Handle(pId));
	[HttpPut()][Route("sil2")]              public IActionResult Oyuncui_Sil2([FromBody] int pId)                => Ok(new OyuncuS�L(_context, _mapper).Handle(pId));


	}