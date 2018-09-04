using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forum.App.DataBase.Context;
using Forum.App.DataBase.Entities;

namespace Forum.App.Pages.Messages
{
    public class CreateModel : PageModel
    {
        private readonly Forum.App.DataBase.Context.ForumDbContext _context;

        public CreateModel(Forum.App.DataBase.Context.ForumDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Message Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Messages.Add(Message);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}