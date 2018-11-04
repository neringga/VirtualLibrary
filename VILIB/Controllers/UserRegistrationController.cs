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
    public class UserRegistrationController : ApiController
    {
        private readonly IUserRepository _mUserRepository;
        private readonly IInputValidator _mInputValidator;

        public UserRegistrationController(IUserRepository userRepository, IInputValidator inputValidator)
        {
            _mUserRepository = userRepository;
            _mInputValidator = inputValidator;
        }

        //GET: api/User
        //public bool Get()
        //{
        //return _mUserPresenter.GetUserList();
        //}

        //// GET: api/User/5
        //public IHttpActionResult Get(string username)
        //{
        //    var foundUser = _mUserRepository.GetList().FirstOrDefault(user => user.Nickname == username);
        //    if (foundUser == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(foundUser);
        //}

        // POST: api/User
        //public void Post([FromBody]string value)
        //{
        //}

        //PUT: api/User/5
        public async Task<HttpResponseMessage> Put()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var credentials = JsonConvert.DeserializeObject<User>(jsonContent);

            if (_mInputValidator.UsernameTaken(credentials.Nickname))
            {
                return JsonResponse.JsonHttpResponse<Object>(StaticStrings.UsernameErr);
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

            //if (!_mInputValidator.UsernameTaken(credentials.Nickname)
            //    || !_mInputValidator.EmailTaken(credentials.Email))
            //{
            //    _mUserRepository.Add(credentials);
            //    return JsonResponse.JsonHttpResponse<Object>(true);
            //}
            //else
            //{
            //    return JsonResponse.JsonHttpResponse<Object>(false);
            //}
        }

        // DELETE: api/User/5
        //public void Delete(int id)
        //{
        //}
        }
}
