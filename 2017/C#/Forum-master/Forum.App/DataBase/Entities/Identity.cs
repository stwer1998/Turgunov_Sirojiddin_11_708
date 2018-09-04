using System.ComponentModel.DataAnnotations;

namespace Forum.App.DataBase.Entities
{
    public abstract class Identity
    {
        [Key]
        public int Id { get; set; }
    }
}
