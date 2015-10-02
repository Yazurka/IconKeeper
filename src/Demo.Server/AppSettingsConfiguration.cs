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
       
        /// <summary>
        /// Gets the connection string to be used for 
        /// connecting to the database. 
        /// </summary>
        public string ConnectionString
        {
            get { return "Server=127.0.0.1;Database=iconbase;Uid=mal;Pwd=oosp5ukt;"; }
        }
    }
}
