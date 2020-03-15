namespace IISWebManager.Infrastructure.Utils
{
    public static class ApplicationUtils
    {
        public static string ConvertPathToName(string path)
            => path.Replace("/", string.Empty);

        public static string ConvertNameToPath(string name)
            => $"/{name}";
    }
}