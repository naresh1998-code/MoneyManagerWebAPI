using Microsoft.AspNetCore.Mvc;

namespace MoneyManagerWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoneyManagerController : ControllerBase
{
    public MoneyManagerController(ILogger)
    {
        
    }
}
