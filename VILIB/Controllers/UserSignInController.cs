using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using VILIB.DataSources.Data;
using VILIB.Helpers;
using VILIB.Model;
using VILIB.View;
using VILIB.Presenters;
using VILIB.Repositories;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserSignInController : ApiController
    {
        private readonly IUserRepository _mUserRepository;
        private readonly IInputValidator _mInputValidator;

        public UserRegistrationController(IUserRepository userRepository, IInputValidator inputValidator)
        {
            _mUserRepository = userRepository;
            _mInputValidator = inputValidator;
        }

        /*// GET: api/UserSignIn
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserSignIn/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserSignIn
        public void Post([FromBody]string value)
        {
        }*/

        // PUT: api/UserSignIn/5
        public async Task<HttpResponseMessage> Put()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var credentials = JsonConvert.DeserializeObject<User>(jsonContent);

            if (_mInputValidator.ValidatetLogin(credentials.Nickname, credentials.Password))
            {
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.noUser);
            }
            else
            {
                //_mUserRepository.Add(credentials);
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.LoggedIn);
            }

            /*// DELETE: api/UserSignIn/5
            public void Delete(int id)
            {
            }*/
        }
    }
}
