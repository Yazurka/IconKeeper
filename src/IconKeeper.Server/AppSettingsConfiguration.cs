namespace IconKeeper.Server
{
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
