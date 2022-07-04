using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Data;

public class Oyuncu {

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int           Id                               { get; set; }
	public string?       AdıSoyadı                        { get; set; }
	//
	public List<Film>?    OynadığıFilmler                 { get; set; }

	}

