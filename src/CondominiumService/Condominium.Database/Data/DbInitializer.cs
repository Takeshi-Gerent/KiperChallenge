using Auth.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Condominium.Database.Data
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(User.WithId(1,"admin", "password"));
        }

    }
}
