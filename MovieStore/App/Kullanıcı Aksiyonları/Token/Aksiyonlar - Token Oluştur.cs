
using AutoMapper;

using MovieStore.DbActions;

namespace MovieStore.App.Aksiyonlar.Kullanıcılar;

public class TokenOluştur {

	public ModelTokenOluştur Model { get; set; }
	public string? Token { get; set; }

	private readonly MovieStoreDbContext  _context;
	private readonly IMapper _mapper;
	private readonly IConfiguration _config;


	public TokenOluştur ( MovieStoreDbContext  pContext, IMapper pMapper, IConfiguration pConfig ) { _context = pContext; _mapper = pMapper; _config = pConfig; Model = new ModelTokenOluştur(); }

	public void Handle () => this.Handle( Model );
	public Token Handle ( ModelTokenOluştur Token ) {
		// new TokenValidator().RulesFor_Create().ValidateAndThrow( Token );

		var user = _context.Kullanıcılar.SingleOrDefault( s => s.EMail == Token.EMail && s.Password == Token.Password );
		if ( user is not null ) {
			var token = new TokenHandler( _config ).CreateAccessToken( user );

			user.RefreshToken = token.RefreshToken;
			user.RTokenExpireDate = token.Expiration.AddMinutes( 5 );
			_context.SaveChanges();

			return token;
			}

		else { throw new InvalidOperationException( $"Geçersiz Kullanıcı ! [ {Token.EMail} ] " ); }

		}

	}



