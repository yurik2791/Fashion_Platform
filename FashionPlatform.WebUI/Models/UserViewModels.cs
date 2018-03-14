using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FashionPlatform.Domain.UserAndRole;
using FashionPlatform.Domain.UserAndRole.Infrastructure;

namespace FashionPlatform.WebUI.Models
{
    public class RegisterUserViewModel
    {
        [DisplayName("Имя")]
        [Required(ErrorMessage = "Введите ваше имя")]
        [StringLength(16, ErrorMessage = "Имя должно содержать не менее 2 символов и не более 16", MinimumLength = 2)]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Введите вашу фамилию")]
        [StringLength(16, ErrorMessage = "Фамилия должна содержать не менее 2 символов и не более 16", MinimumLength = 2)]
        public string LastName { get; set; }

        [DisplayName("Логин")]
        [Required(ErrorMessage = "Введите Username")]
        [StringLength(255, ErrorMessage = "Username должен содержать не менее 2 символов и не более 16", MinimumLength = 5)]
        public string UserName { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Введите email")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Введите правильный email")]
        public string Email { get; set; }

        [DisplayName("Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [StringLength(255,ErrorMessage = "Пароль должен содержать не менее 5 символов и не более 255", MinimumLength = 5)]
        public string Password { get; set; }

        [DisplayName("Подтвердите пароль")]
        [Required(ErrorMessage = "Введите подтвердждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Согласен(а)")]
        [Required(ErrorMessage = "Вы должны быть согласны с правилами и условиями")]
        public bool Agree { get; set; }
        }
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class RoleEditModel
    {
        public AppRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }

    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}