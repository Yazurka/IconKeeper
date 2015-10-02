using Newtonsoft.Json;

namespace IconKeeper.Server.Icon
{
   public class Icon
    {
        [JsonIgnore]
        public string GuidString { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Tag { get; set; }
    }
}
