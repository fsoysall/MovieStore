namespace MovieStore.Data {

	public class Kullanıcı {

		public int       Id               { get; set; }
		public string?   FullName         { get; set; }
		public string?   EMail            { get; set; }
		public string?   Password         { get; set; }
		public string?   RefreshToken     { get; set; }
		public DateTime? RTokenExpireDate { get; set; }

		}
	}