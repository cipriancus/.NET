using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsProject.Class
{
    public class Palindrome
    {
        public static Boolean check(string array)
        {
            if (array == null)
                throw new ArgumentNullException();

            char[] palindromCharArray = array.ToCharArray();
            Array.Reverse(palindromCharArray);
            string reversePalindrom = new string(palindromCharArray);

            if (reversePalindrom.Equals(array))
                return true;
            else
                return false;
        }
    }
}