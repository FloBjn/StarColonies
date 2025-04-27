using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class BonusObjectMapper
{
    public static BonusObject ToDomain(StarColoniesBonusObject entity) => new BonusObject
    {
        BonusObjectId = entity.BonusObjectId,
        Name = entity.Name,
        Price = entity.Price,
        BonusLevel = entity.BonusLevel,
        BonusForce = entity.BonusForce,
        BonusStamina = entity.BonusStamina,

    };

    public static StarColoniesBonusObject ToEntity(BonusObject bonusObject) => new StarColoniesBonusObject
    {
        BonusObjectId = bonusObject.BonusObjectId,
        Name = bonusObject.Name,
        Price = bonusObject.Price,
        BonusLevel = bonusObject.BonusLevel,
        BonusForce = bonusObject.BonusForce,
        BonusStamina = bonusObject.BonusStamina,
    };
}