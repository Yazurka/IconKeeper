using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo.Server
{
    /// <summary>
    ///     An <see cref="IConfiguration" /> implementation that gets its
    ///     values from app/web.config.
    /// </summary>
    /// <example>
    ///     <code>
    /// <![CDATA[
    /// <appSettings>
    ///     <add key="ConnectionString" value="Data Source=world;User ID=mal;Password=oosp5ukt" />
    ///     <add key="EHRServerUrl" value="http://www.tempuri.org" />
    ///     <add key="LogFactoryType" value="DIPS.Insight.Server.WebApi.Logging.Log4NetLogFactory, DIPS.Insight.Server.WebApi"/>
    /// </appSettings>
    /// ]]>
    /// </code>
    /// </example>
    public class AppSettingsConfiguration : IConfiguration
    {
        private Lazy<string> databaseName;
        private Lazy<string> databaseUserName;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettingsConfiguration"/> class.
        /// </summary>
        public AppSettingsConfiguration()
        {
            databaseName = new Lazy<string>(ResolveDatabaseName);
            databaseUserName = new Lazy<string>(ResolveDatabaseUser);
        }

        private string ResolveDatabaseUser()
        {
            return Regex.Match(ConnectionString, "User ID=(.*?);").Groups[1].Value;
        }

        private string ResolveDatabaseName()
        {
            return "looool";
        }

        /// <summary>
        /// Gets the connection string to be used for 
        /// connecting to the database. 
        /// </summary>
        public string ConnectionString
        {
            get { return "Server=127.0.0.1;Database=iconbase;Uid=mal;Pwd=oosp5ukt;"; }
        }

        /// <summary>
        ///     Gets the URL to the EHR server.
        /// </summary>
        public string EHRServerUrl
        {
            get { return "looool"; }
        }

        /// <summary>
        ///     Gets the URL to the Arena App server.
        /// </summary>
        public string ArenaAppServerUrl
        {
            get { return "http://localhost:8080/"; }
        }

        public Type LogFactoryType { get; private set; }

        /// <summary>
        ///     Gets the type of log factory to be used.
        /// </summary>


        /// <summary>
        /// Gets the public root url. 
        /// </summary>
        /// <remarks>
        /// This setting is used to provide the correct URL for links when the actual 
        /// service is served through a proxy. If the value is missing, the value from <see cref="IConfiguration.SelfHostUrl"/> will be used.
        /// </remarks>
        public string RootUrl
        {
            get
            {
                return "http://localhost:8080";
            }
        }

        /// <summary>
        /// Gets the URL for the self hosted web application.
        /// </summary>
        public string SelfHostUrl
        {
            get
            {
                return "http://localhost:8080";
            }
        }

        /// <summary>
        /// Gets the database name (TNS name) from the <see cref="IConfiguration.ConnectionString"/>.
        /// </summary>
        public string DatabaseName
        {
            get
            {
                return "lool2";
            }
        }

        /// <summary>
        /// Gets the database username that is used to log onto the database server.
        /// </summary>
        public string DatabaseUserName
        {
            get
            {
                return "loolName";
            }
        }
    }
}
