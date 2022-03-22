using NUnit.Framework;

namespace Nstdspace.UnityCodeGenerator.Tests.Tests
{
    public class GeneratedSourceTest
    {
        [Test]
        public void TestConstructor()
        {
            var source = new GeneratedSource("source-code", "name", "namespace");
            Assert.AreEqual("source-code", source.SourceCode);
            Assert.AreEqual("name", source.Name);
            Assert.AreEqual("namespace", source.RelativeNamespace);
        }
    }
}