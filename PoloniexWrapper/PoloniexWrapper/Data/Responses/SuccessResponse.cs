using Newtonsoft.Json;
using PoloniexWrapper.Exceptions;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoloniexWrapper.Data.Responses
{
    public sealed class SuccessResponse
    {
        public Error Error { get; private set; }
        public bool Status { get; private set; } = true;

        public SuccessResponse(HttpResponseMessage responseMessage)
        {
            Error = GetMessage<Error>(responseMessage).Result;
            CheckStatus(Error);
        }

        public async Task<T> GetMessage<T>(HttpResponseMessage responseMessage)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        private void CheckStatus(Error Error)
        {
            if (Error.ErrorMessage != null) Status = false;
        }
    }
}
