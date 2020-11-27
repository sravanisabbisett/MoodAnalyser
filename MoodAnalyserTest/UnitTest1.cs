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
            string message = "I am sad Message";
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);
            string result=moodAnalyse.AnalyseMood(message);
            Assert.AreEqual("SAD", result);
        }

        [TestMethod]
        public void GivenHappyMessage_ShouldReturnHappy()
        {
            string message = "I am Happy Message";
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);
            string result=moodAnalyse.AnalyseMood(message);
            Assert.AreEqual("HAPPY", result);
        }

    }
}
