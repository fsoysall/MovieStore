using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStore.App.Aksiyonlar.Al��Veri�ler;
using MovieStore.App.Aksiyonlar.M��teriler;
using MovieStore.Data;
using MovieStore.Data.Model;
using MovieStore.DbActions;
using MovieStore.Services;


namespace MovieStore.Controllers;


[ApiController]
//[Route("[controller]")]
[Route("/M��teriler/")]
public class M��teriController : ControllerBase {

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly ILoggerService _logger;

	public M��teriController(MovieStoreDbContext  pContext, IMapper pMapper, ILoggerService pLogger) { _context = pContext; _mapper = pMapper; _logger = pLogger; }

	[HttpPut()][Route("listesi")]           public IActionResult M��teri_Listesi()                                  => Ok(new M��teriBilgileri(_context, _mapper).T�mListe());
	[HttpPut()][Route("detay/{Id}")]        public IActionResult M��teri_Bilgisi(int Id)                            => Ok(new M��teriBilgileri(_context, _mapper).Id_�le(Id));
	[HttpPut()][Route("detay/{adisoyadi}")] public IActionResult M��teri_Bilgisi(string adisoyadi)                  => Ok(new M��teriBilgileri(_context, _mapper).Ad�Soyad�_�le(adisoyadi));
	//
	[HttpPut()][Route("olu�tur")]           public IActionResult M��teri_Olu�tur([FromBody] M��teriModel pM��teri)  => Ok(new M��teriOlu�tur(_context, _mapper).Handle(pM��teri));
	//
	[HttpPut()][Route("g�ncelle")]          public IActionResult M��teri_G�ncelle([FromBody] M��teriModel pM��teri) => Ok(new M��teriG�ncelle(_context, _mapper).Handle(pM��teri));
	//
	[HttpPut()][Route("sil")]               public IActionResult M��terii_Sil(int pId)                              => Ok(new M��teriS�L(_context, _mapper).Handle(pId));
	[HttpPut()][Route("sil2")]              public IActionResult M��terii_Sil2([FromBody] int pId)                  => Ok(new M��teriS�L(_context, _mapper).Handle(pId));


	}




