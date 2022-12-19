using System.Text.Json;

namespace API.Model
{
    public class PlainText
    {
        public string username { get; set; }
        public string password { get; set; }
        public string Key { get; set; }
    }
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LowerCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) =>
            name.ToLower();
    }
}
