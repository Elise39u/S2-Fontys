using KillerAppS2DAL;
using KillerAppS2DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace KillerAppS2Interfaces
{
    public static class InvokerClass
    {
        //Source used here
        // https://www.codeproject.com/Articles/19911/Dynamically-Invoke-A-Method-Given-Strings-with-Met

        public static string InvokeStringToMethod (string typeName, string methodName, string stringParam, TemplateDTO templateDTO)
        {
            // Get the Type for the class
            Type calledType = Type.GetType(typeName);
            TemplateDAL templateDAL = new TemplateDAL();

            // Invoke the method itself. The string returned by the method winds up in s.
            // Note that stringParam is passed via the last parameter of InvokeMember,
            // as an array of Objects.

            //Issue --> System.Reflection.TargetException Object does not match target type

            /*
             * var TestData = calledType.GetMethod(methodName);
             string s = (string)calledType.InvokeMember(
                           methodName,
             BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod,
             null, null,
             new object[] { new string[] { stringParam } });
             */
             var TestData = calledType.GetMethod(methodName);
             var s = TestData.Invoke(
                               templateDAL,
                               BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod,
                               null, new object[] {  stringParam, templateDTO },
                               null);

             // Return the string that was returned by the called method.
             return s.ToString();
        }
    }
}
