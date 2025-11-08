using System.Web.Helpers;
using Conservices.Butler.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Conservices.Butler.Controllers.Api;

[Route("api/v1/{eventId}/[controller]")]
public class ProgramController(IRawProgramService rawProgramService) : ControllerBase
{

	[HttpGet]
	[Route("")]
	public async Task<ActionResult> Get(string eventId)
	{
		var programResult = await rawProgramService.GetAllAsync(eventId);

		if (programResult is null)
			return NotFound();
		
		return Content(programResult, "application/json");
	}
	
}