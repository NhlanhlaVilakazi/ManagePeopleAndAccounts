namespace ManagePeople.Data
{
    public class ServicesExtensions
    {
        public static string? defaultConnectionString { get; set; }
        public static void CheckApplicationConnectionString()
        {
            defaultConnectionString = Environment.GetEnvironmentVariable("PeopleManagementConnectionString");
            if (string.IsNullOrEmpty(defaultConnectionString))
                throw new Exception("Please setup the connection string on your environment variables");
        }
    }
}
