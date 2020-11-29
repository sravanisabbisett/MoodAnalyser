using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyse
    {
        /// Initialised message as private
        private string message;

        public MoodAnalyse()
        {

        }
        /// <summary>
        ///Constructor Initializes a new instance of the <see cref="MoodAnalyser"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MoodAnalyse(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// Analyses the mood of the person bases on the input message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ENTERED_EMPTY, "Mood should not be empty");
                }

                return this.message.Contains("sad") ? "SAD" : "HAPPY";

            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ENTERED_NULL, "Mood should not be null");
            }
        }

    }
}
