using Microsoft.AspNetCore.Mvc;

namespace MoneyManagerWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{
    public AccountsController(ILogger)
    {
        
    }
}
