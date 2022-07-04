using System.IdentityModel.Tokens.Jwt;
using System.Text;

using Microsoft.IdentityModel.Tokens;

using MovieStore.Data;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieStore.App.Aksiyonlar.Kullanıcılar;

public class TokenHandler {

	//private readonly MovieStoreDbContext  _DbContext;
	//private readonly IMapper _Mapper;
	private readonly IConfiguration _config;


	public TokenHandler ( IConfiguration pConfig ) { _config = pConfig; }


	public Token CreateAccessToken ( Kullanıcı user ) {
		if ( user is null ) { throw new ArgumentNullException( nameof( user ) ); }

		var tokenModel = new Token();
		var key = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _config [ "Token:SecurityKey" ] ) );
		var signingCredentials = new SigningCredentials( key, SecurityAlgorithms.HmacSha256 );

		tokenModel.Expiration = DateTime.Now.AddMinutes( 5 );
		var secToken = new JwtSecurityToken( issuer: _config [ "Token:Issuer" ],
														audience: _config [ "Token:Audience" ],
														expires: tokenModel.Expiration,
														notBefore: DateTime.Now,
														signingCredentials: signingCredentials
														);

		var tokenHandler = new JwtSecurityTokenHandler();
		tokenModel.AccessToken = tokenHandler.WriteToken( secToken );
		tokenModel.RefreshToken = CreateRefreshToken();

		return tokenModel;
		}


	public string CreateRefreshToken () { return Guid.NewGuid().ToString(); }


	}

