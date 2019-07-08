namespace ERP.Infra.CrossCutting.Identity.Authorization
{
    public class TokenDescription
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int MinutesValid { get; set; }
    }
}
