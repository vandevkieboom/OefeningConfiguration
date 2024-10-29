namespace OefeningConfiguration.Models
{
    public class ApplicationSettings
    {
        public const string SectionName = "ApplicationSettings";
        public string AppName { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public int MaxUsers { get; set; }
    }
}
