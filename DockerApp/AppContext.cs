using System.Threading.Tasks;
using DockerApp.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DockerApp
{
    class AppContext : DbContext
    {
        static IConfigurationRoot config = Startup.Config();
        static private AppContext obj = null;

        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }


        static public AppContext GetContext()
        {
            if (obj == null) obj = new AppContext();
            return obj;
        }

        private AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            ChecDB();
        }

        private async void ChecDB()
        {
            await Task.Run(() =>
            {
                int countGroup = Groups.ToListAsync().Result.Count;
                if (countGroup == 0)
                {
                    Group g1 = new Group { Name = "User" };
                    Group g2 = new Group { Name = "Guest" };
                    Group g3 = new Group { Name = "Manager" };
                    Group g4 = new Group { Name = "Administrator" };
                    Groups.AddRange(g1, g2, g3, g4);
                    SaveChanges();

                    int salt = Crypto.GenerateSaltForPassword();
                    byte[] hash = Crypto.ComputePasswordHash("password", salt);

                    User su = new User { 
                        Login = "Administrator",
                        Group = g4,
                        PasswordSalt = salt,
                        PasswordHash = hash
                    };
                    Users.Add(su);
                    SaveChanges();
                }            
            });          
        }

   

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseNpgsql(config["Database:ConnectionString"]);
        }
    }

}
