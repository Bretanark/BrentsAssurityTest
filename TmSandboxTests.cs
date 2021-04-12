using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace BrentsAssurityTest
{
    public class TmSandboxTests
    {
        [Test]
        public async Task TestCarbonCredits()
        {
            var root = await GetJTokenResponse("https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false");

            var name = root["Name"]?.Value<string>();
            Assert.That(name, Is.EqualTo("Carbon credits"));

            var canRelist = root["CanRelist"]?.Value<bool>();
            Assert.That(canRelist, Is.EqualTo(true));

            var promotions = root["Promotions"];
            var gallery = promotions.Single(x => x["Name"]?.Value<string>() == "Gallery");

            var galleryDescription = gallery["Description"]?.Value<string>();
            StringAssert.Contains("2x larger image", galleryDescription);
        }

        private static async Task<JToken> GetJTokenResponse(string url)
        {
            var request = WebRequest.Create(url);
            var response = await request.GetResponseAsync();
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var responseJson = await reader.ReadToEndAsync();
                var root = JToken.Parse(responseJson);
                return root;
            }
        }

    }
}