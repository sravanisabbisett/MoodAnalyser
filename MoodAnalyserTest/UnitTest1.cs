using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MoodAnalyserTest
{
    /// <summary>
    /// MS Testing class
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Given the happy mood message as parameter should return HAPPY.
        /// </summary>
        [TestMethod]
        public void Given_HappyMoodMessage_Should_Return_HAPPY()
        {
            ///Arrange
            string expected = "HAPPY";
            MoodAnalyse moodAnalyser = new MoodAnalyse("i am very happy");
            ///Act
            string mood = moodAnalyser.AnalyseMood();
            ///Assert
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// Given the sad mood message as parameter should return SAD.
        /// </summary>
        [TestMethod]
        public void Given_SadMoodMessage_Should_Return_SAD()
        {
            ///Arrange
            string expected = "SAD";
            MoodAnalyse moodAnalyser = new MoodAnalyse("i am very sad");
            ///Act
            string mood = moodAnalyser.AnalyseMood();
            ///Assert
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// Given the null as input should return mood should not be null
        /// </summary>
        /// <param name="message">The message.</param>
        [TestMethod]
        [DataRow(null)]
        public void Given_Null_AsInput_Should_Return_MOOD_SHOULD_NOT_BE_NULL(string message)
        {
            try
            {
                //Arrange
                MoodAnalyse moodAnalyser = new MoodAnalyse(message);
                ///Act
                var mood = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException e)
            {
                ///Assert
                Assert.AreNotEqual("Mood should not be null", e.Message);
            }

        }
        /// <summary>
        /// Given Empty message as input parameter should throw exception as
        /// moos should not be empty
        /// </summary>
        [TestMethod]
        public void GivenEmptyAsInput_ShouldReturnException()
        {
            try
            {
                /// Arrange
                string message = " ";
                ///string expected = "mood should not be empty";
                MoodAnalyse moodAnalyser = new MoodAnalyse(message);
                ///Act
                var mood = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException e)
            {
                ///Assert
                Assert.AreEqual("Mood should not be empty", e.Message);
            }

        }
    }
}
