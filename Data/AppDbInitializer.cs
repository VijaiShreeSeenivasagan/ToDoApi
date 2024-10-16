using Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace Data{
    public class AppDbInitializer{
        public static void Seed(IApplicationBuilder applicationBuilder){
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope()){
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                 if (context == null)
                {
                    throw new ArgumentNullException(nameof(context), "Database context cannot be null.");
                }
                if(!context.Books.Any()){
                    context.Books.AddRange(new Book(){
                        Title = "1st Book",
                        Description = "Book1",
                        isRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now
                    },
                    new Book(){
                        Title = "2nd Book",
                        Description = "Book2",
                        isRead = false,
                        Genre = "Biography",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now
                    }
                    );

                    context.SaveChanges();
                }
            }
        }
    }

}