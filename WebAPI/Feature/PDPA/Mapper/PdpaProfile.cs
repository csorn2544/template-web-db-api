using AutoMapper;
using WebAPI.Feature.PDPA.Commands;
using WebAPI.Feature.PDPA.DTO;

namespace WebAPI.Feature.PDPA.Mapper
{
    public class PdpaProfile : Profile
    {
        public PdpaProfile()
        {
            // Mapping from PdpaConsentCreate to Models.PDPA.PdpaConsent
            CreateMap<PdpaConsentCreate, Models.PDPA.PdpaConsent>();

            // Mapping from Models.PDPA.PdpaConsent to PdpaConsentDto
            CreateMap<Models.PDPA.PdpaConsent, PdpaConsentDto>();
        }
    }
}
