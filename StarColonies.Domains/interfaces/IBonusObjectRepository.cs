namespace StarColonies.Domains.interfaces;

public interface IBonusObjectRepository
{
    Task <List<BonusObject>> GetAllBonusObjectsAsync();
    Task <BonusObject?> GetBonusObjectByIdAsync(string objectId);
    Task AddBonusObjectAsync(BonusObject bonusObject);
    Task UpdateBonusObjectNameAsync(BonusObject bonusObject);
    Task UpdateBonusObjectPriceAsync(BonusObject bonusObject);
    Task UpdateBonusObjectPerfBonusAsync(BonusObject bonusObject);
    Task DeleteBonusObject(BonusObject bonusObject);
}