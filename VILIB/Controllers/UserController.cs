using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using VILIB.Helpers;
using VILIB.Model;
using VILIB.Repositories;

namespace VILIB.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserRegistrationController : ApiController
    {
        private readonly IInputValidator _mInputValidator;
        private readonly IUserRepository _mUserRepository;

        public UserRegistrationController(IUserRepository userRepository, IInputValidator inputValidator)
        {
            _mUserRepository = userRepository;
            _mInputValidator = inputValidator;
        }

        public async Task<HttpResponseMessage> Put()
        {
            var requestContent = Request.Content;
            var jsonContent = await requestContent.ReadAsStringAsync();
            var credentials = JsonConvert.DeserializeObject<FrontendUser>(jsonContent);

            if (_mInputValidator.UsernameTaken(credentials.username))
                return JsonResponse.JsonHttpResponse<object>(
                    ConfigurationManager.AppSettings["usernameError"]);

            if (_mInputValidator.EmailTaken(credentials.email))
                return JsonResponse.JsonHttpResponse<object>(
                    ConfigurationManager.AppSettings["emailError"]);

            var user = new User
            {
                Nickname = credentials.username, Password = credentials.password, Email = credentials.email,
                Name = credentials.firstName, Surname = credentials.lastName
            };
            var result = await _mUserRepository.Add(user);
            return JsonResponse.JsonHttpResponse<object>(true);
        }
    }


    [EnableCors("*", "*", "*")]
    public class UserSignInController : ApiController
    {
        public delegate bool UserActionHandler<TEventsArgs>(object sender, TEventsArgs e);

        private readonly IUserRepository _mUserRepository;

        public UserSignInController(IUserRepository userRepository)
        {
            _mUserRepository = userRepository;
        }

        public event UserActionHandler<LoginEventArgs> OnLogin;

        public async Task<HttpResponseMessage> Put()
        {
            var requestContent = Request.Content;
            var jsonContent = await requestContent.ReadAsStringAsync();
            var credentials = JsonConvert.DeserializeObject<FrontendUser>(jsonContent);

            if (Login(credentials))
            {
                var token = JwtManager.GenerateToken(credentials.username);
                return JsonResponse.JsonHttpResponse(token);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        private bool Login(FrontendUser credentials)
        {
            if (credentials == null) return false;
            var loginArgs = new LoginEventArgs {Username = credentials.username, Password = credentials.password};

            if (OnLogin(this, loginArgs))
                return true;
            return false;
        }
    }
}