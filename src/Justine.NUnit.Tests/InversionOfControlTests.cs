using NUnit.Framework;

namespace Justine.Tests
{
    public static class InversionOfControlTests
    {
        [Test]
        public static void IocContainerTest()
        {
            var container = InversionOfControl.Container;
            container.GetInstance<Justine>();
        }
    }
}
