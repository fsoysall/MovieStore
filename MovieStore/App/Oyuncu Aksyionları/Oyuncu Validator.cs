using FluentValidation;

using MovieStore.Data;

namespace MovieStore.App.Aksiyonlar.Oyuncular;


public class OyuncuValidator : AbstractValidator<Oyuncu> {

	public OyuncuValidator () { }


	public OyuncuValidator DefaultRules () {
		RuleFor( r => r.AdıSoyadı ).NotEmpty().MinimumLength( 3 );
		return this;
		}



	public OyuncuValidator RulesFor_Create () {
		this.DefaultRules();
		RuleFor( r => r.Id ).Equal( 0 );
		return this;
		}

	public OyuncuValidator RulesFor_Update () {
		this.DefaultRules();
		RuleFor( r => r.Id ).GreaterThan( 0 );
		return this;
		}

	public OyuncuValidator RulesFor_Read () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	public OyuncuValidator RulesFor_Delete () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	}
