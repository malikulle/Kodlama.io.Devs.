using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguage.Rules
{
    public class ProgrammingLanguageBusinessRules
    {

        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task CheckProgrammingLanguageExist(string name)
        {
            var result = await _programmingLanguageRepository.Query().AnyAsync(x => x.Name == name);
            if (result)
                throw new BusinessException("LanguageNameExist");
        }
        
        public async Task CheckProgrammingLanguageExist(int id)
        {
            var result = await _programmingLanguageRepository.Query().AnyAsync(x => x.Id == id);
            if (!result)
                throw new BusinessException("LanguageDoesntExist");
        }
    }
}
