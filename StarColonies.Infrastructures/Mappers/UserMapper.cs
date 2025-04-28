using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public static class UserMapper
{
    public static User ToDomain(StarColoniesUser entity) => new User
    {
        Avatar = entity.Avatar,
        BirthDate = entity.BirthDate,
        IsAdmin = entity.IsAdmin,
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
        IsAdmin = user.IsAdmin,
        UserColon = ColonMapper.ToEntity(user.UserColon),
        ColonId = user.ColonId,
        UserName = user.Name,
        Id = user.Id,
        Email = user.Email,
    };
}