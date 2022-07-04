using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace MovieStore.Data;

	[Index(nameof(Id), Name = "a1",IsUnique = true)]
	public class Film {

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int            Id         { get; set; }

	public string?        Adı        { get; set; }
	public string?        Yılı       { get; set; }
	//
	//public eFilmTürleri TürId      { get; set; }
	public int            TürId      { get; set; }
	public FilmTürü?      Tür        { get; set; }
	//
	public int?           YönetmenId { get; set; }
	public Yönetmen?      Yönetmen   { get; set; }
	//
	public List<Oyuncu>?  Oyuncular  { get; set; }
	//public List<int>?   Oyuncular  { get; set; }
	//
	public decimal        Fiyat      { get; set; }

	}