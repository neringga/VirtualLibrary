using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using VILIB.View;
using VILIB.Presenters;
using VILIB.Repositories;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private readonly IUserRepository _mUserRepository;

        public UserController(IUserRepository userRepository)
        {
            _mUserRepository = userRepository;
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

        //// POST: api/User
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/User/5
        public void Put()
        {

        }

        // DELETE: api/User/5
        //public void Delete(int id)
        //{
        //}

    }
}
