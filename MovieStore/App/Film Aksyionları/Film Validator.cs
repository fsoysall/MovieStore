using FluentValidation;

using MovieStore.Data;

namespace MovieStore.App.Aksiyonlar.Filmler;


public class FilmValidator : AbstractValidator<Film> {

	public FilmValidator () { }


	public FilmValidator DefaultRules () {
		RuleFor( r => r.Adı ).NotEmpty().MinimumLength( 3 );
		RuleFor( r => r.TürId ).GreaterThan( -1 );
		RuleFor( r => r.Yılı ).NotEmpty();
		return this;
		}



	public FilmValidator RulesFor_Create () {
		this.DefaultRules();
		RuleFor( r => r.Id ).Equal( 0 );
		return this;
		}

	public FilmValidator RulesFor_Update () {
		this.DefaultRules();
		RuleFor( r => r.Id ).GreaterThan( 0 );
		return this;
		}

	public FilmValidator RulesFor_Read () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	public FilmValidator RulesFor_Delete () { RuleFor( r => r.Id ).GreaterThan( 0 ); return this; }

	}
