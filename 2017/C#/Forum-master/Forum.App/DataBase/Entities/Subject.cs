namespace Forum.App.DataBase.Entities
{
    using System.Collections.Generic;

    public class Subject : Identity
    {
        public string Name { get; set; }

        public List<Message> Messages { get; set; }
    }
}
