namespace StarColonies.Domains.interfaces;

public interface ICurrentUserService
{
    bool IsConnected { get; }
    bool IsAdmin { get; }
}