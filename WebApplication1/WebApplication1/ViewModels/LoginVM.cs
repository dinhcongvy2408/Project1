using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Tên Đăng nhập")]
        [Required(ErrorMessage ="Chưa nhập tên Đăng nhập")]
        [MaxLength(25, ErrorMessage ="Tối đa 25 ký tự")]
        public string UserName { get; set; }


        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
