using System.Threading.Tasks;
using GRINTSYSQR.Models.TokenAuth;
using GRINTSYSQR.Web.Controllers;
using Shouldly;
using Xunit;

namespace GRINTSYSQR.Web.Tests.Controllers
{
    public class HomeController_Tests: GRINTSYSQRWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}