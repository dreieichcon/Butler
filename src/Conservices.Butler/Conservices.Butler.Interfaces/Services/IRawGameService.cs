namespace Conservices.Butler.Interfaces.Services;

public interface IRawGameService
{
	public Task<string?> GetAllAsync(string eventId);
}