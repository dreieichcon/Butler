namespace Conservices.Butler.Interfaces.Repositories;

public interface IProgramRepository
{
	public Task<string?> GetProgramRaw(string eventId);
}