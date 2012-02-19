using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;

namespace Simple.Http.Tests
{
    [TestFixture]
    public class MethodDispatcherTests
    {
        [Test]
        public void CallingGetMethodShouldGenerateGetRequest()
        {
            var transportMock = new Mock<ITransport>();
            var requestMock = new Mock<IServiceRequest>();
            transportMock.Setup(t => t.CreateRequest()).Returns(requestMock.Object);
            dynamic twitter = new MethodDispatcher(transportMock.Object);
            twitter.GetTimeline();
            requestMock.VerifySet(r => r.HttpMethod = System.Net.WebRequestMethods.Http.Get);
        }
    }
}
