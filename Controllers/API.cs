using API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using XC.RSAUtil;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API : ControllerBase
    {
     

        // POST api/<GiaKietController>
        [HttpPost]
        public string Post(PlainText data)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new LowerCaseNamingPolicy(),
                WriteIndented = false
            };
            User user = new User();

            user.UserName = data.username;
            user.Password = data.password;

            string jsonUser = System.Text.Json.JsonSerializer.Serialize(user, serializeOptions);

            var publicKey = data.Key;

            var rsaUltil = new RsaPkcs1Util(Encoding.UTF8, publicKey, "", 2048);
            var credential = rsaUltil.EncryptBigData(jsonUser, RSAEncryptionPadding.Pkcs1);

            return credential;
        }

    }
}
