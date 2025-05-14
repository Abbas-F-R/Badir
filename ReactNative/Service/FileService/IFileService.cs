namespace ReactNative.Service.FileService;

public interface IFileService
{
    Task<(string? file , string? error)> Upload(string? directoryName, string? subDirectoryName ,IFormFile file);
    Task<(string? file , string? error)> UploadSql(IFormFile file);
    Task<(List<string>? files , string? error)> Upload(FileForm form);
    Task<(List<string>? files , string? error)> UploadSql(IFormFile[] files);
    Task<(string? filePath, string? error)> Delete(string fileName);
    Task<(List<string>? files, string? error)> Delete(List<string> files, string image);
    Task<(string? data, string? error)> UpdateImageAsync(string? currentImage, string? newImage);
    Task<(List<string>? data, string? error)> UpdateFilesAsync(List<string>? currentFiles, List<string>? newFiles, string image);

}