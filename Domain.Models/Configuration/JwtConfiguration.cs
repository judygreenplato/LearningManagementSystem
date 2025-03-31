namespace Domain.Models.Configuration;
#nullable disable
public class JwtConfiguration
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int Expires { get; set; }
    public string SecretKey { get; set; }
}
