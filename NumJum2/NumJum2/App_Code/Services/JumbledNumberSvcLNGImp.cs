using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NumJum2.Domain;
using System.IO;


namespace NumJum2.Services
{
    public class JumbledNumberSvcLNGImp : IJumbledNumberSvc
    {
        public int GetJumbledNumber(JumbledNumber NumJumObj, int difficulty)
        {
            Random random = new Random();
            int numDigits = 0,
                curDigitCount = 0,
                placeHolder = 1;
            long buildNumber = 0,
                jumbledNumber = 0;

            // Generte a unique random number, with size determined by difficulty
            // Must build number in pieces based on length

            // Use switch to determine actual number of digits

            switch (difficulty)
            {
                case 0:
                    numDigits = random.Next(3,5);
                    break;
                case 1:
                    numDigits = random.Next(4,7);
                    break;
                case 2:
                    numDigits = random.Next(6,9);
                    break;
            }

            // Use for loops and if statements to generate unique number

            bool testDigit = true;
            ArrayList holdDigits = new ArrayList();
            
            for (int i = 0; i < numDigits; i++)
            {
                // Build number digit by digit
                // Make sure each digit is unique
                do
                {
                    buildNumber = random.Next(0,9);
                    testDigit = true;

                    // If first run through, add initial entry to holdDigit
                    if (curDigitCount == 0)
                        holdDigits.Add(buildNumber);
                

                    for (int j = 0; j < curDigitCount; j++)
                    {
                        if (buildNumber == (long)holdDigits[j])
                        {
                            testDigit = false;
                        }
                        else
                        {
                            if (testDigit == true)
                            {
                                testDigit = true;
                            }
                            else
                                testDigit = false;
                        }
                    }

                } while (testDigit == false);

                // Store unique digit
                if (curDigitCount > 0)
                    holdDigits.Add(buildNumber);
  
                // Increment digit counter
                curDigitCount++;

                // If digit is not 0 update Jumbled Number
                // Skipping over 0 allows for internal digits to have the
                // value of 0
                if (buildNumber != 0)
                    jumbledNumber = (buildNumber * placeHolder) + jumbledNumber;
              
                // Increment place holder
                placeHolder *= 10;
            }

            // Handle case of first digit being 0
            // Valid numbers cannot start with 0, compensate
            // by decreasing the appropriate counts
            if ((numDigits == curDigitCount) && (buildNumber == 0))
            {
                numDigits--;
                curDigitCount--;
            }

            // Store values in class
            NumJumObj.JNumberValue = jumbledNumber;
            NumJumObj.NumDigits = numDigits;

            // Return number of digits stored......
            return curDigitCount;
        }

        public bool GetGameStatus(JumbledNumber NumJum)
        {
            return NumJum.GameInProgress;
        }
    }
}
