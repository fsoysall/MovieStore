using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using AutoMapper.Configuration.Annotations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieStore.Data;

public class Müşteri {

	
	[Key][DatabaseGenerated( DatabaseGeneratedOption.Identity )]
	public   int     Id                 { get; set; }
	public   string? AdıSoyadı          { get; set; }
	public   string? SatınAldığıFilmler { get; set; }
	public   string? EPosta             { get; set; }
	public   string? GSM                { get; set; }

	}

