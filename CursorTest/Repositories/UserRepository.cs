using System.Collections.Concurrent;
using System.Threading;

namespace CursorTest.Repositories;

public sealed class UserRepository : IUserRepository
{
    private static int _nextId = 0;
    private static readonly ConcurrentDictionary<int, UserDto> Users = new();

    public IEnumerable<UserDto> GetAll()
    {
        return Users.Values.OrderBy(u => u.Id);
    }

    public UserDto? GetById(int id)
    {
        return Users.TryGetValue(id, out var user) ? user : null;
    }

    public UserDto Create(string name)
    {
        var id = Interlocked.Increment(ref _nextId);
        var user = new UserDto { Id = id, Name = name };
        Users.TryAdd(id, user);
        return user;
    }

    public bool Update(int id, string name)
    {
        while (true)
        {
            if (!Users.TryGetValue(id, out var existing))
            {
                return false;
            }

            var updated = new UserDto { Id = existing.Id, Name = name };
            if (Users.TryUpdate(id, updated, existing))
            {
                return true;
            }
        }
    }

    public bool Delete(int id)
    {
        return Users.TryRemove(id, out _);
    }
}

