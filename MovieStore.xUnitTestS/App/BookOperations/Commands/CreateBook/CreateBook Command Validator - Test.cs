using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using FluentAssertions;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

using MovieStore.DbActions;
using MovieStore.UnitTests.TestSetup;

using Xunit;

namespace MovieStore.UnitTests.Application.BookOperations.Commands.CreateCommand {

	public class CreateBookCommandValidatorTests : IClassFixture<CommonTextFixture> {

		private readonly IMovieStoreDbContext _context;
		private readonly IMapper _mapper;


		public CreateBookCommandValidatorTests(CommonTextFixture textFixture) { _context = textFixture.Context; _mapper = textFixture.Mapper; }


		//[Theory]
		[InlineData("Lord Of The Rings", 0, 0)]
		[InlineData("Lord Of The Rings", 0, 1)]
		[InlineData("", 0, 0)]
		[InlineData("", 100, 1)]
		[InlineData("", 0, 1)]
		[InlineData("Lor", 100, 1)]
		[InlineData("Lor", 100, 0)]
		[InlineData("Lord", 100, 1)]
		[InlineData("Lord", 0, 1)]
		[InlineData(" ", 100, 1)]
		[InlineData("Lord Of The Rings", 100, 1)]
		public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId) {
			///* A */
			//var cmd = new CreateBookCommand( null, null ) {
			//	Model = new CreateBookModel() {
			//		Title = title,
			//		PageCount = pageCount,
			//		PublishDate = DateTime.Now.Date.AddYears( -1 ),
			//		GenreId = genreId
			//		}
			//	};

			///* A */
			//var result = new CreateBookCommandValidator().Validate( cmd );

			///* A */
			//result.Errors.Count.Should().BeGreaterThan( 0 );
			////FluentActions.Invoking( () => cmd.Handle() ).Should().Throw<InvalidOperationException>().And.Message.Should().Be( "Kayıt ZATEN VAR !" );
			//
			}

		//[Fact]
		public void WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn() {
			///* A */
			//var book = new Book() { PageCount = 100, PublishDate = new DateTime( 2010, 1, 2 ), GenreId = 2, Title = "TEST:2: WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn", };
			//_context.Books.Add( book );
			//_context.SaveChanges();


			//var cmd = new CreateBookCommand( null, null ) {
			//	Model = new CreateBookModel() {
			//		Title = book.Title,
			//		PageCount = 0,
			//		PublishDate = DateTime.Now.Date,
			//		GenreId = 0
			//		}
			//	};

			///* A */
			//var validator = new CreateBookCommandValidator();
			//var result = validator.Validate( cmd );

			///* A */
			//result.Errors.Count.Should().BeGreaterThan( 0 );
			////FluentActions.Invoking( () => cmd.Handle() ).Should().Throw<InvalidOperationException>().And.Message.Should().Be( "Kayıt ZATEN VAR !" );

			}


		[Fact]
		public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnNull() {
			///* A */
			//var cmd = new CreateBookCommand( null, null ) {
			//	Model = new CreateBookModel() {
			//		PublishDate = DateTime.Now.Date /* DateTime.Now.Date */,
			//		Title = "Lord",
			//		PageCount = 10,
			//		GenreId = 1,
			//		}
			//	};

			///* A */
			//var result = new CreateBookCommandValidator().Validate( cmd );

			///* A */
			//result.Errors.Count.Should().BeGreaterThan( 0 );
			////FluentActions.Invoking( () => cmd.Handle() ).Should().Throw<InvalidOperationException>().And.Message.Should().Be( "Kayıt ZATEN VAR !" );

			}

		[Fact]
		public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError() {
			///* A */
			//var cmd = new CreateBookCommand( null, null ) {
			//	Model = new CreateBookModel() {
			//		PublishDate = DateTime.Now.Date.AddYears( -2 ),
			//		Title = "Lord",
			//		PageCount = 100,
			//		GenreId = 1,
			//		}
			//	};

			///* A */
			//var result = new CreateBookCommandValidator().Validate( cmd );

			///* A */
			//result.Errors.Count.Should().Be( 0 );
			////FluentActions.Invoking( () => cmd.Handle() ).Should().Throw<InvalidOperationException>().And.Message.Should().Be( "Kayıt ZATEN VAR !" );
			//
			}

		[Fact]
		public void WhenValidInputsAreGiven_Book_SholdBeCreated() {
			///* A */
			//var cmd = new CreateBookCommand( _context, _mapper) {
			//	Model = new CreateBookModel() {
			//		PublishDate = DateTime.Now.Date.AddYears( -2 ),
			//		Title = "WhenValidInputsAreGiven_Book_SholdBeCreated",
			//		PageCount = 100,
			//		GenreId = 1,
			//		}
			//	};

			/* A */
			//var result = new CreateBookCommandValidator().Validate( cmd );
			//FluentActions.Invoking( () => cmd.Handle() ).Invoke();//.Should().Throw<InvalidOperationException>().And.Message.Should().Be( "Kayıt ZATEN VAR !" );

			///* A */
			////result.Errors.Count.Should().Be( 0 );
			//var book = _context.Books.Single( s => s.Title == cmd.Model.Title );

			//book.Should().NotBeNull();
			//book.PageCount.Should().Be( cmd.Model.PageCount );
			//book.PublishDate.Should().Be( cmd.Model.PublishDate);
			//book.GenreId.Should().Be( cmd.Model.GenreId);

			}



		}

	}
