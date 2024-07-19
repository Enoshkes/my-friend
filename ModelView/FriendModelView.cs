using System.ComponentModel.DataAnnotations;

namespace MyFriend.ModelView
{
    public class FriendModelView
    {
        [Display (Name = "First Name")]
        public string FirstName { get; set; }
        [Display (Name = "Last Name")]
        public string LastName { get; set; }
        [EmailAddress (ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        public IFormFile Image { get; set; }
    }
}
