using Demolite.Http.Repository;

namespace Conservices.Butler.Repositories.Core;

public class AbstractConservicesRepository : AbstractHttpRepository
{
	public override void SetGetHeaders()
	{
		base.SetGetHeaders();
		Client.DefaultRequestHeaders.Add("accept", "application/json");
	}
}