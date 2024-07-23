using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MoneyManagerWebAPI.Data;
using MoneyManagerWebAPI.Models;
using System.Collections;

namespace MoneyManagerWebAPI.Controllers;

//[Authorize]  //TODO un-comment this line on deployment
[ApiController]
[Route("[controller]/[action]")]
public class MoneyManagerController : ControllerBase
{

    // Logger
    //private readonly ILogger<MoneyManagerController> _logger;

    //public MoneyManagerController(ILogger<MoneyManagerController> logger)
    //{
    //    _logger = logger;
    //}

    private readonly U483397598MauiMoneyContext _context;
    private readonly IMemoryCache _cache;

    public MoneyManagerController(U483397598MauiMoneyContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<AccountType>?>> GetAccountTypes()
    {
        var CacheKey = "accountType";
        if (!_cache.TryGetValue(CacheKey, out List<AccountType>? accountTypes))
        {
            accountTypes = await _context.AccountTypes.ToListAsync();
            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));
            _cache.Set(CacheKey, accountTypes, cacheOptions);

        }
        return accountTypes;
    }
}
