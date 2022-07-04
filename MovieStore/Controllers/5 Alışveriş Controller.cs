using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MovieStore.Data;
using MovieStore.Data.Model;
using MovieStore.DbActions;
using MovieStore.Services;


namespace MovieStore.Controllers;


[ApiController]
[Route("AlýþVeriþ")]
public class zAlýþVeriþController : ControllerBase {

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly ILoggerService _logger;

	public zAlýþVeriþController(MovieStoreDbContext  pContext, IMapper pMapper, ILoggerService pLogger) { _context = pContext; _mapper = pMapper; _logger = pLogger; }


	[HttpPut()][Route("list")]     public IActionResult User_Create()                              => Ok();
	[HttpPut()][Route("get/{Id}")] public IActionResult User_Create(int Id)                        => Ok();
	[HttpPut()][Route("create")]   public IActionResult User_Create([FromBody] Sipariþ AlýþVeriþ)  => Ok();
	[HttpPut()][Route("update")]   public IActionResult User_Update([FromBody] Sipariþ pAlýþVeriþ) => Ok();
	[HttpPut()][Route("delete")]   public IActionResult User_Delete(int pId)                       => Ok();
	[HttpPut()][Route("delet2")]   public IActionResult User_Delete2([FromBody] int pId)           => Ok();


	}