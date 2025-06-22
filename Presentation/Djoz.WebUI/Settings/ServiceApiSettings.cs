namespace Djoz.WebUI.Settings
{
    public class ServiceApiSettings
    {
        public string BaseUrl { get; set; }
        public ServiceApi Banners { get; set; }
        public ServiceApi Contacts { get; set; }
        public ServiceApi CountDowns { get; set; }
        public ServiceApi Events { get; set; }
        public ServiceApi DjInfos { get; set; }
        public ServiceApi Packages { get; set; }
        public ServiceApi Songs { get; set; }
        public ServiceApi UserLogins { get; set; }
        public ServiceApi UserRegisters { get; set; }
        public ServiceApi Users { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
