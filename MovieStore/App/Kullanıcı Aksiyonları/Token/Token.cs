﻿namespace MovieStore.App.Aksiyonlar.Kullanıcılar;

public class Token {

	public string? AccessToken { get; set; }
	public string? RefreshToken { get; set; }
	public DateTime Expiration { get; set; }

	}

