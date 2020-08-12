using Microsoft.Extensions.Configuration;

namespace IoCTest
{
    public class Settings
    {
        public static IConfiguration Configuration { get; set; } = new ConfigurationBuilder().AddJsonFile("iocsettings.json",reloadOnChange: true, optional:false).Build();

    }
}