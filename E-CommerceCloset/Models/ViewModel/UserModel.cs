using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceCloset.Models.ViewModel
{
    public class UserModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Name-Surname Required")]
        [Display(Name = "Name ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "E-Mail Required")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "TCKN Required")]
        [Display(Name = "TCKN")]
        public string TCKN { get; set; }

        [Required(ErrorMessage = "Telephone Required")]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Image Required")]
        [Display(Name = "Image")]
        public HttpPostedFileBase ImagePath { get; set; }
        [Required(ErrorMessage = "User Admin Required")]
        [Display(Name = "User Status")]
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}