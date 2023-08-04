// Creator = DV
// Date of creation = 04/08/2023
// Version = 1

/* Discription: 
    • In the console you will ask a time as a text in the format “00:00”.
       o As long as the time is incorrect, show the reason why it is not accepted and re-ask the time.
    • What must be checked and in what order?
        o The text is exact 5 characters long.
        o The third character must be a “:”.
        o The first 2 digits are between 0 and 23 (borders included).
        o The last 2 digits are between 0 and 59 (borders included).
    • Every check is a different method that checks 1 specific criteria.
    • Every method returns a boolean value.
        o True, the value is correct.
        o False, the value is incorrect.
  • The moment one criteria fail, you show a nice error message and re-ask until a given time is correct.
 */

// Update
// Date of update = ../../....
// Description of update = ...

/* using methods
 * blnCheckHours()
 * blnCheckLenght()
 * blnCheckMinutes()
 * blnCheckSeparator()
 */

using System;

namespace Exercise_07._06
{
  class Program
  {

    static void Main()
    // When starting the console, the "false" value will cause the time to be prompted in a format of "00:00".
    // The user is given the opportunity to make a time entry in a form of a text.
    // The time goes through the first method.There it is checked for the correct length.This returns a value: "true" or "false."
    // If a "true" value, the intCorrectChecks is incremented by 1.
    // Then the time passes through the second method.There it is checked for the correct separator.This returns a value: "true" or "false".
    // If a "true" value is returned the intCorrectChecks is incremented by 1.
    // Then the time passes through the third method. There it is checked for correct entry of hours. This returns a value: "true" or "false".
    // If a "true" value is returned the intCorrectChecks is incremented by 1.
    // Then the time passes through the fourth method. There it is checked for correct entry of minutes. This returns a value: "true" or "false".
    // If a "true" value is returned the intCorrectChecks is incremented by 1.
    // The correct checks are compared to the number of checks.
    // If there is an error somewhere the question is asked again.
    {
      string strTime; // Variable time for user time entry.
      bool blnCorrectCheck = false; // Variable for checking accuracy.

      while (!blnCorrectCheck) // If the a false check repeat the loop.
      {
        try
        {
          int intCorrectChecks = 0; // Set de variable to 0.
          int intNumberOfChecks = 4; // Number of checks in the loop.
          Console.WriteLine("Give a time in the format “00:00”."); // Show the message to the user.
          strTime = Console.ReadLine(); // Let the user enter the time and put it in the variable.                    
          blnCorrectCheck = blnCheckLength(strTime); // Check the Lenght of the time and return a boolean.
          if (blnCorrectCheck) // When the check is correct increase intCorrectCheck by 1.
          {
            ++intCorrectChecks;
          }
          blnCorrectCheck = blnCheckSeparator(strTime); // Check the Separator of the time and return a boolean.
          if (blnCorrectCheck) // When the check is correct increase intCorrectCheck by 1.
          {
            ++intCorrectChecks;
          }
          blnCorrectCheck = blnCheckHours(strTime); // Check the Hours of the time and return a boolean.
          if (blnCorrectCheck) // When the check is correct increase intCorrectCheck by 1.
          {
            ++intCorrectChecks;
          }
          blnCorrectCheck = blnCheckMinutes(strTime); // Check the Minutes of the time and return a boolean.
          if (blnCorrectCheck) // When the check is correct increase intCorrectCheck by 1.
          {
            ++intCorrectChecks;
          }
          if (intCorrectChecks < intNumberOfChecks) // Compare the number of correct checks and the number of checks.
          {
            blnCorrectCheck = false;
          }
        }
        catch
        {
          blnCorrectCheck = false;
        }
      }

      if (blnCorrectCheck) // When everything is correct, say: Thank You.
      {
        Console.WriteLine("Thank you");
      }
      Console.ReadLine();
    }

    #region Methods

    static bool blnCheckHours(string strText)
    // Method checks the hours of the specified time.
    // The hours of time are put into a variable.
    // The variable of time is converted to an integer.
    // If this fails, a message is displayed and a "false" value is added to the variable "blnCorrectHours". 
    // If the conversion is successful, the following steps are performed.
    // This variable is compared with the predefined hours "intHoursMin" and "intHoursMax".
    // If they are less than "intHoursMin" or greater than "intHoursMax", a message is displayed and a "false" value is added to the variable "blnCorrectHours".
    // If the hours are equal or in between, the value "true" is added to the variable "blnCorrectHours".
    // Return the value of the variable "blnCorrectHours".
    {
      int intHoursMin = 00; // Variable of minimum hours.
      int intHoursMax = 23; // Variable of maximum hours.
      bool blnCorrectHours; // Variable for the correct hours.
      string strMessage = "The hours must be between" + intHoursMin + " and " + intHoursMax + " ."; // Varibale of message displayed if false.
      string strTimeHours; // Variable for the hours of time.
      strTimeHours = strText.Substring(0, 2); // The value of the first two characters of time is put into the variable.
      int intTimeHours = 00; // Variable for the hours of time.
      try
      {
        intTimeHours = Convert.ToInt32(strTimeHours); // The variable of time is converted to an integer.
        if (intTimeHours < intHoursMin || intTimeHours > intHoursMax) // This variable is compared with the predefined hours "intHoursMin" and "intHoursMax".
        {
          blnCorrectHours = false; // Put "false" value into the variable.
          Console.WriteLine(strMessage); // Show the message.
        }
        else
        {
          blnCorrectHours = true; // Put "true" value into the variable.
        }
      }
      catch
      {
        blnCorrectHours = false; // Put "false" value into the variable.
        Console.WriteLine(strMessage); // Show the message.
      }

      return blnCorrectHours; // Return "true" or "false".
    }

    static bool blnCheckLength(string strText)
    // Method checks the length of the specified time.
    // The length of time is plugged into a variable.
    // This variable is compared to the predefined length of time "intTextLenght".
    // If they do not match show a message and put "false" value into the variable "blnCorrectLenght".
    // If equal insert "true" value into the variable "blnCorrectLenght".
    // Return the value the variable "blnCorrectLenght".
    {
      int intTimeTextLength; // Variable for the length of time.
      int intTextLength = 5; // Variable for length. 
      bool blnCorrectLenght; // Variable for the correct length.
      string strMessage = "Text is must be exactly " + intTextLength + " characters long."; // Varibale of message displayed if false.

      intTimeTextLength = strText.Length; // The length of time is put into the variable.

      if (intTimeTextLength != intTextLength) // Comparison of the length of time with the requested length.
      {
        blnCorrectLenght = false; // Put "false" value into the variable.
        Console.WriteLine(strMessage); // Show the message.
      }
      else
      {
        blnCorrectLenght = true; // Put "true" value into the variable.
      }

      return blnCorrectLenght; // Return "true" or "false".
    }

    static bool blnCheckMinutes(string strText)
    // Method checks the minutes of the specified time.
    // The minutes of time are put into a variable.
    // The variable of time is converted to an integer.
    // If this fails, a message is displayed and a "false" value is added to the variable "blnCorrectMinutes". 
    // If the conversion is successful, the following steps are performed.
    // This variable is compared with the predefined hours "intMinutesMin" and "intMinutesMax".
    // If they are less than "intMinutesMin" or greater than "intMinutessMax", a message is displayed and a "false" value is added to the variable "blnCorrectMinutes".
    // If the hours are equal or in between, the value "true" is added to the variable "blnCorrectMinutes".
    // Return the value of the variable "blnCorrectMinutes".
    {
      int intMinutesMin = 00; // Variable of minimum minutes.
      int intMinutesMax = 59; // Variable of maximum minutes.
      bool blnCorrectMinutes; // Variable for the correct minutes.
      string strMessage = "The minutes must be between" + intMinutesMin + " and " + intMinutesMax + " ."; // Varibale of message displayed if false.
      string strTimeMinutes; // Variable for the minutes of time.
      strTimeMinutes = strText.Substring(3, 2); // The value of the last two characters of time is put into the variable.
      int intTimeMinutes = 00; // Variable for the minutes of time.
      try
      {
        intTimeMinutes = Convert.ToInt32(strTimeMinutes); // The variable of time is converted to an integer.
        if (intTimeMinutes < intMinutesMin || intTimeMinutes > intMinutesMax) // This variable is compared with the predefined hours "intMinutesMin" and "intMinutesMax".
        {
          blnCorrectMinutes = false; // Put "false" value into the variable.
          Console.WriteLine(strMessage); // Show the message.
        }
        else
        {
          blnCorrectMinutes = true; // Put "true" value into the variable.
        }
      }
      catch
      {
        blnCorrectMinutes = false; // Put "false" value into the variable.
        Console.WriteLine(strMessage); // Show the message.
      }

      return blnCorrectMinutes; // Return "true" or "false".
    }

    static bool blnCheckSeparator(string strText)
    // Method checks the separator of the specified time.
    // The separator of time is plugged into a variable.
    // This variable is compared to the predefined separator of time "strSeparator".
    // If they do not match show a message and put "false" value into the variable "blnCorrectSeparator".
    // If equal insert "true" value into the variable "blnCorrectSeparator".
    // Return the value the variable "blnCorrectSeparator".
    {
      string strSeparator = ":"; // Variable of the separator. 
      bool blnCorrectSeparator; // Variable for the correct length.
      string strMessage = "The separator between hours and minutes must be “" + strSeparator + "”."; // Varibale of message displayed if false.
      string strTimeSeparator; // Variable for the separator of time.
      strTimeSeparator = strText.Substring(2, 1);  // The value of the third character of time is put into the variable.

      if (strTimeSeparator != strSeparator)  // Comparison of the separator of time with the requested separator.
      {
        blnCorrectSeparator = false; // Put "false" value into the variable.
        Console.WriteLine(strMessage);  // Show the message.
      }
      else
      {
        blnCorrectSeparator = true; // Put "true" value into the variable.
      }

      return blnCorrectSeparator; // Return "true" or "false".
    }

    #endregion
  }
}
