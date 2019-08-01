using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Domain to Api
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Contact, ContactResource>()
                .ForMember(cr => cr.Name, opt => opt.MapFrom(c => c.ContactName))
                .ForMember(cr => cr.Email, opt => opt.MapFrom(c => c.ContactEmail))
                .ForMember(cr => cr.Phone, opt => opt.MapFrom(c => c.ContactPhone));

            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId))); 


            // Api to Resource Domain
            CreateMap<ContactResource, Contact>()
                .ForMember(c => c.ContactName, opt => opt.MapFrom(cr => cr.Name))
                .ForMember(c => c.ContactEmail, opt => opt.MapFrom(cr => cr.Email))
                .ForMember(c => c.ContactPhone, opt => opt.MapFrom(cr => cr.Phone));
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature { FeatureId = id })));
        }
    }
}
