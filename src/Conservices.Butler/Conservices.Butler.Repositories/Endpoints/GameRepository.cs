using Conservices.Butler.Interfaces.Repositories;
using Conservices.Butler.Repositories.Core;

namespace Conservices.Butler.Repositories.Endpoints;

public class GameRepository : AbstractConservicesRepository, IGameRepository
{ 
	public async Task<string?> GetGamesRaw(string eventId)
	{
		var uri = new ConservicesRequestUri().WithSegments("event", eventId, "game");
		var request = await GetAsync(uri);

		if (!request.IsSuccess || string.IsNullOrEmpty(request.ResponseBody))
			return null;

		return request.ResponseBody;
	}
}