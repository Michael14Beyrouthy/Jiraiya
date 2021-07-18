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
            Mapper.CreateMap<Project, ProjectDto>();
            Mapper.CreateMap<ProjectDto, Project>();
            Mapper.CreateMap<Issue, IssueDto>();
            Mapper.CreateMap<Sprint, SprintDto>();
        }        

    }
}