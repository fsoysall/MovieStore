using AutoMapper;

using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Kullanıcılar;


public class TokenYenile {

	public string? RefreshToken { get; set; }

	private readonly MovieStoreDbContext  _DbContext;
	private readonly IMapper _Mapper;
	private readonly IConfiguration _config;


	public TokenYenile ( MovieStoreDbContext  pContext, IMapper pMapper, IConfiguration pConfig ) { _DbContext = pContext; _Mapper = pMapper; _config = pConfig; }

	public Token Handle () => this.Handle( RefreshToken );

	public Token Handle ( string? pToken ) {
		// new TokenValidator().RulesFor_Refresh().ValidateAndThrow( Token );

		var user = _DbContext.Kullanıcılar.SingleOrDefault( s => s.RefreshToken == pToken && s.RTokenExpireDate >= DateTime.Now );
		if ( user is not null ) {
			var handler = new TokenHandler( _config );
			var token = handler.CreateAccessToken( user );

			user.RefreshToken = token.RefreshToken;
			user.RTokenExpireDate = token.Expiration.AddMinutes( 5 );
			return token;
			}
		else {
			throw new InvalidOperationException( "İlgili Token Bulunamadı !" );
			}

		}
	}
