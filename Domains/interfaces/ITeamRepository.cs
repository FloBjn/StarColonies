namespace StarColonies.Domains.interfaces;

public interface ITeamRepository
{
    Task<List<Team>> GetAllTeamsAsync();
    Task<Team?> GetByIdAsync(string teamId);
    Task AddTeamAsync(Team team);
    Task UpdateTeamNameAsync(Team team);
    Task UpdateTeamMaxLvlMissionAsync(Team team);
    Task UpdateTeamMembersAsync(Team team);

    Task DeleteTeamAsync(Team team);
}