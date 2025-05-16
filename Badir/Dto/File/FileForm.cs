namespace ReactNative.Dto.File;

public class FileForm
{
    public string? DirectoryName { get; set; }
    public string? SubDirectoryName { get; set; }
    public required IFormFile[] Files { get; set; } 
}