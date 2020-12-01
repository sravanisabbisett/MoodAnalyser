using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactorcs
    {
        /// <summary>
        /// Creates the mood analyse.
        /// </summary>
        /// <param name="classname">The classname.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserException">
        /// No such class found
        /// or
        /// No such constructor found
        /// </exception>
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

        /// <summary>
        /// Creates the mood analyser objectwith para meterized constructor.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserException">
        /// Constructor not found
        /// or
        /// Class not found
        /// </exception>
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

        /// <summary>
        /// Invokes the analyse method.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserException">Method is not found</exception>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static object SetFieldValue(string message, string fieldName, string methodName)
        {
            // Get the type of the class
            Type type = Type.GetType("MoodAnalyser.MoodAnalyse");

            // Create an object of class
            object instance = Activator.CreateInstance(type);

            //Get the field and If the field is not found it throws null exception and if message is empty throw exception
            // catch the exception if thrown
            try
            {
                // Get the field by using reflections
                FieldInfo fieldInfo = type.GetField(fieldName,BindingFlags.Public|BindingFlags.Instance);

                if (message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_FIELD, "Message should not ne null");
                }
                // Get the method using reflection
                MethodInfo method = type.GetMethod(methodName);

                // set the field value of a particular field in particular object
                fieldInfo.SetValue(instance,message);

                // Invoke the method using reflection
                object methodReturn = method.Invoke(instance, null);
                
                return methodReturn;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_FIELD, "Field is not found");
            }
        }

    }
}


