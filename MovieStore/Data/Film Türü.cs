using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Data;

public class FilmTürü {

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int           Id          { get; set; }
	public string?       Tür         { get; set; }
	
	//public eFilmTürleri2 FilmTürleri23 { get; set; }
	//public int FilmTürleri { get; set; }

	// public ICollection<Film> Movies { get; set; }
	// public ICollection<CustomerGenre> CustomerGenres { get; set; }


	}