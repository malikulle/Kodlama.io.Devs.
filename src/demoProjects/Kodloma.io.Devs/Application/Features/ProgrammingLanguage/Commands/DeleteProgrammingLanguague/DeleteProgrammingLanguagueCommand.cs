using Application.Features.ProgrammingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguage.Commands.DeleteProgrammingLanguague
{
    public class DeleteProgrammingLanguagueCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguagueHandler : IRequestHandler<DeleteProgrammingLanguagueCommand, bool>
        {

            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly ProgrammingLanguageBusinessRules _rules;

            public DeleteProgrammingLanguagueHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageBusinessRules rules)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
                _rules = rules;
            }

            public async Task<bool> Handle(DeleteProgrammingLanguagueCommand request, CancellationToken cancellationToken)
            {
                await _rules.CheckProgrammingLanguageExist(request.Id);

                var entity = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);
                await _programmingLanguageRepository.DeleteAsync(entity);
                return true;
            }
        }
    }
}
