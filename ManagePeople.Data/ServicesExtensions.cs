namespace ManagePeople.Data
{
    public class ServicesExtensions
    {
        public static string? defaultConnectionString { get; set; }
        public static string GetApplicationConnectionString()
        {
            defaultConnectionString = Environment.GetEnvironmentVariable("PeopleManagementConnection");
            if (string.IsNullOrEmpty(defaultConnectionString))
                throw new Exception("Please setup the connection string on your environment variables");
            return defaultConnectionString;
        }
    }
}
