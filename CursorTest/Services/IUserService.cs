namespace CursorTest.Services;

public interface IUserService
{
    IEnumerable<UserDto> GetAll();
    UserDto? GetById(int id);
    UserDto Create(string name);
    bool Update(int id, string name);
    bool Delete(int id);
}

