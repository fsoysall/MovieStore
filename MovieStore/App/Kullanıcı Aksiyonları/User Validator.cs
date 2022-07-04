
using FluentValidation;

using MovieStore.Data;


namespace MovieStore.App.Aksiyonlar.Kullanıcılar;


public class KullanıcıValidator : AbstractValidator<Kullanıcı> {

	public KullanıcıValidator () { }


	public KullanıcıValidator DefaultRules () {
		RuleFor( r => r.FullName ).NotEmpty().MinimumLength( 3 );
		return this;
		}



	public KullanıcıValidator RulesFor_Create () {
		this.DefaultRules();
		RuleFor( r => r.Id ).Equal( 0 );
		return this;
		}

	public KullanıcıValidator RulesFor_Update () {
		this.DefaultRules();
		RuleFor( r => r.Id ).GreaterThan( 0 );
		return this;
		}

	public KullanıcıValidator RulesFor_Read () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	public KullanıcıValidator RulesFor_Delete () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	}
