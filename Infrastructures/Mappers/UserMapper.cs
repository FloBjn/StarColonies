using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public static class UserMapper
{
    public static User ToDomain(StarColoniesUser entity) => new User
    {
        Avatar = entity.Avatar,
        BirthDate = entity.BirthDate,
        UserColon = ColonMapper.ToDomain(entity.UserColon),
        ColonId = entity.ColonId,
        Name = entity.UserName,
        Id = entity.Id,
        Email = entity.Email,
    };

    public static StarColoniesUser ToEntity(User user) => new StarColoniesUser
    {
        Avatar = user.Avatar,
        BirthDate = user.BirthDate,
        UserColon = ColonMapper.ToEntity(user.UserColon),
        ColonId = user.ColonId,
        UserName = user.Name,
        Id = user.Id,
        Email = user.Email,
    };
}