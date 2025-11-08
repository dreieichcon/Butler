using Conservices.Butler.Models;

namespace Conservices.Butler.Services.Core;

public abstract class AbstractKeyedConService<T>
{
	protected Dictionary<string, ConventionKeyedModel<T>> Items = [];

	protected abstract TimeSpan RefreshInterval { get; }

	protected abstract Task<T?> TryLoadValueForConventionAsync(string eventId);

	protected async Task RefreshIfNeededAsync(string eventId)
	{
		var exists = Items.TryGetValue(eventId, out var model);

		if (exists && !model!.NeedsUpdate(RefreshInterval))
			return;
		
		var loadResult = await TryLoadValueForConventionAsync(eventId);

		if (loadResult is null)
			return;

		if (!exists)
			Items[eventId] = new ConventionKeyedModel<T>(loadResult);

		else
		{
			model!.Value = loadResult;
			model.LastUpdated = DateTime.UtcNow;
		}
	}
}