using System.ComponentModel.DataAnnotations;

namespace ReactNative.Dto.AppUser
{
    public class UserForm
    {
        [Required(ErrorMessage = "الاسم مطلوب")]
        [StringLength(100, ErrorMessage = "يجب ألا يزيد الاسم عن 50 حرفاً")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "اسم المستخدم مطلوب")]
        [StringLength(15, ErrorMessage = "يجب ألا يزيد اسم المستخدم عن 15 حرفاً")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "اسم المستخدم يجب أن يحتوي فقط على أحرف إنجليزية وأرقام.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "يجب أن تحتوي كلمة المرور على 6 أحرف على الأقل")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "كلمة المرور يجب أن تحتوي فقط على أحرف إنجليزية وأرقام.")]
        public required string Password { get; set; }

    }
}