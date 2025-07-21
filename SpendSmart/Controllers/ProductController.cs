using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpendSmart.Data;
using SpendSmart.Models;

namespace SpendSmart.Controllers;

public class ProductController(ProductDbContext db) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetTotalValue()
    {
        var totalValue = await db.Products.SumAsync(p => p.Value);
        return Ok(new { totalValue });
    }
    
    [HttpGet]
    public async Task<IActionResult> Products()
    {
        // Read-only, use AsNoTracking to speed up
        // remove tracking from returned entities
        // recommended for read operation
        var products = await db.Products.AsNoTracking()
            .Include(p => p.ProductType) // include the related ProductType
            .Include(s => s.SubType)
            .ToListAsync();

        // Compute sum directly in DB for performance
        // was doing sum on List, now comes straight from db
        var totalProductsValue = await db.Products.SumAsync(p => p.Value);

        ViewBag.Products = totalProductsValue;
        return View(products);
    }


    [HttpGet]
    public async Task<IActionResult> CreateEditProduct(int? id)
    {
        ViewBag.ProductTypes = await db.ProductTypes
            .Select(pt => new SelectListItem
            {
                Value = pt.Id.ToString(),
                Text = pt.ProductTypeName
            }).ToListAsync();

        if (id != null)
        {
            var product = await db.Products
                .AsNoTracking()
                // .Include(p => p.ProductType)
                .Include(p => p.SubType)
                .SingleOrDefaultAsync(p => p.Id == id);

            return View(product);
        }

        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await db.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound($"No product found with ID {id}");
        }

        db.Products.Remove(product);
        await db.SaveChangesAsync();
        return Ok($"Deleted product with ID {id}");
    }


    [HttpPost]
    public async Task<IActionResult> CreateEditProductForm(Product model)
    {
        if (string.IsNullOrWhiteSpace(model.Name) || model.ProductTypeId == 0 || model.SubTypeId == 0)
        {
            return BadRequest("Missing required fields.");
        }

        if (model.Id == 0)
        {
            await db.Products.AddAsync(model);
        }
        else
        {
            var existingProduct = await db.Products.FindAsync(model.Id);
            if (existingProduct == null) return NotFound();
            db.Entry(existingProduct).CurrentValues.SetValues(model);
        }

        await db.SaveChangesAsync();
        return Ok();
    }


}