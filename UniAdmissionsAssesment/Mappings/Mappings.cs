using AutoMapper;
using UniAdmissionsAssesment.Entities.TransferDTOs;
using UniAdmissionsAssesment.Entities.ViewModels;

namespace UniAdmissionsAssesment.Entities.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<UpdateBookModel, Book>();
            CreateMap<Book, BookTransferDTO>();
        }
    }
}