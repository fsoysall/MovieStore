using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStore.App.Aksiyonlar.Kullanıcılar;
using MovieStore.Data;
using MovieStore.Data.Model;
using MovieStore.DbActions;
using MovieStore.Services;

namespace MovieStore.Controllers;

[ApiController]
[Route("Kullanıcılar")]
public class KullanıcıController : ControllerBase {

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly ILoggerService _logger;

	public KullanıcıController(MovieStoreDbContext  pContext, IMapper pMapper, ILoggerService pLogger) { _context = pContext; _mapper = pMapper; _logger = pLogger; }


	[HttpPut()][Route("list")]                 public IActionResult User_Create()                                            => Ok();
	[HttpPut()][Route("get/{Id}")]             public IActionResult User_Create(int Id)                                      => Ok();
	[HttpPut()][Route("create")]               public IActionResult User_Create([FromBody] Kullanıcı Kullanıcı)              => Ok();
	[HttpPut()][Route("update")]               public IActionResult User_Update([FromBody] Kullanıcı pKullanıcı)             => Ok();
	[HttpPut()][Route("delete")]               public IActionResult User_Delete(int pId)                                     => Ok();
	[HttpPut()][Route("delet2")]               public IActionResult User_Delete2([FromBody] int pId)                         => Ok();
	//
	[HttpPut()][Route("listesi")]              public IActionResult Kullanıcı_Listesi()                                      => Ok(new KullanıcıBilgileri(_context, _mapper).TümKayıtlar());
	[HttpPut()][Route("detay/Id/{Id}")]        public IActionResult Kullanıcı_Bilgisi(int Id)                                => Ok(new KullanıcıBilgileri(_context, _mapper).Id_İle(Id));
	[HttpPut()][Route("detay/AS/{adisoyadi}")] public IActionResult Kullanıcı_Bilgisi(string adisoyadi)                      => Ok(new KullanıcıBilgileri(_context, _mapper).KullAdı_ile(adisoyadi));
	//
	[HttpPut()][Route("oluştur")]              public IActionResult Kullanıcı_Oluştur([FromBody] KullanıcıModel pKullanıcı)  => Ok(new KullanıcıOluştur(_context, _mapper).Handle(pKullanıcı));
	//
	[HttpPut()][Route("güncelle")]             public IActionResult Kullanıcı_Güncelle([FromBody] KullanıcıModel pKullanıcı) => Ok(new KullanıcıGüncelle(_context, _mapper).Handle(pKullanıcı));
	//
	[HttpPut()][Route("sil")]                  public IActionResult Kullanıcıi_Sil(int pId)                                  => Ok(new KullanıcıSİL(_context, _mapper).Handle(pId));
	[HttpPut()][Route("sil2")]                 public IActionResult Kullanıcıi_Sil2([FromBody] int pId)                      => Ok(new KullanıcıSİL(_context, _mapper).Handle(pId));


	}