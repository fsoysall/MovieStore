using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using FluentAssertions;

using FluentValidation;

using MovieStore.DbActions;
using MovieStore.UnitTests.TestSetup;

using Xunit;

namespace MovieStore.UnitTests.Application.AuthorOperations {

	public class Author_CommandS_TestS : IClassFixture<CommonTextFixture> {
		
		readonly IMovieStoreDbContext _context;
		readonly IMapper _mapper;


		public Author_CommandS_TestS(CommonTextFixture textFixture) {
			_context = textFixture.Context;
			_mapper = textFixture.Mapper;
			}


		//[Fact]
		public void Author_CRUD_Tests() {
			/* A:1 */
			//var book = new Book() { Title = "TESTO 1", AuthorId = 12, GenreId = 2, PageCount = 5, PublishDate = DateTime.Now, };
			//var author = new Author() { BirthDate = DateTime.Now.AddYears(2), Name = "test author 12" };

			//_context.Books.Add(book);
			//_context.SaveChanges();

			//var cmd = new CreateAuthorCommands(_context, _mapper);
			///* A:2 */
			///* A:3 */
			//FluentActions.Invoking(() => cmd.Handle(author)).Should().Throw<FluentValidation.ValidationException>().And.Errors.Should().HaveCountGreaterThan(0);


			//_context.Authors.Add(author);
			//_context.SaveChanges();

			//author = new Author() { BirthDate = DateTime.Now.AddYears(-22), Name = "test author 12" };
			//FluentActions.Invoking(() => cmd.Handle(author)).Should().Throw<InvalidOperationException>().And.Message.Should().StartWith("Kayıt ZATEN VAR !");

			//_context.Authors.Add(author);
			//_context.SaveChanges();
			//author = new Author() { BirthDate = DateTime.Now.AddYears(-22), Name = "test author 12" };
			//FluentActions.Invoking(() => cmd.Handle(author)).Should().Throw<InvalidOperationException>().And.Message.Should().Contain("Kayıt ZATEN VAR !");



			}


		}

	}
