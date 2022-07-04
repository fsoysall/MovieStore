
using AutoMapper;

using MovieStore.App.Aksiyonlar.Al��Veri�ler;
using MovieStore.App.Aksiyonlar.Filmler;
using MovieStore.App.Aksiyonlar.Kullan�c�lar;
using MovieStore.App.Aksiyonlar.M��teriler;
using MovieStore.App.Aksiyonlar.Oyuncular;
using MovieStore.Data;

namespace MovieStore.Common {

	public class MappingProfile : Profile {

		public MappingProfile() {

			//CreateMap<CreateBookModel, Book>();
			//CreateMap<Book, BookViewModel>().ForMember( dest => dest.Genre, opt => opt.MapFrom( src => src.Genre.Name ) );

			CreateMap<Kullan�c�, Kullan�c�Model>()	;
			CreateMap<Film, FilmModel>()      		;
			CreateMap<M��teri, M��teriModel>()		;
			CreateMap<Oyuncu, OyuncuModel>()  		;
			CreateMap<Y�netmen, OyuncuModel>()		;
			CreateMap<Sipari�, Sipari�Model>()		;
			// CreateMap<Book, Book>()        		;



			}
		}
	}