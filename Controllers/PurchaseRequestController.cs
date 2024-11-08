using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PurchaseRequestController : Controller
{
    private readonly ApplicationDbContext _context;

    public PurchaseRequestController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (!userId.HasValue)
            return RedirectToAction("Login", "Account");

        var requests = await _context.PurchaseRequests
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.CreatedDate)
            .ToListAsync();

        return View(requests);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PurchaseRequest request)
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (!userId.HasValue)
            return RedirectToAction("Login", "Account");

        request.UserId = userId.Value;
        request.Status = "PENDING";
        request.RequestNumber = GenerateRequestNumber();
        request.TotalCost = request.ItemCost * request.ItemQuantity;
        request.CreatedDate = DateTime.Now;

        _context.PurchaseRequests.Add(request);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private string GenerateRequestNumber()
    {
        return "PR" + DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}
