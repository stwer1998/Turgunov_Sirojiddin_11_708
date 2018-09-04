using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum.App.DataBase.Context;
using Forum.App.DataBase.Entities;

namespace Forum.App.Pages.Messages
{
    public class IndexModel : PageModel
    {
        private readonly Forum.App.DataBase.Context.ForumDbContext _context;

        public IndexModel(Forum.App.DataBase.Context.ForumDbContext context)
        {
            _context = context;
        }

        public IList<Message> Message { get;set; }

        public async Task OnGetAsync()
        {
            Message = await _context.Messages.ToListAsync();
        }
    }
}
