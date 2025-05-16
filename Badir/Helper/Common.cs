using System.Net;
namespace ReactNative.Helper;

public static class Common
{
    private static string GetCurrentDirectory()
    {
        var result = Directory.GetCurrentDirectory();
        return result;
    }
    private static string GetStaticContentDirectory()
    {
        var result = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" );
        if (!Directory.Exists(result))
        {
            Directory.CreateDirectory(result);
        }
        return result;
    }
    public static string GetFilePath(string fileName)
    {
        var staticContentDirectory = GetStaticContentDirectory();
        var decodedFileName = WebUtility.UrlDecode(fileName);
        var result = Path.Combine(staticContentDirectory, decodedFileName);
        return result;
    }
}