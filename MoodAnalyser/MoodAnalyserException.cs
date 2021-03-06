﻿using System;
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
            ENTERED_EMPTY,ENTERED_NULL,NO_SUCH_CLASS,NO_SUCH_METHOD,NO_SUCH_FIELD,NULL_MESSAGE
        }
        
        ExceptionType exceptionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyserException"/> class.
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <param name="message">The message.</param>
        public MoodAnalyserException(ExceptionType exceptionType,string message):base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
