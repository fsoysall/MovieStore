using FluentValidation;

using MovieStore.Data;


namespace MovieStore.App.Aksiyonlar.Müşteriler;


public class MüşteriValidator : AbstractValidator<Müşteri> {

	public MüşteriValidator () { }


	public MüşteriValidator DefaultRules () {
		RuleFor( r => r.AdıSoyadı ).NotEmpty().MinimumLength( 3 );
		RuleFor( r => r.EPosta ).NotEmpty().MinimumLength( 3 ).Must( m => m.Contains( '@' ) );
		return this;
		}



	public MüşteriValidator RulesFor_Create () {
		this.DefaultRules();
		RuleFor( r => r.Id ).Equal( 0 );
		return this;
		}

	public MüşteriValidator RulesFor_Update () {
		this.DefaultRules();
		RuleFor( r => r.Id ).GreaterThan( 0 );
		return this;
		}

	public MüşteriValidator RulesFor_Read () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	public MüşteriValidator RulesFor_Delete () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	}
