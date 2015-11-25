namespace CareerHub_API_ASPNET.Framework.Config {
    public interface ICareerHubConfig {        
        string BaseUrl { get; }
        string ClientID { get; }
        string ClientSecret { get; }
    }
}