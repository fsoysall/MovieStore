using FluentValidation;

using MovieStore.Data;


namespace MovieStore.App.Aksiyonlar.AlışVerişler;


public class AlışVerişValidator : AbstractValidator<Sipariş> {

	public AlışVerişValidator () { }


	public AlışVerişValidator DefaultRules () {
		RuleFor( r => r.FilmId ).GreaterThan( 0 );
		RuleFor( r => r.MüşteriId ).GreaterThan( 0 );
		
		RuleFor( r => r.Fiyat ).GreaterThan( 0 );

		RuleFor( r => r.Tarih ).NotEmpty();
		return this;
		}



	public AlışVerişValidator RulesFor_Create () {
		this.DefaultRules();
		RuleFor( r => r.Id ).Equal( 0 );
		return this;
		}

	public AlışVerişValidator RulesFor_Update () {
		this.DefaultRules();
		RuleFor( r => r.Id ).GreaterThan( 0 );
		return this;
		}

	public AlışVerişValidator RulesFor_Read () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	public AlışVerişValidator RulesFor_Delete () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	}
