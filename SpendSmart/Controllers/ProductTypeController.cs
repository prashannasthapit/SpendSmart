using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendSmart.Data;
using SpendSmart.Models;

namespace SpendSmart.Controllers;

public class ProductTypeController(ProductDbContext db) : Controller
{
    public async Task<List<ProductType>> ProductTypes()
    {
        var productTypes = await db.ProductTypes.AsNoTracking().ToListAsync();
        return productTypes;
    }

    [HttpGet]
    public IActionResult GetSubTypes(int typeId)
    {
        var subTypes = db.SubTypes
            .Where(st => st.ProductTypeId == typeId)
            .Select(st => new
            {
                id = st.Id,
                name = st.SubTypeName
            })
            .ToList();

        return Ok(subTypes);
    }
}