
using FluentValidation;

using MovieStore.Data;



namespace MovieStore.App.Aksiyonlar.Yönetmenler;


public class YönetmenValidator : AbstractValidator<Yönetmen> {

	public YönetmenValidator () { }


	public YönetmenValidator DefaultRules () {
		RuleFor( r => r.AdıSoyadı ).NotEmpty().MinimumLength( 3 );
		return this;
		}



	public YönetmenValidator RulesFor_Create () {
		this.DefaultRules();
		RuleFor( r => r.Id ).Equal( 0 );
		return this;
		}

	public YönetmenValidator RulesFor_Update () {
		this.DefaultRules();
		RuleFor( r => r.Id ).GreaterThan( 0 );
		return this;
		}

	public YönetmenValidator RulesFor_Read () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	public YönetmenValidator RulesFor_Delete () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	}
