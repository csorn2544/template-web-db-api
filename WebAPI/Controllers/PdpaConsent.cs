using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("[controller]")]
[ApiController]
public class PdpaConsentController : ControllerBase
{
    private readonly _dbContext _db;

    public PdpaConsentController(_dbContext db)
    {
        _db = db;
    }

    [HttpGet("pdpa-consent-get", Name = "GetAllPdpaConsent")]
    public async Task<IResult> GetAllPdpaConsent()
    {
        return TypedResults.Ok(await _db.PdpaConsents.ToArrayAsync());
    }

    [HttpGet("pdpa-consent-isdelete", Name = "GetDeletedPdpaConsent")]
    public async Task<IResult> GetDeletedPdpaConsent()
    {
        return TypedResults.Ok(await _db.PdpaConsents.Where(t => t.IsDeleted).ToListAsync());
    }

    [HttpGet("pdpa-consent-get-by-id/{id}", Name = "GetPdpaConsentById")]
    public async Task<IResult> GetPdpaConsentById(int id)
    {
        return await _db.PdpaConsents.FindAsync(id)
            is PdpaConsent pdpaConsent
                ? TypedResults.Ok(new PdpaConsentDTO(pdpaConsent))
                : TypedResults.NotFound();
    }

    [HttpPost("pdpa-consent-create", Name = "CreatePdpaConsent")]
    public async Task<IResult> CreatePdpaConsent(PdpaConsentDTO pdpaConsentDTO)
    {
        var pdpaConsentItem = new PdpaConsent
        {
            Name = pdpaConsentDTO.Name,
            Version = pdpaConsentDTO.Version,
            TitleTh = pdpaConsentDTO.TitleTh,
            TitleEn = pdpaConsentDTO.TitleEn,
            TitleZh = pdpaConsentDTO.TitleZh,
            DescriptionTh = pdpaConsentDTO.DescriptionTh,
            DescriptionEn = pdpaConsentDTO.DescriptionEn,
            DescriptionZh = pdpaConsentDTO.DescriptionZh,
            Date = pdpaConsentDTO.Date,
        };
        _db.PdpaConsents.Add(pdpaConsentItem);
        await _db.SaveChangesAsync();

        return TypedResults.Created($"/pdpa-consent-create/{pdpaConsentItem.userId}", pdpaConsentDTO);
    }

    [HttpPut("pdpa-consent-update/{id}", Name = "UpdatePdpaConsent")]
    public async Task<IResult> UpdatePdpaConsent(int id, PdpaConsentDTO pdpaConsentDTO)
    {
        var pdpaConsent = await _db.PdpaConsents.FindAsync(id);

        if (pdpaConsent is null) return TypedResults.NotFound();

        pdpaConsent.Name = pdpaConsentDTO.Name;
        pdpaConsent.Version = pdpaConsentDTO.Version;
        pdpaConsent.TitleTh = pdpaConsentDTO.TitleTh;
        pdpaConsent.TitleEn = pdpaConsentDTO.TitleEn;
        pdpaConsent.TitleZh = pdpaConsentDTO.TitleZh;
        pdpaConsent.DescriptionTh = pdpaConsentDTO.DescriptionTh;
        pdpaConsent.DescriptionEn = pdpaConsentDTO.DescriptionEn;
        pdpaConsent.DescriptionZh = pdpaConsentDTO.DescriptionZh;
        pdpaConsent.Date = DateTime.UtcNow;

        await _db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    [HttpDelete("pdpa-consent-delete/{id}", Name = "DeletePdpaConsent")]
    public async Task<IResult> DeletePdpaConsent(int id)
    {
        if (await _db.PdpaConsents.FindAsync(id) is PdpaConsent pdpaConsent)
        {
            _db.PdpaConsents.Remove(pdpaConsent);
            await _db.SaveChangesAsync();
            return TypedResults.NoContent();
        }

        return TypedResults.NotFound();
    }
}
