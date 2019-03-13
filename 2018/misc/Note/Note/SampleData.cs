using Note.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note
{
    public class SampleData
    {
        public static void Initialize(MyDbContext context)
        {
            if (!context.Notes.Any())
            {
                context.Notes.AddRange(
                    new Models.Note
                    {
                        NoteName = "smth",
                        NoteText = "some text"
                    });
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Login = "a",
                        Password = "a"

                    });
            }
        }
    }
}
