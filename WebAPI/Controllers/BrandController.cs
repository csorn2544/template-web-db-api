using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("[controller]")]
[ApiController]

public class BrandController : ControllerBase
{
    private readonly _dbContext _db;

    public BrandController(_dbContext db)
    {
        _db = db;
    }

    [HttpGet("brand-get", Name = "GetAllBrand")]
    public async Task<IResult> GetAllBrand()
    {
        return TypedResults.Ok(await _db.Brands.ToArrayAsync());
    }

    [HttpGet("brand-get-id/{id}", Name = "brandGetById")]
    public async Task<IResult> BrandGetById(int id)
    {
        return await _db.Brands.FindAsync(id)
                is Brand brand
                ? TypedResults.Ok(brand)
                    : TypedResults.NotFound();
    }

    [HttpPost("brand-create", Name = "CreateBrand")]
    public async Task<IResult> CreateBrand(Brand brand)
    {

        _db.Brands.Add(brand);
        await _db.SaveChangesAsync();

        return TypedResults.Created($"/brand-create/{brand}", brand);
    }
}