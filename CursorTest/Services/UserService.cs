using CursorTest.Repositories;

namespace CursorTest.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<UserDto> GetAll() => _repo.GetAll();

    public UserDto? GetById(int id) => _repo.GetById(id);

    public UserDto Create(string name) => _repo.Create(name);

    public bool Update(int id, string name) => _repo.Update(id, name);

    public bool Delete(int id) => _repo.Delete(id);
}

