using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Jiraiya.Dtos;
using Jiraiya.Models;

namespace Jiraiya.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Project, ProjectDto>();
            Mapper.CreateMap<Sprint, SprintDto>();
            Mapper.CreateMap<Issue, IssueDto>();

            //Dto to Domain
            Mapper.CreateMap<ProjectDto, Project>().ForMember(p => p.Id, opt => opt.Ignore());
            Mapper.CreateMap<SprintDto, Sprint>().ForMember(s => s.Id, opt => opt.Ignore());
            Mapper.CreateMap<IssueDto, Issue>().ForMember(i => i.Id, opt => opt.Ignore());

        }

    }
}