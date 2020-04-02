using System.Threading.Tasks;
using datascienceanalytics.com.Web.Controllers;
using Shouldly;
using Xunit;

namespace datascienceanalytics.com.Web.Tests.Controllers
{
    public class HomeController_Tests: comWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
