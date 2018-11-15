using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using VILIB.DataSources.Data;
using VILIB.Helpers;
using VILIB.Model;
using VILIB.Repositories;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserRegistrationController : ApiController
    {
        private readonly IUserRepository _mUserRepository;
        private readonly IInputValidator _mInputValidator;

        public UserRegistrationController(IUserRepository userRepository, IInputValidator inputValidator)
        {
            _mUserRepository = userRepository;
            _mInputValidator = inputValidator;
        }

        public async Task<HttpResponseMessage> Put()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var credentials = JsonConvert.DeserializeObject<FrontendUser>(jsonContent);

            if (_mInputValidator.UsernameTaken(credentials.username))
            {
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.UserErr);
            }
            else if (_mInputValidator.EmailTaken(credentials.email))
            {
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.EmailErr);
            }
            else
            {
                var user = new User() { Nickname = credentials.username, Password = credentials.password, Email = credentials.email, Name = credentials.firstName, Surname = credentials.lastName };
                var result = await _mUserRepository.Add(user);
                return JsonResponse.JsonHttpResponse<Object>(true);
            }

        }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserSignInController : ApiController
    {
        private readonly IUserRepository _mUserRepository;
        private readonly IInputValidator _mInputValidator;

        public UserSignInController(IUserRepository userRepository, IInputValidator inputValidator)
        {
            _mUserRepository = userRepository;
            _mInputValidator = inputValidator;
        }

        public async Task<HttpResponseMessage> Put()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var credentials = JsonConvert.DeserializeObject<FrontendUser>(jsonContent);

            if (_mUserRepository.Login(credentials.username, credentials.password))
            {
                
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.LoggedIn);
            }
            else
            {
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.UserErr);
            }
        }
    }

    public class FrontendUser
    {
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
