using System.ComponentModel.DataAnnotations;

namespace VuaBepFoodsWeb.EditModels
{
    public class EM_SendSMS
    {
        [Required(ErrorMessage = "Vui lòng nhập điện thoại")]
        [StringLength(20, ErrorMessage = "Điện thoại có độ dài tối đa 20 ký tự")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        [StringLength(20, ErrorMessage = "Tài khoản có độ dài tối đa 20 ký tự")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(20, ErrorMessage = "Mật khẩu có độ dài tối đa 20 ký tự")]
        public string password { get; set; }

        //[Required(ErrorMessage = "Vui lòng nhập Link")]
        //[StringLength(60, ErrorMessage = "Link có độ dài tối đa 60 ký tự")]
        //public string Link { get; set; }
    }
}
