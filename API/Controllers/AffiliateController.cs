using AffiliateWODTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AffiliateController : ControllerBase
{
    private readonly IAffiliateManager _affiliateManager;

    public AffiliateController(IAffiliateManager affiliateManager)
    {
        _affiliateManager = affiliateManager;
    }

    [HttpGet(nameof(GetAffiliates), Name = nameof(GetAffiliates))]
    public async Task<IActionResult> GetAffiliates()
    {
        var affiliates = await _affiliateManager.GetAllAffiliates();
        return Ok(affiliates);
    }



    // Other actions...
}
