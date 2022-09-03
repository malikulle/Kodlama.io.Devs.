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

namespace Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingLanguageHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {

            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly ProgrammingLanguageBusinessRules _rules;

            public UpdateProgrammingLanguageHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules rules)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
                _rules = rules;
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _rules.CheckProgrammingLanguageExist(request.Id);
                var programmingLanguage = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
                await _rules.CheckProgrammingLanguageExist(programmingLanguage.Name);
                var result = await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
                var programmingLanguageDto = _mapper.Map<UpdateProgrammingLanguageDto>(result);
                return programmingLanguageDto;
            }
        }
    }
}
