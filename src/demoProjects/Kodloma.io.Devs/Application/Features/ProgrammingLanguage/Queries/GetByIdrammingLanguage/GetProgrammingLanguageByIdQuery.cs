using Application.Features.ProgrammingLanguage.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguage.Queries.GetByIdProgrammingLanguage
{
    public class GetProgrammingLanguageByIdQuery : IRequest<ProgrammingLanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetProgrammingLanguageByIdHandler : IRequestHandler<GetProgrammingLanguageByIdQuery, ProgrammingLanguageGetByIdDto>
        {

            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

            public GetProgrammingLanguageByIdHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<ProgrammingLanguageGetByIdDto> Handle(GetProgrammingLanguageByIdQuery request, CancellationToken cancellationToken)
            {
                var programmingLanugage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);
                var mappedProrammingLanguage = _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanugage);
                return mappedProrammingLanguage;
            }
        }
    }
}
