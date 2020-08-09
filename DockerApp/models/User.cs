using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DockerApp.models
{
    class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        [ForeignKey("GruopId")]
        public Group Group { get; set; }
        public int PasswordSalt { set; get; }
        public byte[] PasswordHash { set; get; }


        static public User createUser(string Login, string password, string Group)
        {
            int salt = Crypto.GenerateSaltForPassword();
            byte[] hash = Crypto.ComputePasswordHash(password, salt);
            using (AppContext db = AppContext.GetContext())
            {
                var groupInstance = db.Groups.Single(g => g.Name == Group);
                User user = new User
                {
                    Login = Login,
                    Group = groupInstance,
                    PasswordSalt = salt,
                    PasswordHash = hash
                };
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
        }

        static public User getUser(string login)
        {
            using (AppContext db = AppContext.GetContext())
            {
                return db.Users.Include(u => u.Group).Single(u => u.Login == login);
            }
        }
        static public User getUser(int Id)
        {
            using (AppContext db = AppContext.GetContext())
            {
                return db.Users.Include(u => u.Group).Single(u => u.Id == Id);
            }
        }


        static public User validatingUser(string login, string password)
        {
            using (AppContext db = AppContext.GetContext())
            {
                try
                {
                    User user = db.Users.Include(u => u.Group).Single(u => u.Login == login);
                    int salt = user.PasswordSalt;
                    byte[] hash = user.PasswordHash;
                    if (Crypto.IsPasswordValid(password, salt, hash))
                        return user;
                    else return null;
                }
                catch { return null; }
            }
        }



        static public List<User> getUserList()
        {
            using (AppContext db = AppContext.GetContext())
            {
                return db.Users.Include(u => u.Group).ToList();
            }
        }
    }
}
