
using AutoMapper;

using MovieStore.App.Aksiyonlar.AlýþVeriþler;
using MovieStore.App.Aksiyonlar.Filmler;
using MovieStore.App.Aksiyonlar.Kullanýcýlar;
using MovieStore.App.Aksiyonlar.Müþteriler;
using MovieStore.App.Aksiyonlar.Oyuncular;
using MovieStore.Data;

namespace MovieStore.Common {

	public class MappingProfile : Profile {

		public MappingProfile() {

			//CreateMap<CreateBookModel, Book>();
			//CreateMap<Book, BookViewModel>().ForMember( dest => dest.Genre, opt => opt.MapFrom( src => src.Genre.Name ) );

			CreateMap<Kullanýcý, KullanýcýModel>()	;
			CreateMap<Film, FilmModel>()      		;
			CreateMap<Müþteri, MüþteriModel>()		;
			CreateMap<Oyuncu, OyuncuModel>()  		;
			CreateMap<Yönetmen, OyuncuModel>()		;
			CreateMap<Sipariþ, SipariþModel>()		;
			// CreateMap<Book, Book>()        		;



			}
		}
	}