using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Models;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            this.CreateMap<ProgrammingLanguage, CreateProgrammingLanguageDto>().ReverseMap();
            this.CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

            this.CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            this.CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

            this.CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();

            this.CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
            this.CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageDto>().ReverseMap();
        }
    }
}
