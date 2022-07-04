using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Data;

public class AlışVeriş : Sipariş { }

public class Sipariş {

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int          Id        { get; set; }
	public int          MüşteriId { get; set; }
	public int          FilmId    { get; set; }
	public decimal      Fiyat     { get; set; }
	public DateTime     Tarih     { get; set; }

	}

