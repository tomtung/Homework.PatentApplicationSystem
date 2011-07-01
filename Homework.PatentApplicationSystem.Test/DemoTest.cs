using System;
using System.Diagnostics;

using Homework.PatentApplicationSystem.Model;

using NUnit.Framework;
using FluentAssertions;
using Moq;

namespace Homework.PatentApplicationSystem.Test
{
    [TestFixture]
    public class DemoTest
    {
        [Test]
        public void SomeTest()
        {
            1.Should().Be(1);
            true.Should().BeTrue();

            Action action = () => { throw new NotSupportedException(); };
            action.ShouldThrow<NotSupportedException>();

            var mock = new Mock<IUserSpecificService>();
            mock.SetupGet(s => s.User)
                .Returns(new User {UserName = "李冬冬", Password = "mystenarice", Role = Role.立案员});
            Debug.WriteLine(mock.Object.User.UserName);
        }
    }
}
