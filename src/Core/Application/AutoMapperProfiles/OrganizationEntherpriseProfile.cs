using Application.DTOs;
using Application.MediatR.UseCases;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Models;
using EnumsNET;

namespace Application.AutoMapperProfiles;

public class OrganizationEntherpriseProfile : Profile
{
    public OrganizationEntherpriseProfile()
    {
        CreateMap<OrganizationEntherprise, OrganizationEntherpriseDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(a => a.Id))
            .ForMember(dest => dest.ClassificationType, opt => opt.MapFrom(a => a.ClassificationType.AsString(EnumFormat.Description)))
            .ReverseMap();

        CreateMap<OrganizationEntherpriseDTO, OrganizationEntherpriseModel> ()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(a => a.Id.ToString()))
            .ForMember(dest => dest.ClassificationType, opt => opt.MapFrom(a => a.ClassificationType))
            .ReverseMap();      
        
        CreateMap<OrganizationEntherprise, OrganizationEntherpriseModel> ()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(a => a.Id.ToString()))
            .ForMember(dest => dest.ClassificationType, opt => opt.MapFrom(a => a.ClassificationType.AsString(EnumFormat.Description)))
            .ReverseMap();

        CreateMap<OrganizationEntherpriseContract, OrganizationEntherpriseOrchestratorCommand>()
            .ReverseMap();

        CreateMap<OrganizationEntherpriseOrchestratorCommand, OrganizationEntherprise>()
            .ReverseMap();

        CreateMap<OrganizationEntherpriseOrchestratorCommand, OrganizationEntherpriseModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(a => a.Id.ToString()))
            .ForMember(dest => dest.ClassificationType, opt => opt.MapFrom(a => a.ClassificationType.AsString(EnumFormat.Description)))
            .ReverseMap();

        CreateMap<OrganizationEntherpriseContract, OrganizationEntherprise>()
            .ReverseMap();
    }
}
