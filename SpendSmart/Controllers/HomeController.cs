using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;

namespace SpendSmart.Controllers;

public class HomeController(ILogger<HomeController> logger, SpendSmartDbContext db) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    private readonly SpendSmartDbContext _db = db;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Expenses()
    {
        var expenses = _db.Expenses.ToList();
        
        var totalExpenses = expenses.Sum(e => e.Value);
        
        ViewBag.Expenses = totalExpenses;
        
        return View(expenses);
    }

    public IActionResult CreateEditExpense(int? id)
    {
        if (id != null)
        {
            var expense = _db.Expenses.SingleOrDefault(ex => ex.Id == id);
            return View(expense);
        }

        return View();
    }

    public IActionResult DeleteExpense(int id)
    {
        var expense = _db.Expenses.SingleOrDefault(ex => ex.Id == id);
        _db.Expenses.Remove(expense!);
        _db.SaveChanges();
        return RedirectToAction("Expenses");
    }

    public IActionResult CreateEditExpenseForm(Expense model)
    {
        if (model.Id == 0)
        {
            _db.Expenses.Add(model);
        }
        else
        {
            _db.Expenses.Update(model);
        }

        _db.SaveChanges();
        return RedirectToAction("Expenses");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}