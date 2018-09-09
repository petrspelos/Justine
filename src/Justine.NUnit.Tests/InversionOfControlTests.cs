using NUnit.Framework;

namespace Justine.Tests
{
    public class InversionOfControlTests
    {
        [Test]
        public static void IocContainerTest()
        {
            var container = InversionOfControl.Container;
            var justine = container.GetInstance<Justine>();
        }
    }
}
