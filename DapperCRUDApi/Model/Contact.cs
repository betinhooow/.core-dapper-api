using System.ComponentModel.DataAnnotations;

namespace DapperCRUDApi.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Emoji { get; set; }
    }
}