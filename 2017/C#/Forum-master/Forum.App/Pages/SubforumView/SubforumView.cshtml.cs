using Forum.App.DataBase.Context;
using Forum.App.DataBase.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum.App.Pages.SubforumView
{
    public class SubforumModel : PageModel
    {
        private readonly ForumDbContext dbContext;

        public SubforumModel(ForumDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet(int forumid)
        {
            this.SubjectsWithMessages = this.dbContext.Subjects
                .Where(x => x.Id == forumid)
                .Include(x => x.Messages).ToList();
        }

        public List<Subject> SubjectsWithMessages { get; set; }
    }
}