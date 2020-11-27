using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyse
    {
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyse"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MoodAnalyse(string message)
        {
            this.message = message;
        }


        /// <summary>
        /// Analyses the given mood shoud return the mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public string AnalyseMood(string message)
        {
            try
            {
                return message.Contains("sad") ? "SAD" : "HAPPY";
            }
            catch (NullReferenceException)
            {
                return "HAPPY";
            }
        }
    }
}
