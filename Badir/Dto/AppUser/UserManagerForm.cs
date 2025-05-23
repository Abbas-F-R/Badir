using System.ComponentModel.DataAnnotations;

namespace Badir.Dto.AppUser;

public class UserManagerForm
{
    [Required(ErrorMessage = "الاسم مطلوب")]
    [MaxLength(50, ErrorMessage = "يجب ألا يزيد الاسم عن 50 حرفاً")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "اسم المستخدم مطلوب")]
    [MaxLength(15, ErrorMessage = "يجب ألا يزيد اسم المستخدم عن 15 حرفاً")]
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "اسم المستخدم يجب أن يحتوي فقط على أحرف إنجليزية وأرقام.")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "كلمة المرور مطلوبة")]
    [MinLength(6, ErrorMessage = "يجب أن تحتوي كلمة المرور على 6 أحرف على الأقل")]
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "كلمة المرور يجب أن تحتوي فقط على أحرف إنجليزية وأرقام.")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    

}