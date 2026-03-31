using AutoMapper;
using LoanManagementWebAPI.Models;
using LoanManagementWebAPI.DTO;
namespace LoanManagementWebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Loan, LoanReadDto>();
            CreateMap<LoanCreateDto, Loan>();
            CreateMap<LoanUpdateDto, Loan>();
        }
    }
}
