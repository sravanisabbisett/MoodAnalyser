using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSadMessage_ShouldReturnSad()
        {
            MoodAnalyse moodAnalyse = new MoodAnalyse();
            string result=moodAnalyse.AnalyseMood("I am sad message");
            Assert.AreEqual("SAD", result);
        }

        [TestMethod]
        public void GivenHappyMessage_ShouldReturnHappy()
        {
            MoodAnalyse moodAnalyse = new MoodAnalyse();
            string result=moodAnalyse.AnalyseMood("I am Happy Message");
            Assert.AreEqual("HAPPY", result);
        }

    }
}
