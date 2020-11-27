using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Givens the sad message should return sad.
        /// </summary>
        [TestMethod]
        public void GivenSadMessage_ShouldReturnSad()
        {
            string message = "I am sad Message";
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);
            string result=moodAnalyse.AnalyseMood(message);
            Assert.AreEqual("SAD", result);
        }
        /// <summary>
        /// Givens the happy message should return happy.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_ShouldReturnHappy()
        {
            string message = "I am Happy Message";
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);
            string result=moodAnalyse.AnalyseMood(message);
            Assert.AreEqual("HAPPY", result);
        }

        /// <summary>
        /// Given the null mood should return happy.
        /// </summary>
        [TestMethod]
        public void GivenNullMood_ShouldReturnHappy()
        {
            string message = null;
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);
            string result = moodAnalyse.AnalyseMood(message);
            Assert.AreEqual("HAPPY", result);
        }

    }
}
