using core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MainEngineTests
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void TestReadFromValidUrlAndNode()
        {
            var url = "https://www.estadao.com.br";                                //"https://twitter.com/vladimirrech";
            // read single node using the "class" attribute
            var node = "//h3[@class='title']/a";    //"p[@class='TweetTextSize TweetTextSize--normal js-tweet-text tweet-text']";
            using (MainEngine eng = new MainEngine(url, node))
            {
                string text = eng.Read();
                Assert.IsNotNull(text, eng.LastError);
                TestContext.WriteLine("".PadLeft(80, '='));
                TestContext.WriteLine(text);
                TestContext.WriteLine("".PadLeft(80, '='));
                TestContext.WriteLine(eng.DecodedText);
            }
        }

        [TestMethod]
        public void TestRejectWhenUrlOrNodeIsEmpty()
        {
            string url = null;
            string node = null;

            using (MainEngine eng = new MainEngine(url, node))
            {
                string text = eng.Read();
                Assert.IsTrue(string.IsNullOrEmpty(text));
                Assert.IsTrue(!string.IsNullOrEmpty(eng.LastError));
                TestContext.WriteLine("".PadLeft(80, '='));
                TestContext.WriteLine(eng.LastError);
                url = "https://www.estadao.com.br";
                text = eng.Read();
                Assert.IsTrue(string.IsNullOrEmpty(text));
                Assert.IsTrue(!string.IsNullOrEmpty(eng.LastError));
                TestContext.WriteLine("".PadLeft(80, '='));
                TestContext.WriteLine(eng.LastError);
                url = null;
                node = "somenode";
                Assert.IsTrue(string.IsNullOrEmpty(text));
                Assert.IsTrue(!string.IsNullOrEmpty(eng.LastError));
                TestContext.WriteLine("".PadLeft(80, '='));
                TestContext.WriteLine(eng.LastError);
            }
        }
    }
}
