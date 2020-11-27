using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyse
    {
        public string AnalyseMood(string message)
        {
            return message.Contains("sad") ? "SAD" : "HAPPY";
        }
    }
}
