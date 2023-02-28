using EntityFrameworkTest.Models;

namespace EntityFrameworkTest.Services;

public class UsersService
{
    private readonly ApplicationDbContext _dbContext;

    public UsersService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<User> GetUsers()
    {
        var users = _dbContext.Users.ToList();
        return users;
    }

    public User UpdateUser(User user)
    {
        var userToUpdate = _dbContext.Users.SingleOrDefault(u => u.UserId == user.UserId) ??
                           throw new InvalidOperationException("Could not find the user.");
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        _dbContext.SaveChanges();

        return userToUpdate ?? throw new InvalidOperationException("Could not find the user you were looking for.");
    }
}