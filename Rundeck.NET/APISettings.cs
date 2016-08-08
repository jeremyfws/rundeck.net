using System.Configuration;

namespace RundeckNET.Config
{
    public class APISettings : ConfigurationSection
    {
        static APISettings settings =
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            .GetSection("RundeckNETSettings")
            as APISettings;

        public static APISettings Settings
        {
            get
            {
                return settings;
            }
        }

        [ConfigurationProperty("Endpoint", IsRequired = true, DefaultValue = "")]
        public string Endpoint
        {
            get { return (string)this["Endpoint"]; }
            set { this["Endpoint"] = value; }
        }


        [ConfigurationProperty("Port",
          DefaultValue = "",
          IsRequired = false)]

        public string Port
        {
            get
            {
                return this["Port"].ToString();
            }
            set
            {
                this["Port"] = value;

            }
        }

        [ConfigurationProperty("AuthToken", IsRequired = false, DefaultValue = "")]

        public string AuthToken
        {
            get { return (string)this["AuthToken"]; }
            set { this["AuthToken"] = value; }
        }


    }

}
