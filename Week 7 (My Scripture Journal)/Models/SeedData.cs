using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_Scripture_Journal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Scripture_Journal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new My_Scripture_JournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<My_Scripture_JournalContext>>()))
            {
                // Look for any Scriptures.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "1 Nephi",
                        Verse = "3:7",
                        DateAdded = DateTime.Parse("2022-6-4"),
                        Notes = "Nephi states that he will do what the Lord commands of him."
                    },

                    new Scripture
                    {
                        Book = "Mosiah",
                        Verse = "2:17",
                        DateAdded = DateTime.Parse("2022-6-4"),
                        Notes = "By performing service for others, we shall learn wisdom."
                    },

                    new Scripture
                    {
                        Book = "Moroni",
                        Verse = "10:4",
                        DateAdded = DateTime.Parse("2022-6-4"),
                        Notes = "Through the Holy Ghost, we can know truth."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
