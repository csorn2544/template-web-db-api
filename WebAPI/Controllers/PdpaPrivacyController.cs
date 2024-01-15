using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("[controller]")]
[ApiController]

public class PdpaPrivacyController : ControllerBase
{
  private readonly _dbContext _db;

  public PdpaPrivacyController (_dbContext db)
  { 
    _db = db;
  }

  [HttpGet("pdpa-privacy-get", Name = "GetAllPdpaPrivacy")]
  public async Task<IResult> GetAllPdpaPrivacy()
  {
    return TypedResults.Ok(await _db.PdpaPrivacies.ToArrayAsync());
  }

  [HttpGet("pdpa-privacy-get-id/{id}", Name = "PdpaPrivacyGetById")]
  public async Task<IResult> PdpaPrivacyGetById(int id)
  {
    return await _db.PdpaPrivacies.FindAsync(id)
            is PdpaPrivacy pdpaPrivacy
            ? TypedResults.Ok(pdpaPrivacy)
                : TypedResults.NotFound();
  }

  [HttpPost("pdpa-privacy-create", Name = "CreatePdpaPrivacy")]
  public async Task<IResult> CreatePdpaPrivacy(PdpaPrivacy pdpaPrivacy)
  {

    _db.PdpaPrivacies.Add(pdpaPrivacy);
    await _db.SaveChangesAsync();

    return TypedResults.Created($"/pdpa-privacy-create/{pdpaPrivacy}", pdpaPrivacy);
  }




 /* [HttpGet("pdpa-privacy-isdelete", Name = "GetDeletedPdpaPrivacy")]
  public async Task<IResult> GetDeletedPdpaPrivacy()
  {
    return TypedResults.Ok(await _db.PdpaPrivacies.Where(t => t.IsDeleted).ToListAsync());
  }

  [HttpDelete("pdpa-privacy-delete/{id}", Name = "DeletePdpaPrivacy")]
  public async Task<IResult> DeletePdpaPrivacy(int id)
  {
    if (await _db.PdpaPrivacies.FindAsync(id) is PdpaPrivacy pdpaPrivacy)
    {
      _db.PdpaPrivacies.Remove(pdpaPrivacy);
      await _db.SaveChangesAsync();
      return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
  }*/

}
 
