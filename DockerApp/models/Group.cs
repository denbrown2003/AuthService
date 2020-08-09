using System.Collections.Generic;
using System.Linq;


namespace DockerApp.models
{
    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; }

        static public Group GroupCreate(string Name)
        {
            using (AppContext db = AppContext.GetContext())
            {
                Group group = new Group { Name = Name };
                db.Groups.Add(group);
                db.SaveChanges();
                return group;
            }
        }
        static public List<Group> getGroupsList()
        {
            using (AppContext db = AppContext.GetContext())
            {
                return db.Groups.ToList();
            }
        }

    }
}
