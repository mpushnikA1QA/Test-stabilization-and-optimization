using System.Threading.Tasks;
using RestSharp;

namespace Exam
{
    public static class API_TokenCreator
    {
        private const string RequestTokenHead = "token/get";
        private const string RequestTokenParam = "variant";

        public static async Task<string> GenerateToken(string API_URL, string variant)
        {
            RestClient Client = new RestClient(API_URL);
            var request = new RestRequest(RequestTokenHead);
            request.AddParameter(RequestTokenParam, variant);
            request.RequestFormat = DataFormat.Json;
            var token = await Client.PostAsync(request);
            return token.Content;
        }
    }
}
