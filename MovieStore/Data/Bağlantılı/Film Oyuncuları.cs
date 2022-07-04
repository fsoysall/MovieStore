using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Data;

public class FilminOyuncuları {

	[Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int     Id       { get; set; }
	//
	public int?    OyuncuId { get; set; }
	public int?    FilmId   { get; set; }
	//
	public Oyuncu? Oyuncu   { get; set; }
	public Film?   Film     { get; set; }

	}