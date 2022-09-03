using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreateProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreateProgrammingLanguageDto>
        {

            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly ProgrammingLanguageBusinessRules _rules;

            public CreateProgrammingLanguageCommandHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules rules)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
                _rules = rules;
            }

            public async Task<CreateProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _rules.CheckProgrammingLanguageExist(request.Name);
                var mappedProgrammingLanguage = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
                var createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguage);
                var createdProgrammingLanguageDto = _mapper.Map<CreateProgrammingLanguageDto>(createdProgrammingLanguage);
                return createdProgrammingLanguageDto;
            }
        }
    }
}
