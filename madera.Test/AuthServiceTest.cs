using madera.Services;
using madera.Test.Mocks;
using System;
using System.Net;
using Xunit;

namespace madera.Test
{
    public class AuthServiceTest
    {
        [Theory]
        [InlineData("test@test.com", "123456", HttpStatusCode.OK)]
        [InlineData("aaaa@test.com", "123456", HttpStatusCode.BadRequest)]
        [InlineData("dsqdsqdqsdsq", "123456", HttpStatusCode.BadRequest)]
        public void LoginTest(string email, string password, HttpStatusCode statusCode)
        {
            var service = new MockAuthService();
            var response = service.Login(new Models.Utilisateur
            {
                utilisateur_email = email,
                utilisateur_password = password
            });
            Assert.Equal(statusCode, response.Result);
        }
    }
}
