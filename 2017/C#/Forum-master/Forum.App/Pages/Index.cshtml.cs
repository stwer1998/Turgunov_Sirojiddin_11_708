using Forum.App.DataBase.Context;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum.App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ForumDbContext dbContext;

        public IndexModel(ForumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            this.Subforums = this.dbContext.Forums.Include(x => x.Subjects).ToList();
        }

        public IEnumerable<Forum.App.DataBase.Entities.Subforum> Subforums { get; set; }
    }
}
