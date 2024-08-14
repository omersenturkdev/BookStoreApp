using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookContext(serviceProvider.GetRequiredService<DbContextOptions<BookContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        BookId = 1,
                        Title = "Learn",
                        GenreId = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 05)
                    },
                  new Book
                  {
                      BookId = 2,
                      Title = "Test",
                      GenreId = 1,
                      PageCount = 682,
                      PublishDate = new DateTime(2003, 06, 05)
                  });
                context.SaveChanges();
            }
        }
    }
}
