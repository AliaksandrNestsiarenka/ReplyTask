namespace ReplyTask.ConfigurationModels
{
    public class MainConfigModel
    {
        public string BaseUrl { get; set; }

        public string Browser { get; set; }

        public string DefaultWaitTimeSec { get; set; }

        public Users Users { get; set; }
    }
}
