using Conservices.Butler.Interfaces.Repositories;
using Conservices.Butler.Interfaces.Services;
using Conservices.Butler.Services.Core;

namespace Conservices.Butler.Services.Endpoints;

public class KeyedRawProgramService(IProgramRepository programRepository) : AbstractKeyedConService<string>, IRawProgramService
{
	protected override TimeSpan RefreshInterval => TimeSpan.FromMinutes(5);

	protected override async Task<string?> TryLoadValueForConventionAsync(string eventId)
		=> await programRepository.GetProgramRaw(eventId);

	public async Task<string?> GetAllAsync(string eventId)
	{
		await RefreshIfNeededAsync(eventId);

		if (Items.TryGetValue(eventId, out var games))
			return games.Value;

		return null;
	}
}