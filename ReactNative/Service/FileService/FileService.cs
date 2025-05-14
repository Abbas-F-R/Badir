namespace ReactNative.Service.FileService;

public class FileService(IWebHostEnvironment webHostEnvironment) : IFileService
{
    
    
  public async Task<(string? file , string? error)> Upload( string? directoryName, string? subDirectoryName, IFormFile file) {
    var maxFileSize = 10 * 1024 * 1024; // 10 MB
    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" }; // الأنواع المسموح بها فقط
    
    if (file.Length > maxFileSize) {
        return (null, "حجم الملف يتجاوز الحد المسموح.");
    }

    // التحقق من امتداد الملف
    var sanitizedFileName = Path.GetFileName(file.FileName);
    var extension = Path.GetExtension(sanitizedFileName).ToLower();
    if (!allowedExtensions.Contains(extension)) {
        return (null, "نوع الملف غير مسموح.");
    }

    // إنشاء اسم فريد للملف
    var id = Guid.NewGuid();
    var fileName = $"{id}{extension}";

    // تحديد المسار وتخزين الملف
    var attachmentsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Attachments", directoryName ?? "none", subDirectoryName ?? "none");

// تأكد من وجود المجلد
    if (!Directory.Exists(attachmentsDir)) Directory.CreateDirectory(attachmentsDir);

    var path = Path.Combine(attachmentsDir, fileName);
    await using var stream = new FileStream(path, FileMode.Create);
    await file.CopyToAsync(stream);

    var filePath = Path.Combine("Attachments", directoryName?? "none", subDirectoryName?? "none", fileName);
    return (filePath , null);
}

public async Task<(string? file , string? error)> UploadSql(IFormFile file) {
    var allowedExtensions = new[] { ".sql" }; // السماح فقط بملفات SQL
    var maxFileSize = 10 * 1024 * 1024; // 10 MB

    // التحقق من حجم الملف
    if (file.Length > maxFileSize) {
        return (null, "حجم الملف يتجاوز الحد المسموح.");
    }

    // التحقق من امتداد الملف
    var sanitizedFileName = Path.GetFileName(file.FileName);
    var extension = Path.GetExtension(sanitizedFileName).ToLower();
    if (!allowedExtensions.Contains(extension)) {
        return (null, "نوع الملف غير مسموح.");
    }

    // إنشاء اسم فريد للملف
    var id = Guid.NewGuid();
    var fileName = $"{id}{extension}";

    // تحديد المسار وتخزين الملف
    var attachmentsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "SQL");
    if (!Directory.Exists(attachmentsDir)) Directory.CreateDirectory(attachmentsDir); // تأكد من وجود المجلد

    var path = Path.Combine(attachmentsDir, fileName);
    await using var stream = new FileStream(path, FileMode.Create);
    await file.CopyToAsync(stream);

    var filePath = Path.Combine("SQL", fileName);
    return (filePath , null);
}




public async Task<(List<string>? files , string? error)> Upload(FileForm form)
    {
        var fileList = new List<string>();
        foreach (var file in form.Files)
        { 
            var fileToAdd = await Upload(form.DirectoryName, form.SubDirectoryName, file);
            fileList.Add(fileToAdd.file!);
        }
        return (fileList , null);
    }

    public async Task<(List<string>? files, string? error)> UploadSql(IFormFile[] files)
    {
        var fileList = new List<string>();
        foreach (var file in files)
        { 
            var fileToAdd = await UploadSql(file);
            fileList.Add(fileToAdd.file!);
        }
        return (fileList , null);
    }

    public async Task<(string? filePath, string? error)> Delete(string fileName)
    {
            var filePath = Path.Combine(webHostEnvironment.WebRootPath,  fileName);


            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
                return (filePath, null); 
            }
            else
            {
                return (null, "File does not exist.");
            }
    }
    public async Task<(List<string>? files, string? error)> Delete(List<string> files, string image)
    {
        var deletedFiles = new List<string>();

        foreach (var file in files)
        {
            if (image != file)
            {
                var (filePath, error) = await Delete(file);
            
                if (filePath != null)
                {
                    deletedFiles.Add(filePath);
                }
                else
                {
                    return (null, $"Error deleting file '{file}': {error}");
                }
            }
        }

        return (deletedFiles, null);
    }

    
    public async Task<(string? data, string? error)> UpdateImageAsync(string? currentImage, string? newImage)
    {
        if (string.IsNullOrEmpty(newImage) || !newImage.StartsWith("Attachments") ) return (currentImage , null);

        if (!string.IsNullOrEmpty(currentImage) && currentImage.StartsWith("Attachments"))
        {
            var (_, error) = await Delete(currentImage);
            if (error != null)
            {
                return (newImage, null);
            }
        }
        return (newImage,null);
    }

    public async Task<(List<string>? data, string? error)> UpdateFilesAsync(List<string>? currentFiles, List<string>? newFiles, string image)
    {
        if (newFiles == null || newFiles.Any(file => (string.IsNullOrEmpty(file) || !(file.StartsWith("Attachments")))))
        {
            return (currentFiles, null);
        }
        if (currentFiles != null&& currentFiles.Any(file => (!string.IsNullOrEmpty(file) && (file.StartsWith("Attachments")))))
        {
            var (_, error) = await Delete(currentFiles, image);
            if (error != null)
            {
                return (null, error);
            }
        }
        return (newFiles, null);
    }

   
}
