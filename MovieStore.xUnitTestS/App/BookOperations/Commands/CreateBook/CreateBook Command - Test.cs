using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using FluentAssertions;

using MovieStore.DbActions;
using MovieStore.UnitTests.TestSetup;

using Xunit;

namespace MovieStore.UnitTests.Application.BookOperations.Commands.CreateCommand {

	public class CreateBookCommandTests : IClassFixture<CommonTextFixture> {

		private readonly IMovieStoreDbContext _context;
		private readonly IMapper _mapper;


		public CreateBookCommandTests ( CommonTextFixture textFixture ) {
			_context = textFixture.Context;
			_mapper = textFixture.Mapper;
			}


		//[Fact]
		public void WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn () {

			///* A */
			//var book = new Book() { PageCount = 100, PublishDate = new DateTime( 2010, 1, 2 ), GenreId = 2, Title = "TEST:1: WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn", };
			//_context.Books.Add( book );
			//_context.SaveChanges();

			//var cmd = new CreateBookCommand( _context, _mapper ) { Model = new CreateBookModel() { Title = book.Title } };

			///* A */
			///* A */
			//FluentActions.Invoking( () => cmd.Handle() ).Should().Throw<InvalidOperationException>().And.Message.Should().Be( "Kayıt ZATEN VAR !" );

			}


		}

	}
