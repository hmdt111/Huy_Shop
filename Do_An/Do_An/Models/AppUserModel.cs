using Microsoft.AspNetCore.Identity;

namespace Do_An.Models
{
    public class AppUserModel : IdentityUser
    {
        public string Occupation {  get; set; }

        public string RoleId { get; set; }

        public string Token { get; set; }
     
    }
}
