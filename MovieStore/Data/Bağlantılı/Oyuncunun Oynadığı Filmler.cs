using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

using AutoMapper.Configuration.Annotations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieStore.Data;



// Oyuncu - Oynadığı Filmler
public class OOF {


	public OOF () { }
	public OOF ( int pOyuncuId, int pFilmId ) { OyuncuId = pOyuncuId; FilmId = pFilmId; }

	[Key][DatabaseGenerated( DatabaseGeneratedOption.Identity )]
	public int Id { get; set; }
	//
	public int OyuncuId { get; set; }
	public int FilmId { get; set; }
	//
	public Oyuncu? Oyuncu { get; set; }
	public Film? Film { get; set; }
	}
