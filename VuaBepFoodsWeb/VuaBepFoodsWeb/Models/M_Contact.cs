
using System.ComponentModel.DataAnnotations;

namespace VuaBepFoodsWeb.Models
{
    public class M_Contact
    {
        public string name { get; set; }
        public string email { get; set; }
        public string telephoneNumber { get; set; }
        public int quantity { get; set; }
        public string message { get; set; }
    }
    public class EM_Contact
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(50, ErrorMessage = "Tên có độ dài tối đa 50 ký tự")]
        public string name { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không hợp lệ")]
        [StringLength(50, ErrorMessage = "Email có độ dài tối đa 50 ký tự")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Email không hợp lệ!")]
        public string email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điện thoại")]
        [StringLength(12, ErrorMessage = "Điện thoại có độ dài tối đa 12 ký tự")]
        public string telephoneNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        public int quantity { get; set; }
        [StringLength(1000, ErrorMessage = "Lời nhắn có độ dài tối đa 1000 ký tự")]
        public string message { get; set; }
    }
}
