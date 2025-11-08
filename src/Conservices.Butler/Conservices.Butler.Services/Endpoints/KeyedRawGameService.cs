using Conservices.Butler.Interfaces.Repositories;
using Conservices.Butler.Interfaces.Services;
using Conservices.Butler.Services.Core;

namespace Conservices.Butler.Services.Endpoints;

public class KeyedRawGameService(IGameRepository gameRepository) : AbstractKeyedConService<string>, IRawGameService
{
	protected override TimeSpan RefreshInterval => TimeSpan.FromSeconds(30);

	protected override async Task<string?> TryLoadValueForConventionAsync(string eventId)
		=> await gameRepository.GetGamesRaw(eventId);

	public async Task<string?> GetAllAsync(string eventId)
	{
		await RefreshIfNeededAsync(eventId);

		if (Items.TryGetValue(eventId, out var games))
			return games.Value;

		return null;
	}
}