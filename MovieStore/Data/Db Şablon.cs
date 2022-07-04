using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Data;

public abstract class DbŞablon {

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int       Id              { get; set; }
	//
	public DateTime? OluşturmaZamanı { get; set; } = DateTime.Now;
	public bool      AktifMi         { get; set; } = true;

	}