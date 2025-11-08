using Conservices.Butler.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Conservices.Butler.Controllers.Api;

[Route("api/v1/{eventId}/[controller]")]
public class GameController(IRawGameService rawGameService) : ControllerBase
{

	[HttpGet]
	[Route("")]
	public async Task<ActionResult> Get(string eventId)
	{
		var gameResult = await rawGameService.GetAllAsync(eventId);

		if (gameResult is null)
			return NotFound();
		
		return Content(gameResult, "application/json");
	}
	
}