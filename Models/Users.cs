using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HTTPswagerTEST.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Имя

        [DefaultValue("vvedipochty@mail.ru")]
        public string Mail { get; set; } // Почта
    }

}
