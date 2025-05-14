using System.ComponentModel.DataAnnotations;

namespace ReactNative.Dto.AppUser;

public class LoginRequest
{
    
    [Required(ErrorMessage = "اسم المستخدم مطلوب")]
    [MaxLength(20, ErrorMessage = "يجب ألا يزيد اسم المستخدم عن 20 حرفاً")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "كلمة المرور مطلوبة")]
    [MinLength(6, ErrorMessage = "يجب أن تحتوي كلمة المرور على 6 أحرف على الأقل")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

}