using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.View;
using VirtualLibrary.Model;

namespace VirtualLibrary.Helpers.Tests
{
    [TestClass]
    public class InputValidatorTests
    {
        //private InputValidator m_inputValidator;

        //private string m_validName = "valid name";
        //private string m_validSurname = "valid surname";
        //private string m_validEmail = "valid@email.com";

        //[TestInitialize]
        //public void Initialize()
        //{
        //    m_inputValidator = new InputValidator();
        //}

        //[TestMethod]
        //public void Constructor_shouldCreate()
        //{
        //    Assert.IsNotNull(m_inputValidator);
        //}

        //[TestMethod]
        //public void ValidateUserInput_ValidUser_ReturnsNewUser()
        //{
        //    IUser newUser = new User() { Name = m_validName, Surname = m_validSurname, Email = m_validEmail };

        //    var result = m_inputValidator.ValidateUserInput(newUser);
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void ValidateUserInput_NullName_ReturnsNull()
        //{
        //    IUser newUser = new User() { Name = null, Surname = m_validSurname, Email = m_validEmail };

        //    var result = m_inputValidator.ValidateUserInput(newUser);
        //    Assert.IsNull(result);
        //}

        //[TestMethod]
        //public void ValidateUserInput_NullSurname_ReturnsNull()
        //{
        //    IUser newUser = new User() { Name = m_validName, Surname = null, Email = m_validEmail };

        //    var result = m_inputValidator.ValidateUserInput(newUser);
        //    Assert.IsNull(result);
        //}

        //[TestMethod]
        //public void ValidateUserInput_NullEmail_ReturnsNull()
        //{
        //    IUser newUser = new User() { Name = m_validName, Surname = m_validSurname, Email = null };

        //    var result = m_inputValidator.ValidateUserInput(newUser);
        //    Assert.IsNull(result);
        //}

        //[TestMethod]
        //public void ValidateUserInput_NameAsEmptyString_ReturnsNull()
        //{
        //    IUser newUser = new User() { Name = string.Empty, Surname = m_validSurname, Email = m_validEmail };

        //    var result = m_inputValidator.ValidateUserInput(newUser);
        //    Assert.IsNull(result);
        //}

        //[TestMethod]
        //public void ValidateUserInput_SurnameAsEmptyString_ReturnsNull()
        //{
        //    IUser newUser = new User() { Name = m_validName, Surname = string.Empty, Email = m_validEmail };

        //    var result = m_inputValidator.ValidateUserInput(newUser);
        //    Assert.IsNull(result);
        //}

        //[TestMethod]
        //public void ValidateUserInput_EmailAsEmptyString_ReturnsNull()
        //{
        //    IUser newUser = new User() { Name = m_validName, Surname = m_validSurname, Email = string.Empty };

        //    var result = m_inputValidator.ValidateUserInput(newUser);
        //    Assert.IsNull(result);
        //}

        //[TestMethod]
        //public void ValidateUserInput_InvalidEmailformat_ReturnsNull()
        //{
        //    var invalidEmailStrings = new[]
        //    {
        //        "invalid email with whitespace", "emailWithNoAtsign.com", "emailWithNoDotcom@", "emailWithNoDotCom"
        //    };

        //    foreach (var invalidEmail in invalidEmailStrings)
        //    {
        //        IUser newUser = new User() { Name = m_validName, Surname = m_validSurname, Email = invalidEmail };

        //        var result = m_inputValidator.ValidateUserInput(newUser);
        //        Assert.IsNull(result);
        //    }
        //}
    }
}