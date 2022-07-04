using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MovieStore.DbActions;

using MovieStore.Common;
using MovieStore.DbOpers;

namespace MovieStore.UnitTests.TestSetup {

	public class CommonTextFixture {

		public MovieStoreDbContext Context { get; set; }
		public IMapper Mapper { get; set; }


		public CommonTextFixture() {
			var db = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "MovieStore_Test_DB")
			.EnableSensitiveDataLogging().EnableDetailedErrors();
			var options = db.Options;


			Context = new MovieStoreDbContext(options);
			DataGenerator.Initialize(Context);

			//Context.Database.EnsureCreated();
			//Context.FilmleriEkle   ();
			//Context.MüşterileriEkle();
			//Context.OyuncularıEkle ();
			//Context.YönetmenEkle   ();
			//Context.SiparişleriEkle();

			Mapper = new MapperConfiguration(c => c.AddProfile<MappingProfile>()).CreateMapper();

			}

		}
	}
