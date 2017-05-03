using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Demo.API;
using Demo.Data;
using Demo.API.Controllers;
using System.Web.Http;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace Demo.API.Test
{
    /// <summary>
    /// Summary description for DemoControllerTest
    /// </summary>
    [TestClass]
    public class DemoControllerTest
    {
        [TestMethod]
        public void Call_Get_Method()
        {
            //Arrange
            Mock<IDemoRepository> mock = new Mock<IDemoRepository>();
            mock.Setup(x => x.Get()).Returns("Hello World");       
            
             DemoController democontroller = new DemoController(mock.Object);
            democontroller.Request = new HttpRequestMessage();
             democontroller.Configuration = new HttpConfiguration();
            //Act
            var response = democontroller.Get();
            //assert
            string result;
            Assert.IsTrue(response.TryGetContentValue<string>(out result));
            Assert.AreEqual("Hello World", result);

        }
        [TestMethod]
        public void Get_Return_Status()
        {
            //Arrange
            Mock<IDemoRepository> mock = new Mock<IDemoRepository>();
            mock.Setup(x => x.Get()).Returns("Hello World");
            DemoController democontroller = new DemoController(mock.Object);
            democontroller.Request = new HttpRequestMessage();
            democontroller.Configuration = new HttpConfiguration();

            // Act
            HttpResponseMessage value = democontroller.Get();
            //Assert
            Assert.IsNotNull(value);
            Assert.IsNotNull(value.Content);


        }
        [TestMethod]
        public void Check_Link_Address()
        {
            //arrange
            Mock<IDemoRepository> mock = new Mock<IDemoRepository>();
            mock.Setup(x => x.Get()).Returns("Hello World");
            DemoController democontroller = new DemoController(mock.Object);
            democontroller.Request = new HttpRequestMessage() { RequestUri=new Uri("http://localhost:56980/api/Demo") };
            democontroller.Configuration = new HttpConfiguration();
            democontroller.Configuration.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            democontroller.RequestContext.RouteData = new HttpRouteData(route: new HttpRoute(), values: new HttpRouteValueDictionary { { "controller", "Demo" } });
            //Act
            var response = democontroller.Get();
            //Assert
            Assert.AreEqual("http://localhost:56980/api/Demo", response.RequestMessage.RequestUri.AbsoluteUri);

          

        }
    }
}
