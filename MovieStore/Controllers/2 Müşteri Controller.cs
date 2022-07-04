using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStore.App.Aksiyonlar.AlýþVeriþler;
using MovieStore.App.Aksiyonlar.Müþteriler;
using MovieStore.Data;
using MovieStore.Data.Model;
using MovieStore.DbActions;
using MovieStore.Services;


namespace MovieStore.Controllers;


[ApiController]
//[Route("[controller]")]
[Route("/Müþteriler/")]
public class MüþteriController : ControllerBase {

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly ILoggerService _logger;

	public MüþteriController(MovieStoreDbContext  pContext, IMapper pMapper, ILoggerService pLogger) { _context = pContext; _mapper = pMapper; _logger = pLogger; }

	[HttpPut()][Route("listesi")]           public IActionResult Müþteri_Listesi()                                  => Ok(new MüþteriBilgileri(_context, _mapper).TümListe());
	[HttpPut()][Route("detay/{Id}")]        public IActionResult Müþteri_Bilgisi(int Id)                            => Ok(new MüþteriBilgileri(_context, _mapper).Id_Ýle(Id));
	[HttpPut()][Route("detay/{adisoyadi}")] public IActionResult Müþteri_Bilgisi(string adisoyadi)                  => Ok(new MüþteriBilgileri(_context, _mapper).AdýSoyadý_Ýle(adisoyadi));
	//
	[HttpPut()][Route("oluþtur")]           public IActionResult Müþteri_Oluþtur([FromBody] MüþteriModel pMüþteri)  => Ok(new MüþteriOluþtur(_context, _mapper).Handle(pMüþteri));
	//
	[HttpPut()][Route("güncelle")]          public IActionResult Müþteri_Güncelle([FromBody] MüþteriModel pMüþteri) => Ok(new MüþteriGüncelle(_context, _mapper).Handle(pMüþteri));
	//
	[HttpPut()][Route("sil")]               public IActionResult Müþterii_Sil(int pId)                              => Ok(new MüþteriSÝL(_context, _mapper).Handle(pId));
	[HttpPut()][Route("sil2")]              public IActionResult Müþterii_Sil2([FromBody] int pId)                  => Ok(new MüþteriSÝL(_context, _mapper).Handle(pId));


	}




