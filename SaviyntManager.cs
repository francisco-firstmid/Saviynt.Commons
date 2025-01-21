using Newtonsoft.Json;
using RestSharp;
using Saviynt.Commons.Requests;
using System.Text;

namespace Saviynt.Commons.Responses
{
    public class SaviyntManager
    {
        private string _Url { get; }
        private string _UserName { get; }
        private string _Password { get; }

        public SaviyntManager(string url, string username, string password)
        {
            _Url = url;
            _UserName = username;
            _Password = password;
        }

        public GetTokenResponse GetToken(string userName, string password)
        {
            var options = new RestClientOptions(_Url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/ECM/api/login", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Basic {GetBasicAuth(_UserName, _Password)}"); //U1ZDX0ZyZXNoc2VydmljZTpTYXZpJDEyMzVzaGZyQCE=");
            RestResponse response = client.ExecuteAsync(request).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                GetTokenResponse getTokenResponse = JsonConvert.DeserializeObject<GetTokenResponse>(response.Content);
                if (getTokenResponse != null)
                    return getTokenResponse;
                else
                {
                    throw new Exception($"Invalid \"GetTokenResponse\" format: {response.Content}.");
                }
            }
            else
            {
                throw new Exception($"Invalid \"GetToken\" response: {response.Content}.");
            }
        }

        private string GetBasicAuth(string username, string password)
        {
            byte[] credentialsByteArray = Encoding.UTF8.GetBytes($"{_UserName}:{_Password}");
            return Convert.ToBase64String(credentialsByteArray);
        }

        public RestResponse ExecuteSaviyntRequest(string extension, Method method, string requestJson = null)
        {
            var options = new RestClientOptions(_Url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(extension, method);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {GetToken(_UserName, _Password).access_token}");

            if (requestJson != null)
                request.AddJsonBody(requestJson);

            return client.ExecuteAsync(request).Result;
        }

        public GetUserDetailsResponse GetUserDetails(GetUserDetailsRequest getUserDetailsRequest)
        {
            var options = new RestClientOptions(_Url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/ECM/api/v5/getUser", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {GetToken(_UserName, _Password).access_token}");

            request.AddBody(getUserDetailsRequest, ContentType.Json);
            RestResponse response = client.ExecuteAsync(request).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                GetUserDetailsResponse getUserDetailsResponse = JsonConvert.DeserializeObject<GetUserDetailsResponse>(response.Content);
                if (getUserDetailsResponse != null)
                    return getUserDetailsResponse;
                else
                {
                    throw new Exception($"Invalid \"GetUserDetailsResponse\" format: {response.Content}.");
                }
            }
            else
            {
                throw new Exception($"Invalid \"GetUserDetails\" response: {response.Content}.");
            }
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest updateUserRequest)
        {
            var options = new RestClientOptions(_Url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/ECM/api/v5/updateUser", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {GetToken(_UserName, _Password).access_token}");

            request.AddBody(updateUserRequest, ContentType.Json);
            RestResponse response = client.ExecuteAsync(request).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                UpdateUserResponse createUserResponse = JsonConvert.DeserializeObject<UpdateUserResponse>(response.Content);
                if (createUserResponse != null)
                    return createUserResponse;
                else
                {
                    throw new Exception($"Invalid \"UpdateUserResponse\" format: {response.Content}.");
                }
            }
            else
            {
                throw new Exception($"Invalid \"UpdateUser\" response: {response.Content}.");
            }
        }

        public CreateUserResponse CreateUser(CreateUserRequest createUserRequest)
        {
            var options = new RestClientOptions(_Url)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/ECM/api/v5/createUser", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {GetToken(_UserName, _Password).access_token}");

            request.AddBody(createUserRequest, ContentType.Json);


            RestResponse response = client.ExecuteAsync(request).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                CreateUserResponse createUserResponse = JsonConvert.DeserializeObject<CreateUserResponse>(response.Content);
                if (createUserResponse != null)
                    return createUserResponse;
                else
                {
                    throw new Exception($"Invalid \"CreateUserResponse\" format: {response.Content}.");
                }
            }
            else
            {
                throw new Exception($"Invalid \"CreateUser\" response: {response.Content}.");
            }
        }
    }
}
