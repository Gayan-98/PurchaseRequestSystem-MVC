using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ApprovalController : Controller
{
    private readonly ApplicationDbContext _context;

    // Constructor for dependency injection
    public ApprovalController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Index page showing pending requests for Admin users
    public async Task<IActionResult> Index()
    {
        // Check if the user is authenticated and has the "ADMIN" role
        var userRole = HttpContext.Session.GetString("UserRole");
        if (userRole != "ADMIN")
        {
            // Redirect to the login page if not an Admin
            return RedirectToAction("Login", "Account");
        }

        // Get the pending requests
        var pendingRequests = await _context.PurchaseRequests
            .Where(p => p.Status == "PENDING")
            .Include(p => p.User)
            .OrderByDescending(p => p.CreatedDate)
            .ToListAsync();

        return View(pendingRequests);  // Pass the list of pending requests to the view
    }

    // Action to update the status of a PurchaseRequest
    [HttpPost]
    public async Task<IActionResult> UpdateStatus(int id, string status)
    {
        var userRole = HttpContext.Session.GetString("UserRole");
        if (userRole != "ADMIN")
        {
            return Unauthorized();  // Return unauthorized if the user is not an admin
        }

        var request = await _context.PurchaseRequests.FindAsync(id);
        if (request == null)
            return NotFound();  // Return not found if the request with the given id doesn't exist

        // Update the request status
        request.Status = status;
        await _context.SaveChangesAsync();

        // Redirect back to the Index page after updating
        return RedirectToAction(nameof(Index));
    }
}
