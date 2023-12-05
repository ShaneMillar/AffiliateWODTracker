using AffiliateWODTracker.Core.Models;
using AffiliateWODTracker.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AffiliateController : ControllerBase
{
    private readonly IAffiliateRepository _affiliateRepository;

    public AffiliateController(IAffiliateRepository affiliateRepository)
    {
        _affiliateRepository = affiliateRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Affiliate>> GetById(int id)
    {
        var affiliate = await _affiliateRepository.GetByIdAsync(id);
        if (affiliate == null)
            return NotFound();
        return Ok(affiliate);
    }

    // Other actions...
}
