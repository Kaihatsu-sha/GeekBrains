using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Kaihatsu.Timesheets.WebAPI.Data;
using Kaihatsu.Timesheets.WebAPI.Services;
using Kaihatsu.Timesheets.WebAPI.UserEndpoints;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace UnitTests.UserEndpoints
{
    public class Create
    {
        private readonly UserEndpoint endpoint;
        public Create()
        {
            Mock<ILoggerService<UserEndpoint>> logger = new Mock<ILoggerService<UserEndpoint>>();
            Mock<IRepositoryService<User>> repository = new Mock<IRepositoryService<User>>();
            IUserService service = new UserService(repository.Object);
            endpoint = new UserEndpoint(logger.Object, service);
        }
        [Fact]
        public async void Can_create_user_from_good_entity()
        {
            User entity = new User() { FirstName = "Nick", Age = 23, Email = "dug@gmail.com", PasswordHash = "123", LastName = "Smich" };
            var responce = await endpoint.CreateUser(entity, new CancellationToken());
            var responceCode = ((OkResult)responce).StatusCode;

            var expectedCode = new OkResult().StatusCode;

            Assert.Equal(200, responceCode);
        }

        [Fact]
        public async void Can_create_user_from_empty_entity()//Валидация модели не работает
        {
            User entity = new User() { FirstName = "", Age = 1, Email = "", PasswordHash = "", LastName = "" };
            var responce = await endpoint.CreateUser(entity, new CancellationToken());
            var responceCode = ((OkResult)responce).StatusCode;

            var expectedCode = new OkResult().StatusCode;

            Assert.Equal(400, responceCode);
        }

        [Fact]
        public async void Can_get_user()
        {
            var respoce = await endpoint.GetUserById(10, new CancellationToken());
            
            Assert.Equal(0, respoce.Value.Count);
        }
    }
}
