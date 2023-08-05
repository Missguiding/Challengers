using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_07._06
{
    // goal of exercise:
    //    In the console you will ask a time as a text in the format “00:00”.
    //o As long as the time is incorrect, show the reason why it is not accepted and re-ask the time.
    //• What must be checked and in what order?
    //o The text is exact 5 characters long.
    //o The third character must be a “:”.
    //o The first 2 digits are between 0 and 23 (borders included).
    //o The last 2 digits are between 0 and 59 (borders included).
    //• Every check is a different method that checks 1 specific criteria.
    //• Every method returns a boolean value.
    //o True, the value is correct.
    //o False, the value is incorrect.
    //• The moment one criteria fail, you show a nice error message and reask until a given time is correct.
    //• 00:0 → Text is must be exactly 5 characters long.
    //• 00:120 → Text is must be exactly 5 characters long.
    //• 00-00 → The separator between hours and minutes must be “:”.
    //• ab:cd → The hours must be between 00 and 23.
    //• 55:55 → The hours must be between 00 and 23.
    //• 10:cd → The minutes must be between 00 and 59.
    //• 10:59 → Thank you

    class Program
    {
        static public void Message(string strAText) // method with 1 parameter - no return - string message
        {
            Console.WriteLine("{0}", strAText); // write you message
        }

        static public (bool, string) FiveCharacktersCheck(string strUsersInput) // method - one parameter - two returns
        {
            bool blnCorrectInput = false;
            string strErrorMessage = "Time input must be exactly 5 characters long."; // message associated with error

            if (strUsersInput.Length != 5) // if the input is not exactly 5 long
            {
                Message(strErrorMessage); // show what is wrong
            }
            else
            {
                blnCorrectInput = true; // otherwise set bool on true 
            }

            return (blnCorrectInput, strUsersInput); // return the value of the bool and usersinput
        }
            static public (bool, string) SeparatorBetween(string strUsersInput) //method - one parameter - two returns
        {
            bool blnCorrectInput = false;
            string strErrorMessage = "The separator between hours and minutes must be “:”"; // message associated with error

            if (strUsersInput.Length < 3 || strUsersInput[2] != ':') // when users input is not correct, third character is not a :
            {
                Message(strErrorMessage); // show what is wrong
            }
            else
            {
                blnCorrectInput = true; // otherwise set bool on true
            }

            return (blnCorrectInput, strUsersInput); // return the value of the bool and usersinput
        }

        static public (bool, string) CheckCorrectHourInput(string strInputTime) //method - one parameter - two returns
        {
            bool blnCorrectTimeInput = false;
            string strErrorMessage = "The hours must be between 00 and 23."; // message associated with error
            try
            {
                int intHourNotation = Int32.Parse(strInputTime.Substring(0, 2)); // make substring of string, take the first 2 and cast in int
                if (!(intHourNotation >= 00 && intHourNotation < 24)) // when the number is not between 0 & 24
                {
                    Message(strErrorMessage); // message associated with error
                }
                else
                {
                    blnCorrectTimeInput = true; // otherwise set bool on true
                }
            }

            catch
            {
                Message(strErrorMessage);
            }


            return (blnCorrectTimeInput, strInputTime); // return the value of the bool and usersinput
        }

        static public (bool, string) CheckCorrectMinuteInput(string strInputTime) //method - one parameter - two returns
        {

            bool blnCorrectTimeInput = false; 
            string strErrorMessage = "The minutes must be between 00 and 59."; // message associated with error

            try
            {
                int intMinuteNotation = Int32.Parse(strInputTime.Substring(3, 2)); // make substring of string, take the last 2 and cast in int
                if (!(intMinuteNotation >= 00 && intMinuteNotation < 60)) // if the number is not between 0 & 60
                {
                    Message(strErrorMessage); // message associated with error
                }

                else
                {
                    blnCorrectTimeInput = true; // otherwise set bool on true
                }

            }
            catch
            {
                Message(strErrorMessage);
            }

            return (blnCorrectTimeInput, strInputTime); // return the value of the bool and usersinput
        }



        static void Main()
        {
            string strQuestion = "Give a time in the format “00:00” please"; // text with your question
            Message(strQuestion); // method to ask question 

            bool blnWrongInput1 = false, blnWrongInput2 = false, blnWrongInput3 = false, blnWrongInput4 = false; //  4 variables to store the outcome

            while (!blnWrongInput1 || !blnWrongInput2 || !blnWrongInput3 || !blnWrongInput4) // as long the outcome of the four are all false reloop the following
            {
                string strUsersInput = Convert.ToString(Console.ReadLine());  // ask trough console and store the outcome in variable
                string strError; // variable to store error

                // use the four methods
                (blnWrongInput1, strError) = FiveCharacktersCheck(strUsersInput); 
                (blnWrongInput2, strError) = SeparatorBetween(strUsersInput);
                (blnWrongInput3, strError) = CheckCorrectHourInput(strUsersInput);
                (blnWrongInput4, strError) = CheckCorrectMinuteInput(strUsersInput);

                if (blnWrongInput1 && blnWrongInput2 && blnWrongInput3 && blnWrongInput4) // if all four booleans are true
                {
                    Console.WriteLine("Thank you"); // show the message
                }
            }                        
            Console.ReadLine();
        }
    }
}

