using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reeks07Oefening06
{
    class Program
    {

        //this method checks if the 4th and 5th char represent a correct number to use as minutes in a time format
        static bool CheckLast2CharsForMinuteCompilation(string strTheTime)
        {
            bool blnCheckValue = false;//checkvalue for the minute compilation
            bool blnCheckIfSubstringIsInt; //bool to check if substring is an integer (I try to do this without a try... catch...)
            int intCorrectNumber; //int to put the minutes
            string strMinutes = strTheTime.Substring(3, 2); //substring for the minutes
            blnCheckIfSubstringIsInt = int.TryParse(strMinutes, out int intResult); //false if strMinutes isn't an int / true... if it is

            if (blnCheckIfSubstringIsInt == true) //when the substring is an integer...
            {
                intCorrectNumber = Convert.ToInt32(strMinutes); //put strMinutes in intMinutes

                //check to see if it lays within the 0 - 59 range
                if (intCorrectNumber >= 0 && intCorrectNumber < 60)
                {
                    blnCheckValue = true; //return 'true'
                }

            }

            // all other cases return the 'default' 'false' value
            //return the value
            return blnCheckValue;
        }

        //this method checks if the first 2 characters represent a correct number to use as hours in a timeformat
        static bool CheckFirst2CharsForHourCompilation(string strTheTime)
        {
            bool blnCheckValue = false;
            bool blnCheckIfSubstringIsInt; //bool to check if substring is an integer (I try to do this without a try... catch...)
            int intCorrectNumber;
            string strHours = strTheTime.Substring(0, 2);
            blnCheckIfSubstringIsInt = int.TryParse(strHours, out int intResult); //false if strHours isn't an int / true... if it is

            if (blnCheckIfSubstringIsInt == true) //when the substring is an integer...
            {
                intCorrectNumber = Convert.ToInt32(strHours); //put the string in the integer

                //check to see if it lays within the 0 - 23 range
                if (intCorrectNumber >= 0 && intCorrectNumber < 24)
                {
                    blnCheckValue = true; //return 'true'
                }

            }
            // all other cases return the 'default' 'false' value
            //return the value
            return blnCheckValue;
        }

        //this method asks for input (time in this case. following the HH:mm format)
        static string AskTheTime()
        {
            string strTheTime = "";
            Console.WriteLine("Please enter the time (HH:mm):");
            strTheTime = Console.ReadLine();
            return strTheTime;
        }

        //this method checks if the input is exactly 5 long
        static bool CheckLength(string strTime, int intLength)
        {
            bool blnCheckValue = false; //value to return by default

            if (strTime.Length == intLength) //check if input length is desired length
            {
                blnCheckValue = true; //return tru
            }

            //return value
            return blnCheckValue;
        }

        //This method checks if the 3d char is an ':'
        static bool CheckCharInString(string strInput, int intCharPosition, string strChar)
        {
            bool blnCheckValue = false; //value to return by default

            if (strInput.Substring(intCharPosition - 1, 1) == strChar) //check if char on pos 3 (index 2) is ':'
            {
                blnCheckValue = true;//change value when true
            }

            //return value
            return blnCheckValue;
        }

        //This program asks for the input of time and controls the givven format
        static void Main(string[] args)
        {
            //define a string for the input, a check for the possible errors, a check for the complete set of checks
            //and a string for the errormessage
            string strTime;
            bool blnCheck = true;
            bool blnWrongInput = true;
            string strError = "";

            while (blnWrongInput)
            {
                //Ask the time with input 
                strTime = AskTheTime();
                //first check
                blnCheck = CheckLength(strTime, 5);

                //when the check clears, go to the second check
                if (blnCheck)
                {
                    //second check, when it clears, go to the third check
                    blnCheck = CheckCharInString(strTime, 3, ":");

                    if (blnCheck)
                    {
                        //third check, when it clears, go to the fourth check
                        blnCheck = CheckFirst2CharsForHourCompilation(strTime);

                        if (blnCheck)
                        {
                            //fourth check
                            blnCheck = CheckLast2CharsForMinuteCompilation(strTime);

                            if (blnCheck)
                            {
                                blnWrongInput = false; //exit loop
                                strError = "Thank you"; //error (completion string in this case :))
                            }
                            else //when the check returns false, show the error and try again
                            {
                                strError = "The minutes must be between '00' and '59'";
                            }

                        }
                        else //when the check returns false, show the error and try again
                        {
                            strError = "The hours must be between '00' and '23'";
                        }

                    }
                    else //when the check returns false, show the error and try again
                    {
                        strError = "The third character must be a ':'";
                    }

                }
                else //when the check returns false, show the error and try again
                {
                    strError = "Text must be 5 characters long.";
                }

                //show the error string (or completion string)
                Console.WriteLine(strError);
            }

            Console.ReadLine();
        }
        ///         !!!
        ///         NOTE GB
        ///
        ///         PLAYTIME: 01:30  <-- pun intended
        ///         !!!
    }

}
