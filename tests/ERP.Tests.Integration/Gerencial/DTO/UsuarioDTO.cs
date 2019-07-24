using System;

namespace ERP.Tests.Integration.Gerencial.DTO
{
    public class UsuarioDTO
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string access_token { get; set; }
        public DateTime expires_in { get; set; }
        public User user { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public Claim[] claims { get; set; }
    }

    public class Claim
    {
        public string type { get; set; }
        public string value { get; set; }
    }

}
