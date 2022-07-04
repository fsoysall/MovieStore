using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

using AutoMapper.Configuration.Annotations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieStore.Data;



public class MFFT {


	public MFFT () { }

	public MFFT ( int pMId, int pTürId ) { MüşteriId = pMId; TürId = pTürId; }

	[Key][DatabaseGenerated( DatabaseGeneratedOption.Identity )]
	public int          Id        { get; set; }
	public int          MüşteriId { get; set; }
	public int          TürId     { get; set; }
	//
	public Müşteri?     Müşteri   { get; set; }
	public FilmTürü?    Tür       { get; set; }
	}
