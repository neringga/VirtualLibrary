using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
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
                return JsonResponse.JsonHttpResponse<Object>(
                    ConfigurationManager.AppSettings["usernameError"]);
            }
            else if (_mInputValidator.EmailTaken(credentials.email))
            {
                return JsonResponse.JsonHttpResponse<Object>(
                        ConfigurationManager.AppSettings["emailError"]);
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
        public delegate bool UserActionHandler<TEventsArgs>(object sender, TEventsArgs e);
        public event UserActionHandler<LoginEventArgs> OnLogin;

        private readonly IUserRepository _mUserRepository;

        public UserSignInController(IUserRepository userRepository)
        {
            _mUserRepository = userRepository;
        }

        public async Task<HttpResponseMessage> Put()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var credentials = JsonConvert.DeserializeObject<FrontendUser>(jsonContent);

            if (Login(credentials))
            {
                var token = JwtManager.GenerateToken(credentials.username);
                return JsonResponse.JsonHttpResponse<string>(token);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        private bool Login(FrontendUser credentials)
        {
            if (credentials == null)
            {
                return false;
            }
            var loginArgs = new LoginEventArgs() { Username = credentials.username, Password = credentials.password };

            if (OnLogin(this, loginArgs))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
