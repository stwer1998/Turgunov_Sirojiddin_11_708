namespace Forum.App.DataBase.Entities
{
    using System.Collections.Generic;

    public class Subforum : Identity
    {
        public string Name { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}