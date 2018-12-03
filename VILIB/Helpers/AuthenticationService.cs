using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VILIB.Presenters;

namespace VILIB.Helpers
{
    public class AuthenticationService
    {
        private JwtManager _jwtManager;
        private UserPresenter _userPresenter;

        AuthenticationService(JwtManager jwtManager, UserPresenter userPresenter)
        {
            _jwtManager = jwtManager;
            _userPresenter = userPresenter;
        }
        public bool Authenticated(string token)
        {
            //try
            //{
                var user = _jwtManager.DecodeTokenName(token);
                return (_userPresenter.FindUser(user) != null);
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

        public string AuthenticatedUser(string token)
        {
            return _jwtManager.DecodeTokenName(token);
        }
    }
}