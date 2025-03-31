using LMS.Infrastructure.Data;
using LMS.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Presentation.Controllers;

[Route("api/demoauth")]
[ApiController]
public class DemoAuthController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetDemoAuth()
    {
        return Ok(new DemoDto[] { new DemoDto { Id = 1, Name = "Kalle" },
                                  new DemoDto { Id = 2, Name = "Anka" },
                                  new DemoDto { Id = 3, Name = "Nisse" },
                                  new DemoDto { Id = 4, Name = "Pelle" }});
    }
}
