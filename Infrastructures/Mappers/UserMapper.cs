using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public static class UserMapper
{
    public static User ToDomain(StarColoniesUser entity) => new User
    {
        UserId = entity.UserId,
        Avatar = entity.Avatar,
        BirthDate = entity.BirthDate,
        UserColon = ColonMapper.ToDomain(entity.UserColon)
    };

    public static StarColoniesUser ToEntity(User user) => new StarColoniesUser
    {
        UserId = user.UserId,
        Avatar = user.Avatar,
        BirthDate = user.BirthDate,
        UserColon = ColonMapper.ToEntity(user.UserColon)
    };
}