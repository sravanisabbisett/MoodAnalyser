using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactorcs
    {
        public static object  CreateMoodAnalyse(string classname,string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(classname, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type type = Type.GetType(classname);
                    return Activator.CreateInstance(type);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "No such class found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "No such constructor found");
            }
        }
        
        public static object CreateMoodAnalyserObjectwithParaMeterizedConstructor(string className,string constructorName,string message)
        {
            Type type = typeof(MoodAnalyse);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructor = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }

        public static string InvokeAnalyseMethod(string message,string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyser.MoodAnalyse");
                object moodAnalyseObject = MoodAnalyserFactorcs.CreateMoodAnalyserObjectwithParaMeterizedConstructor("MoodAnalyser.MoodAnalyse", "MoodAnalyse", message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Method is not found");
            }
        }
    }
}


