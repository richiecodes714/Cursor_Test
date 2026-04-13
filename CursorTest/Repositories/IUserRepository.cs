namespace CursorTest.Repositories;

public interface IUserRepository
{
    IEnumerable<UserDto> GetAll();
    UserDto? GetById(int id);
    UserDto Create(string name);
    bool Update(int id, string name);
    bool Delete(int id);
}

