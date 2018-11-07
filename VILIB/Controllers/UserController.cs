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
            var credentials = JsonConvert.DeserializeObject<User>(jsonContent);

            if (_mInputValidator.UsernameTaken(credentials.Nickname))
            {
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.UserErr);
            }
            else if (_mInputValidator.EmailTaken(credentials.Email))
            {
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.EmailErr);
            }
            else
            {
                _mUserRepository.Add(credentials);
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
            var credentials = JsonConvert.DeserializeObject<User>(jsonContent);

            if (_mInputValidator.ValidateLogin(credentials.Nickname, credentials.Password))
            {
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.UserErr);
            }
            else
            {
                //_mUserRepository.Add(credentials);
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.LoggedIn);
            }
        }
    }
}
