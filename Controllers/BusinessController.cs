using EcoMeal.Database.Entities;
using EcoMeal.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EcoMeal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusinessController(IBusinessService businessService): ControllerBase
{
    [HttpGet] 
    public async Task<ActionResult<List<Business>>> GetAll()
    {
        return await businessService.GetAll();
    }

    [HttpGet("{id:guid}")] 
    public async Task<ActionResult<Business?>> GetById(Guid id)
    {
        var business = await businessService.GetByIdAsync(id);
        if (business is null)
            return NotFound();

        return business;
    }

    [HttpPost]
    [Authorize(Roles = "BusinessManager, Admin")]
    public async Task<ActionResult> AddAsync(Business business)
    {
        await businessService.AddAsync(business);
        return Created();
    }

    [HttpPut]
    [Authorize(Roles = "BusinessManager, Admin")]
    public async Task<ActionResult> UpdateAsync(Business business)
    {
        await businessService.UpdateAsync(business);
        return NoContent();
    }

    [HttpDelete("{id:guid}")] 
    [Authorize(Roles = "BusinessManager, Admin")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await businessService.DeleteAsync(id);
        return NoContent();
    }
}
