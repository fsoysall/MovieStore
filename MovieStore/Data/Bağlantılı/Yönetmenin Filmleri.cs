using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Data;

public class YönetmeninFilmleri {

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int          Id                               { get; set; }
	//
	public int?         FilmId                           { get; set; }
	public int?         YönetmenId                       { get; set; }
	//
	public Film?        Film                             { get; set; }
	public Yönetmen?    Yönetmen                         { get; set; }

	}
