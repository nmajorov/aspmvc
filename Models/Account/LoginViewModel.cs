using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace aspmvc.Models.Account
{
    public class LoginViewModel :IdentityUser
    {
        
        public bool RememberMe { get; set; }
    }

}
