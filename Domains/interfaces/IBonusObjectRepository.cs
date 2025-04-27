namespace StarColonies.Domains.interfaces;

public interface IBonusObjectRepository
{
    Task <List<BonusObject>> GetAllBonusObjectsAsync();
    Task <BonusObject?> GetBonusObjectByIdAsync(string objectId);
    Task AddBonusObjectAsync(BonusObject bonusObject);
    void UpdateBonusObjectAsync(BonusObject bonusObject);
    void DeleteBonusObject(string objectId);
}