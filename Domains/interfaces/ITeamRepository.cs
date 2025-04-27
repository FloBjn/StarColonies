namespace StarColonies.Domains.interfaces;

public interface ITeamRepository
{
    Task<List<Team>> GetAllTeamsAsync();
    Task<Team?> GetByIdAsync(string teamId);
    Task AddTeamAsync(Team team);
    void UpdateTeamAsync(Team team);
    void DeleteTeamAsync(Team team);
}