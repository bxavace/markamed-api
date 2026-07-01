using System.ComponentModel.DataAnnotations;

namespace markamed_api.Data.Enums
{
    public enum Role
    {
        [Display(Name = "Admin", Description = "Full system access")]
        Admin = 1,

        [Display(Name = "Standard User", Description = "User that can view and rate a healthcare facility")]
        StandardUser = 2,

        [Display(Name = "Moderator", Description = "User that can manage healthcare facilities and their reviews")]
        Moderator = 3
    }
}