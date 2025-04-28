using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Infrastructures.data;
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

    
    public static StarColoniesUser ToEntity(User user, StarColoniesContext context)
    {
        var colonEntity = ColonMapper.ToEntity(user.UserColon, context);

        var trackedColon = context.ChangeTracker
            .Entries<StarColoniesColon>()
            .FirstOrDefault(e => e.Entity.ColonId == colonEntity.ColonId)
            ?.Entity;

        return new StarColoniesUser
        {
            Id = user.Id,
            Avatar = user.Avatar,
            BirthDate = user.BirthDate,
            IsAdmin = user.IsAdmin,
            UserName = user.Name,
            Email = user.Email,
            
            ColonId = user.UserColon.ColonId,
            UserColon = trackedColon ?? colonEntity
        };
    }
}