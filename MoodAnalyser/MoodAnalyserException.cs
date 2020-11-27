using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserException:Exception
    {
        /// <summary>
        /// Its Takes the Exception type
        /// </summary>
        public enum ExceptionType
        {
            ENTERED_EMPTY,ENTERED_NULL
        }
        
        ExceptionType exceptionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyserException"/> class.
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <param name="message">The message.</param>
        public MoodAnalyserException(ExceptionType exceptionType,string message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
