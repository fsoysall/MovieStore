using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStore.App.Aksiyonlar.Kullan�c�lar;
using MovieStore.Data;
using MovieStore.Data.Model;
using MovieStore.DbActions;
using MovieStore.Services;

namespace MovieStore.Controllers;

[ApiController]
[Route("Kullan�c�lar")]
public class Kullan�c�Controller : ControllerBase {

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly ILoggerService _logger;

	public Kullan�c�Controller(MovieStoreDbContext  pContext, IMapper pMapper, ILoggerService pLogger) { _context = pContext; _mapper = pMapper; _logger = pLogger; }


	[HttpPut()][Route("list")]                 public IActionResult User_Create()                                            => Ok();
	[HttpPut()][Route("get/{Id}")]             public IActionResult User_Create(int Id)                                      => Ok();
	[HttpPut()][Route("create")]               public IActionResult User_Create([FromBody] Kullan�c� Kullan�c�)              => Ok();
	[HttpPut()][Route("update")]               public IActionResult User_Update([FromBody] Kullan�c� pKullan�c�)             => Ok();
	[HttpPut()][Route("delete")]               public IActionResult User_Delete(int pId)                                     => Ok();
	[HttpPut()][Route("delet2")]               public IActionResult User_Delete2([FromBody] int pId)                         => Ok();
	//
	[HttpPut()][Route("listesi")]              public IActionResult Kullan�c�_Listesi()                                      => Ok(new Kullan�c�Bilgileri(_context, _mapper).T�mKay�tlar());
	[HttpPut()][Route("detay/Id/{Id}")]        public IActionResult Kullan�c�_Bilgisi(int Id)                                => Ok(new Kullan�c�Bilgileri(_context, _mapper).Id_�le(Id));
	[HttpPut()][Route("detay/AS/{adisoyadi}")] public IActionResult Kullan�c�_Bilgisi(string adisoyadi)                      => Ok(new Kullan�c�Bilgileri(_context, _mapper).KullAd�_ile(adisoyadi));
	//
	[HttpPut()][Route("olu�tur")]              public IActionResult Kullan�c�_Olu�tur([FromBody] Kullan�c�Model pKullan�c�)  => Ok(new Kullan�c�Olu�tur(_context, _mapper).Handle(pKullan�c�));
	//
	[HttpPut()][Route("g�ncelle")]             public IActionResult Kullan�c�_G�ncelle([FromBody] Kullan�c�Model pKullan�c�) => Ok(new Kullan�c�G�ncelle(_context, _mapper).Handle(pKullan�c�));
	//
	[HttpPut()][Route("sil")]                  public IActionResult Kullan�c�i_Sil(int pId)                                  => Ok(new Kullan�c�S�L(_context, _mapper).Handle(pId));
	[HttpPut()][Route("sil2")]                 public IActionResult Kullan�c�i_Sil2([FromBody] int pId)                      => Ok(new Kullan�c�S�L(_context, _mapper).Handle(pId));


	}