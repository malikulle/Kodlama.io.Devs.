using Application.Features.ProgrammingLanguage.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguage.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
    {

        public PageRequest Page { get; set; }

        public class GetListProgrammingLanguageHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
        {

            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

            public GetListProgrammingLanguageHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {

                var list = await _programmingLanguageRepository.GetListAsync(index: request.Page.Page, size: request.Page.PageSize, cancellationToken: cancellationToken);
                var mappedListModel = _mapper.Map<ProgrammingLanguageListModel>(list);
                return mappedListModel;
            }
        }
    }
}
