using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SimpleCleanArch.Application.Common.Interfaces;
using SimpleCleanArch.Application.Common.Mappings;
using SimpleCleanArch.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCleanArch.Application.WeatherForecasts.Queries
{

    public class GetWeatherForecastWithPaginationQuery
        : IRequest<PaginatedList<WeatherForecastModel>>
    {
        //public int ListId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetWeatherForecastWithPaginationQueryHandler
        : IRequestHandler<GetWeatherForecastWithPaginationQuery, PaginatedList<WeatherForecastModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetWeatherForecastWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<WeatherForecastModel>> Handle(GetWeatherForecastWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.WeatherForecasts
             .OrderBy(x => x.Id)
             .ProjectTo<WeatherForecastModel>(_mapper.ConfigurationProvider)
             .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
