using System;
using System.Net;
using Moq;
using NUnit.Framework;

namespace Simple.Http.Tests
{
    [TestFixture]
    public class MethodDispatcherTests
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            var transportMock = new Mock<ITransport>();
            RequestMock = new Mock<IServiceRequest>();
            RequestMock.SetupAllProperties();
            transportMock.Setup(t => t.CreateRequest()).Returns(RequestMock.Object);

            Twitter = new MethodDispatcher(transportMock.Object);
        }

        #endregion

        protected Mock<IServiceRequest> RequestMock { get; set; }

        protected dynamic Twitter { get; set; }


        [Test]
        public void CallingGetMethodShouldGenerateGetRequest()
        {
            Twitter.GetTimeline(screen_name: "testscreenname");
            RequestMock.VerifySet(r => r.HttpMethod = WebRequestMethods.Http.Get);
        }

        [Test]
        public void NamedParameterShouldEnsureQuerystringParamUsed()
        {
            Twitter.GetTimeline(screen_name: "testscreenname");
            var requestQueryString = RequestMock.Object.QueryString;
            Assert.IsNotNull(requestQueryString, "Query string was null");
            Assert.IsTrue(requestQueryString.Contains("screen_name=testscreenname"));
        }
    }
}