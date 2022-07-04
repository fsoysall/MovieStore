using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStore.App.Aksiyonlar.Kullanýcýlar;
using MovieStore.Data;
using MovieStore.Data.Model;
using MovieStore.DbActions;
using MovieStore.Services;

namespace MovieStore.Controllers;

[ApiController]
[Route("Kullanýcýlar")]
public class KullanýcýController : ControllerBase {

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly ILoggerService _logger;

	public KullanýcýController(MovieStoreDbContext  pContext, IMapper pMapper, ILoggerService pLogger) { _context = pContext; _mapper = pMapper; _logger = pLogger; }


	[HttpPut()][Route("list")]                 public IActionResult User_Create()                                            => Ok();
	[HttpPut()][Route("get/{Id}")]             public IActionResult User_Create(int Id)                                      => Ok();
	[HttpPut()][Route("create")]               public IActionResult User_Create([FromBody] Kullanýcý Kullanýcý)              => Ok();
	[HttpPut()][Route("update")]               public IActionResult User_Update([FromBody] Kullanýcý pKullanýcý)             => Ok();
	[HttpPut()][Route("delete")]               public IActionResult User_Delete(int pId)                                     => Ok();
	[HttpPut()][Route("delet2")]               public IActionResult User_Delete2([FromBody] int pId)                         => Ok();
	//
	[HttpPut()][Route("listesi")]              public IActionResult Kullanýcý_Listesi()                                      => Ok(new KullanýcýBilgileri(_context, _mapper).TümKayýtlar());
	[HttpPut()][Route("detay/Id/{Id}")]        public IActionResult Kullanýcý_Bilgisi(int Id)                                => Ok(new KullanýcýBilgileri(_context, _mapper).Id_Ýle(Id));
	[HttpPut()][Route("detay/AS/{adisoyadi}")] public IActionResult Kullanýcý_Bilgisi(string adisoyadi)                      => Ok(new KullanýcýBilgileri(_context, _mapper).KullAdý_ile(adisoyadi));
	//
	[HttpPut()][Route("oluþtur")]              public IActionResult Kullanýcý_Oluþtur([FromBody] KullanýcýModel pKullanýcý)  => Ok(new KullanýcýOluþtur(_context, _mapper).Handle(pKullanýcý));
	//
	[HttpPut()][Route("güncelle")]             public IActionResult Kullanýcý_Güncelle([FromBody] KullanýcýModel pKullanýcý) => Ok(new KullanýcýGüncelle(_context, _mapper).Handle(pKullanýcý));
	//
	[HttpPut()][Route("sil")]                  public IActionResult Kullanýcýi_Sil(int pId)                                  => Ok(new KullanýcýSÝL(_context, _mapper).Handle(pId));
	[HttpPut()][Route("sil2")]                 public IActionResult Kullanýcýi_Sil2([FromBody] int pId)                      => Ok(new KullanýcýSÝL(_context, _mapper).Handle(pId));


	}