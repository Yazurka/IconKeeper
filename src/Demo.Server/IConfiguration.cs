using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Server
{
    /// <summary>
    ///     Represents the configuration value.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        ///     Gets the connection string to be used for
        ///     connecting to the database.
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        ///     Gets the URL to the EHR server.
        /// </summary>
        string EHRServerUrl { get; }

        /// <summary>
        ///     Gets the URL to the Arena App server.
        /// </summary>
        string ArenaAppServerUrl { get; }

        /// <summary>
        ///     Gets the type of log factory to be used.
        /// </summary>
        Type LogFactoryType { get; }

        /// <summary>
        /// Gets the public root url. 
        /// </summary>
        /// <remarks>
        /// This setting is used to provide the correct URL for links when the actual 
        /// service is served through a proxy. If the value is missing, the value from <see cref="SelfHostUrl"/> will be used.
        /// </remarks>
        string RootUrl { get; }

        /// <summary>
        /// Gets the URL for the self hosted web application.
        /// </summary>
        string SelfHostUrl { get; }

        /// <summary>
        /// Gets the database name (TNS name) from the <see cref="ConnectionString"/>.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets the database username that is used to log onto the database server.
        /// </summary>
        string DatabaseUserName { get; }
    }
}
