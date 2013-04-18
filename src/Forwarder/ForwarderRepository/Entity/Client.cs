using System.ComponentModel.DataAnnotations;

namespace ForwarderDAL.Entity
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
