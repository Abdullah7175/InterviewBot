using InterviewBot.Data;
using InterviewBot.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InterviewBot.Pages.SubTopics
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public List<SubTopic> SubTopics { get; set; } = new();

        public IndexModel(AppDbContext db) => _db = db;

        public async Task OnGetAsync()
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            SubTopics = await _db.SubTopics.Include(st => st.Topic).Where(st => st.UserId == userId).ToListAsync();
        }
    }
}