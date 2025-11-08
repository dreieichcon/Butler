using System.Collections;

namespace Conservices.Butler.Models;

public class ConventionKeyedModel<T>(T value)
{
	public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

	public T Value { get; set; } = value;
	
	public bool NeedsUpdate(TimeSpan refreshInterval)
		=> IsValueEmpty() || DateTime.UtcNow - LastUpdated > refreshInterval;

	private bool IsValueEmpty()
	{
		return Value switch
		{
			IList enumerable => enumerable.Count == 0,
			string stringValue => string.IsNullOrEmpty(stringValue),
			var _ => Value == null,
		};
	}
}