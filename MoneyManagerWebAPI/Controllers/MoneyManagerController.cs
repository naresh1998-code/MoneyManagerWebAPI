using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MoneyManagerWebAPI.Data;
using MoneyManagerWebAPI.Models;
using System.Collections;

namespace MoneyManagerWebAPI.Controllers;

[Authorize]  //TODO un-comment this line on deployment
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

    [AllowAnonymous]
    [HttpGet]
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



    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>?>> GetAccount()
    {
        var CacheKey = "accounts";

        if (!_cache.TryGetValue(CacheKey, out List<Account>? accounts))
        {
            accounts = await _context.Accounts.Where<Account>(e => e.UserName == User.Identity!.Name).ToListAsync();
            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(5));
            _cache.Set(CacheKey, accounts, cacheOptions);

        }

        return accounts; // = await _context.Accounts.Where<Account>(e => e.UserName == User.Identity!.Name).ToListAsync();

    }


    [HttpPost]
    public async void AddAccount(NewAccount newAccount)
    {
        Account account = new()
        {
            AccountName = newAccount.AccountName,
            AccountType = newAccount.AccountType,
            Balance = newAccount.Balance,
            BankName = newAccount.BankName,
            UserName = User.Identity!.Name!,
            Remark = newAccount.Remark
        };

        //newAccount.AccountId = _context.Accounts.Select(e => e.AccountId).Max()+1;
        await _context.Accounts.AddAsync(account);
        _context.SaveChanges();
    }



    [HttpPatch]
    public void UpdateAccount(NewAccount account)
    {
        var toBeUpdatedAccount = _context.Accounts
            .FirstOrDefault(at => at.AccountId == account.AccountId && at.UserName == User.Identity!.Name);

        if (toBeUpdatedAccount != null)
        {
            toBeUpdatedAccount.AccountName = account.AccountName;
            toBeUpdatedAccount.AccountType = account.AccountType;
            toBeUpdatedAccount.Balance = account.Balance;
            toBeUpdatedAccount.BankName = account.BankName;
            toBeUpdatedAccount.Remark = account.Remark;

            _context.SaveChanges();
        }
    }



    [HttpPost]
    public void DeleteAccount(int accountID)
    {
        var accountToBeDeleted = _context.Accounts.FirstOrDefault(at => at.AccountId == accountID && at.UserName == User.Identity!.Name);

        if (accountToBeDeleted != null)
        {
            _context.Accounts.Remove(accountToBeDeleted);
            _context.SaveChanges();
        }
    }



    [HttpGet]
    public async Task<List<Transaction>> GetTransactions(int page = 1, int pageSize = 10)
    {
        var transactions = await _context.Transactions.Where(at => at.UserName == User.Identity!.Name).OrderByDescending(at => at.TransactionTime).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return transactions;
    }

    [HttpGet]
    public async void AddTransaction(NewTransaction newTransaction)
    {
        Transaction transaction = new()
        {
            AccountId = newTransaction.AccountId,
            UserName = User.Identity!.Name!,
            Category = newTransaction.Category,
            Remark = newTransaction.Remark,
            TransactionAmount = newTransaction.TransactionAmount,
            TransactionTime = newTransaction.TransactionTime
        };
        await _context.Transactions.AddAsync(transaction);
        _context.SaveChanges();
    }

    [HttpGet]
    public void UpdateTransaction(int transactionID, NewTransaction newTransaction)
    {
        var transactionToBeUpdated = _context.Transactions.FirstOrDefault(at =>
            at.UserName == User.Identity!.Name && at.TransactionId == transactionID);
        if (transactionToBeUpdated != null)
        {
            transactionToBeUpdated.TransactionAmount = newTransaction.TransactionAmount;
            transactionToBeUpdated.Remark = newTransaction.Remark;
            transactionToBeUpdated.Category = newTransaction.Category;

            _context.SaveChanges();
        }
    }

    [HttpGet]
    public void DeleteTransaction(int transactionID)
    {
        var transactionToBeDeleted = _context.Transactions.FirstOrDefault(at =>
            at.UserName == User.Identity!.Name && at.TransactionId == transactionID);

        if (transactionToBeDeleted != null)
        {
            _context.Transactions.Remove(transactionToBeDeleted);
            _context.SaveChanges();
        }
    }


}
