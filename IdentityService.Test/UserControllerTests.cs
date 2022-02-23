using IdentityService.API.Controllers;
using IdentityService.Core.Entities;
using IdentityService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdentityService.Test
{
    public class UserControllerTests
    {
        //private readonly Mock<IUserRepository> service;
        //public UserControllerTests()
        //{
        //    service = new Mock<IUserRepository>();
        //}
        
        //[Fact]
        //public void GetUserByApiId_Users_UserExistInDB()
        //{
        //    //arrange
        //    var user = GetSampleData();
        //    service.Setup(x => x.GetUserByAplId("API1234")).Returns(user);
        //    var controller = new UsersController(service.Object);

        //    //act
        //    var actionResult = controller.GetUserByAplId("API1234");
        //    var result = actionResult.Result as OkObjectResult;
        //    var actual = result.Value as UserDetailEntity;

        //    //assert
        //    Assert.IsType<OkObjectResult>(result);
        //    result.Value.Equals(user);
        //}

        //[Fact]
        //public void GetUserByApiId_Users_UserDoesNotExistInDB()
        //{
        //    //arrange
        //    var user = GetSampleData();
        //    service.Setup(x => x.GetUserByAplId("API1234")).Returns(user);
        //    var controller = new UsersController(service.Object);

        //    //act
        //    var actionResult = controller.GetUserByAplId("API10");

        //    //assert 
        //    var result = actionResult.Result;
        //    Assert.IsType<NotFoundResult>(result);
        //}

        //[Fact]
        //public void GetUserByUserId_Users_UserExistInDB()
        //{
        //    //arrange
        //    var user = GetSampleData();
        //    string userDetailsJson = JsonConvert.SerializeObject(user);
        //    string base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(userDetailsJson));
        //    service.Setup(x => x.GetUserByUserId(new Guid("2ADEA345-7F7A-4313-87AE-F05E8B2DE678"))).
        //       ReturnsAsync(base64String);
        //    var controller = new UsersController(service.Object);

        //    //act
        //    var actionResult = controller.GetUserByUserId(new Guid("2ADEA345-7F7A-4313-87AE-F05E8B2DE678"));
        //    var result = actionResult.Result as OkObjectResult;
        //    var actual = result.Value as String;

        //    //assert
        //    Assert.IsType<OkObjectResult>(result);
        //    result.Value.Equals(base64String);
        //}

        //[Fact]
        //public void GetUserByUserId_Users_UserDoesNotExistInDB()
        //{
        //    //arrange
        //    var user = GetSampleData();
        //    string userDetailsJson = JsonConvert.SerializeObject(user);
        //    service.Setup(x => x.GetUserByUserId(new Guid("2ADEA345-7F7A-4313-87AE-F05E8B2DE678"))).
        //       ReturnsAsync(Convert.ToBase64String(Encoding.UTF8.GetBytes(userDetailsJson)));
        //    var controller = new UsersController(service.Object);

        //    //act
        //    var actionResult = controller.GetUserByUserId(new Guid("2ADEA345-7F7A-4313-87AE-F05E8B2DE671"));

        //    //assert
        //    var result = actionResult.Result;
        //    Assert.IsType<NotFoundResult>(result);
        //}
        //private async Task<UserDetailEntity> GetSampleData()
        //{
        //    UserDetailEntity userDetailEntity = new UserDetailEntity
        //    {
        //        UserName = "AnuThapa",
        //        UserGuid = new Guid("2ADEA345-7F7A-4313-87AE-F05E8B2DE678"),
        //        RoleName = "Agent",
        //        RoleId = 1,
        //        AplId = "API1234",
        //        HasActiveRole = false

        //    };
        //    return await Task.FromResult<UserDetailEntity>(userDetailEntity);
        //}
    }
}
