using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace P1API.Data
{
    public class ClothingAuthDbContext : IdentityDbContext
    {
        public ClothingAuthDbContext(DbContextOptions<ClothingAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "a9855e8c-20a8-427d-b3b0-4d54da098fec";
            var writerRoleId = "441c0030-e479-41c2-a8d6-80cd4598125d";

            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName ="Reader".ToUpper()
                },

                new IdentityRole()
                {
                    Id = writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }


            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
