#region

using AutoMapper;
using GitScraping.Application.Filters;
using GitScraping.Application.Queries;

#endregion

namespace GitScraping.Application.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}