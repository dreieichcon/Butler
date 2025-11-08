using Conservices.Butler.Interfaces.Repositories;
using Conservices.Butler.Repositories.Core;

namespace Conservices.Butler.Repositories.Endpoints;

public class ProgramRepository : AbstractConservicesRepository, IProgramRepository
{
	public async Task<string?> GetProgramRaw(string eventId)
	{
		var uri = new ConservicesRequestUri().WithSegments("event", eventId, "programm");
		var request = await GetAsync(uri);

		if (!request.IsSuccess || string.IsNullOrEmpty(request.ResponseBody))
			return null;

		return request.ResponseBody;
	}
}