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
        public void TestReadFromTweeter()
        {
            var url = "https://www.estadao.com.br";                                //"https://twitter.com/vladimirrech";
            // read single node using the "class" attribute
            var node = "//h3[@class='title']/a";    //"p[@class='TweetTextSize TweetTextSize--normal js-tweet-text tweet-text']";
            MainEngine eng = new MainEngine(url, node);
            string text = eng.Read();
            Assert.IsNotNull(text, eng.LastError);
            TestContext.WriteLine("".PadLeft(80, '='));
            TestContext.WriteLine(text);
            TestContext.WriteLine("".PadLeft(80, '='));
            TestContext.WriteLine(eng.DecodedText);
        }
    }
}
