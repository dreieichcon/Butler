namespace Conservices.Butler.Interfaces.Repositories;

public interface IGameRepository
{
	public Task<string?> GetGamesRaw(string eventId);
}