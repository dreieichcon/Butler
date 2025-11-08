using Microsoft.AspNetCore.Mvc;

namespace Conservices.Butler.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController : ControllerBase
{
	[HttpGet]
	[Route("")]
	public ActionResult Status()
	{
		return Ok();
	}
}