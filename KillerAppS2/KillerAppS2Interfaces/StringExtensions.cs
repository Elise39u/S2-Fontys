using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace KillerAppS2Interfaces
{
    public class StringExtensions
    {
        //Source used here
        // https://www.codeproject.com/Articles/19911/Dynamically-Invoke-A-Method-Given-Strings-with-Met

        public static string InvokeStringToMethod (string typeName, string methodName, string stringParam)
        {
            // Get the Type for the class
            Type calledType = Type.GetType(typeName);

            // Invoke the method itself. The string returned by the method winds up in s.
            // Note that stringParam is passed via the last parameter of InvokeMember,
            // as an array of Objects.
            String s = (String)calledType.InvokeMember(
                            methodName,
                            BindingFlags.InvokeMethod | BindingFlags.Public |
                                BindingFlags.Static,
                            null,
                            null,
                            new Object[] { stringParam });

            // Return the string that was returned by the called method.
            return s;
        }
    }
}
