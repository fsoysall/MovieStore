using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.App.Aksiyonlar.AlýþVeriþler;
using MovieStore.App.Aksiyonlar.Filmler;
using MovieStore.App.Aksiyonlar.Yönetmenler;
using MovieStore.DbActions;
using MovieStore.Services;


namespace MovieStore.Controllers;


[ApiController]
//[Route("[controller]")]
[Route("/filmler/")]
public class FilmController : ControllerBase {

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly ILoggerService _logger;

	public FilmController(MovieStoreDbContext  pContext, IMapper pMapper, ILoggerService pLogger) { _context = pContext; _mapper = pMapper; _logger = pLogger; }

	[HttpPut()][Route("listesi")]              public IActionResult Film_Listesi()                            => Ok(new FilmBilgileri(_context, _mapper).TümListe());
	[HttpPut()][Route("detay/Id/{Id}")]        public IActionResult Film_Bilgisi(int Id)                      => Ok(new FilmBilgileri(_context, _mapper).Id_Ýle(Id));
	[HttpPut()][Route("detay/AS/{adisoyadi}")] public IActionResult Film_Bilgisi(string adisoyadi)            => Ok(new FilmBilgileri(_context, _mapper).AdýSoyadý_Ýle(adisoyadi));
	//
	[HttpPut()][Route("oluþtur")]              public IActionResult Film_Oluþtur([FromBody] FilmModel pFilm)  => Ok(new FilmOluþtur(_context, _mapper).Handle(pFilm));
	//
	[HttpPut()][Route("güncelle")]             public IActionResult Film_Güncelle([FromBody] FilmModel pFilm) => Ok(new FilmGüncelle(_context, _mapper).Handle(pFilm));
	//
	[HttpPut()][Route("sil")]                  public IActionResult Filmi_Sil(int pId)                        => Ok(new FilmSÝL(_context, _mapper).Handle(pId));
	[HttpPut()][Route("sil2")]                 public IActionResult Filmi_Sil2([FromBody] int pId)            => Ok(new FilmSÝL(_context, _mapper).Handle(pId));


	}


