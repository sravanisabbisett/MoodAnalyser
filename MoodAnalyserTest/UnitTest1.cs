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
        public void GivenNullAsInput_ShouldReturnCustomexception(string message)
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
                Assert.AreEqual("Mood should not be null", e.Message);
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

        [TestMethod]
        public void GivenMoodAnalyser_className_Should_ReturnMoodAnalyserObject()
        {
            //Arrange
            object expexted = new MoodAnalyse();
            //Act
            object obj = MoodAnalyserFactorcs.CreateMoodAnalyse("MoodAnalyser.MoodAnalyse", "MoodAnalyse");
            //Assert
            expexted.Equals(obj);
        }
          
        [TestMethod]
        public void GivenMoodAnalyser_withImproperClassName_ShouldThrowException()
        {
            try
            {
                //Arrange
                string className = "Demonamespace.MoodAnalyse";
                string constructor = "MoodAnalyse";
                //Act
                object expected = new MoodAnalyse();
                object obj = MoodAnalyserFactorcs.CreateMoodAnalyse(className, constructor);
            }catch(MoodAnalyserException moodAnalyseException)
            {
                //Assert
                Assert.AreEqual("No such class found", moodAnalyseException.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyser_withImproperConstructorName_ShouldThrowException()
        {
            try
            {
                //Arrange
                string className = "MoodAnalyser.MoodAnalyse";
                string constructor = "MoodAnalysee";
                //Act
                object expected = new MoodAnalyse();
                object obj = MoodAnalyserFactorcs.CreateMoodAnalyse(className, constructor);
            }
            catch (MoodAnalyserException moodAnalyseException)
            {
                //Assert
                Assert.AreEqual("No such constructor found", moodAnalyseException.Message);
            }
        }
        /// <summary>
        /// Givens the modd aalyser class name should return mood analyser object using parametrized constructor.
        /// </summary>
        [TestMethod]
        public void GivenModdAalyserClassName_ShouldReturnMoodAnalyserObject_UsingParametrizedConstructor()
        {
            //Arrange
            object excpected = new MoodAnalyse("HAPPY");
            //Act
            object obj = MoodAnalyserFactorcs.CreateMoodAnalyserObjectwithParaMeterizedConstructor("MoodAnalyser.MoodAnalyse", "MoodAnalyse", "HAPPY");
            //Assert
            excpected.Equals(obj);
        }

        [TestMethod]
        public void GivenModdAalyserImproperClassName_ShouldReturnMoodAnalyserObject_ShouldReturnConstructor()
        {
            try
            {
                //Arrange
                object excpected = new MoodAnalyse("sad");
                //Act
                object obj = MoodAnalyserFactorcs.CreateMoodAnalyserObjectwithParaMeterizedConstructor("Demonamespace.MoodAnalyse", "MoodAnalyse", "HAPPY");
                //Assert
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("Class not found", exception.Message);
            }
        }

        [TestMethod]
        public void GivenModdAalyserImproperConstructorName_ShouldReturnMoodAnalyserObject_ShouldReturnConstructor()
        {
            try
            {
                //Arrange
                object excpected = new MoodAnalyse("sad");
                //Act
                object obj = MoodAnalyserFactorcs.CreateMoodAnalyserObjectwithParaMeterizedConstructor("MoodAnalyser.MoodAnalyse", "MoodAnalyseee", "HAPPY");
                //Assert
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("Constructor not found", exception.Message);
            }
        }
    }
}
