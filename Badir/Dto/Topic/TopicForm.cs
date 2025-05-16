using System.ComponentModel.DataAnnotations;

namespace ReactNative.Dto.Topic;

public class TopicForm
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public  string Name { get; set; }
}