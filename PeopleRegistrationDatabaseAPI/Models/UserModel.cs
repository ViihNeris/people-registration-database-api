using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PeopleRegistrationDatabaseAPI.Models
{
    public class UserModel
    {
        public int IdUser { get; set; }
        public String? UserName { get; set; }
        public String? Address { get; set; }
    }
}
