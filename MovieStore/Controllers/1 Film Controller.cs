using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStore.App.Aksiyonlar.Al��Veri�ler;
using MovieStore.App.Aksiyonlar.Filmler;
using MovieStore.App.Aksiyonlar.Y�netmenler;
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

	[HttpPut()][Route("listesi")]              public IActionResult Film_Listesi()                            => Ok(new FilmBilgileri(_context, _mapper).T�mListe());
	[HttpPut()][Route("detay/Id/{Id}")]        public IActionResult Film_Bilgisi(int Id)                      => Ok(new FilmBilgileri(_context, _mapper).Id_�le(Id));
	[HttpPut()][Route("detay/AS/{adisoyadi}")] public IActionResult Film_Bilgisi(string adisoyadi)            => Ok(new FilmBilgileri(_context, _mapper).Ad�Soyad�_�le(adisoyadi));
	//
	[HttpPut()][Route("olu�tur")]              public IActionResult Film_Olu�tur([FromBody] FilmModel pFilm)  => Ok(new FilmOlu�tur(_context, _mapper).Handle(pFilm));
	//
	[HttpPut()][Route("g�ncelle")]             public IActionResult Film_G�ncelle([FromBody] FilmModel pFilm) => Ok(new FilmG�ncelle(_context, _mapper).Handle(pFilm));
	//
	[HttpPut()][Route("sil")]                  public IActionResult Filmi_Sil(int pId)                        => Ok(new FilmS�L(_context, _mapper).Handle(pId));
	[HttpPut()][Route("sil2")]                 public IActionResult Filmi_Sil2([FromBody] int pId)            => Ok(new FilmS�L(_context, _mapper).Handle(pId));


	}


