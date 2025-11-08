namespace Conservices.Butler.Interfaces.Services;

public interface IRawProgramService
{
	public Task<string?> GetAllAsync(string eventId);
}