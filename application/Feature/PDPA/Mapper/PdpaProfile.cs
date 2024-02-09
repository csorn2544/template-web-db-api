using AutoMapper;
using application.Feature.PDPA.Commands;
using domain.Entities.PDPA;
using application.Feature.PDPA.DTO;

namespace application.Feature.PDPA.Mapper
{
    public class PdpaProfile : Profile
    {
        public PdpaProfile()
        {
            // Mapping from PdpaConsentCreate to Models.PDPA.PdpaConsent
            CreateMap<PdpaConsentCreate, PdpaConsent>();

            // Mapping from Models.PDPA.PdpaConsent to PdpaConsentDto
            CreateMap<PdpaConsent, PdpaConsentDto>();

            // Mapping from PdpaPrivacyCreate to Models.PDPA.PdpaPrivacy
            CreateMap<PdpaPrivacyCreate, PdpaPrivacy>();

            // Mapping from Model.PDPA.Pdpaprivacy to PdpaPrivacy
            CreateMap<PdpaPrivacy, PdpaPrivacyDTO>();
        }
    }
}
