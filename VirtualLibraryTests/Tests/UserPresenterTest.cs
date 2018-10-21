using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.Model;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibraryTests.Helpers
{
    [TestClass]
    public class UserPresenterTest
    {
        private UserPresenter m_userPresenter;
        private IUser m_fakeUser;
        private Mock<IRepository<IUser>> m_mockRepo;

        public void Initialize()
        {
            m_mockRepo = new Mock<IRepository<IUser>>();
            m_mockRepo.Setup(r => r.Add(m_fakeUser));
            IRepository<IUser> repository = m_mockRepo.Object;
            m_userPresenter = new UserPresenter(m_fakeUser, repository);
        }

        [TestMethod]
        public void Constructor_ShouldCreate()
        {
            Initialize();
            Assert.IsNotNull(m_userPresenter);
        }

        [TestMethod]
        public void UserDataInsertUser_ValidUser_MessageBoxShown()
        {
            m_fakeUser = new User() { Name = "name", Surname = "surname", Email = "e@mail.com" };
            Initialize();

            //  m_userPresenter.UserDataInsertUser();
            // m_mockRepo.Verify(mock => mock.Add(m_fakeUser), Times.Once()); TODO: fix the mock verification

        }
    }
}
