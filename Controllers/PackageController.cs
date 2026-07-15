using EcoMeal.Database.Entities;
using EcoMeal.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoMeal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PackageController(IPackageService packageService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Package>>> GetAll()
    {
        var packages = await packageService.GetAllAsync();
        return Ok(packages);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Package>> GetById(Guid id)
    {
        var package = await packageService.GetByIdAsync(id);

        if (package is null)
            return NotFound();

        return Ok(package);
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(Package package)
    {
        await packageService.AddAsync(package);
        return CreatedAtAction(nameof(GetById), new { id = package.Id }, package);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateAsync(Guid id, Package package)
    {
        if (id != package.Id)
            return BadRequest("ID-ul din rută nu se potrivește cu ID-ul pachetului.");

        var existingPackage = await packageService.GetByIdAsync(id);
        if (existingPackage is null)
            return NotFound();

        await packageService.UpdateAsync(package);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var existingPackage = await packageService.GetByIdAsync(id);
        if (existingPackage is null)
            return NotFound();

        await packageService.DeleteAsync(id);
        return NoContent();
    }
}
