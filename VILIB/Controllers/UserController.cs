using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using VILIB.Helpers;
using VILIB.Model;
using VILIB.View;
using VILIB.Presenters;
using VILIB.Repositories;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private readonly IUserRepository _mUserRepository;
        private readonly IInputValidator _mInputValidator;

        public UserController(IUserRepository userRepository, IInputValidator inputValidator)
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
            IUser credentials = JsonConvert.DeserializeObject<IUser>(jsonContent);

            if (!_mInputValidator.UsernameTaken(credentials.Nickname)
                || !_mInputValidator.UsernameTaken(credentials.Email))
            {
                return JsonResponse.JsonHttpResponse<Object>(null);
            }
            else
            {
                _mUserRepository.Add(credentials);
                return JsonResponse.JsonHttpResponse<Object>("Success");
            }
        }

        // DELETE: api/User/5
        //public void Delete(int id)
        //{
        //}

    }
}
