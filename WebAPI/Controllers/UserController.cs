using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly _dbContext _db;

    public UserController(_dbContext db)
    {
        _db = db;
    }

    [HttpGet("get-all-users", Name = "GetAllUsers")]
    public async Task<IResult> GetAllUsers()
    {
        return TypedResults.Ok(await _db.Users.ToArrayAsync());
    }

    [HttpGet("get-user-by-id/{id}", Name = "GetUserById")]
    public async Task<IResult> GetUserById(int id)
    {
        return await _db.Users.FindAsync(id)
            is User user
                ? TypedResults.Ok(user)
                : TypedResults.NotFound();
    }

    [HttpPost("create-user", Name = "CreateUser")]
    public async Task<IResult> CreateUser(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return TypedResults.Created($"/pdpaconsent/{user.userId}", user);
    }

    [HttpPut("update-user/{id}", Name = "UpdateUser")]
    public async Task<IResult> UpdateUser(int id, User inputUser)
    {
        var user = await _db.Users.FindAsync(id);

        if (user is null) return TypedResults.NotFound();
        user.userId = inputUser.userId;
        user.userName = inputUser.userName;

        await _db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    [HttpDelete("delete-user/{id}", Name = "DeleteUser")]
    public async Task<IResult> DeleteUser(int id)
    {
        if (await _db.Users.FindAsync(id) is User user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return TypedResults.NoContent();
        }

        return TypedResults.NotFound();
    }
}