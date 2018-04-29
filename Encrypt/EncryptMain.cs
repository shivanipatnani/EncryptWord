/*============================================================================
 * Name        : driver.cs
 * Author      : Shivani
 * Version     : 1.0
 * Copyright   : Your copyright notice
 *
 * ======================= DESCRIPTION =======================================
 * The Main file contains the control to the execution for the driver.
 *
 * ======================= HOW THIS MAIN WORKS ========================================
 *The Main file will execute the driver when the application is executed.
 *
 *============================================================================
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Encrypt
{
  public class EncryptMain
    {
        public static void Main()
        { 
            var rnd = new Random(5);
            int caesar_cipher = rnd.Next(5);
            EncryptWord1.driver.testValidEncryption();
            EncryptWord1.driver.testInvalidInputEncryption();
            string input;
            Console.Write("\n******************READY TO PLAY THE WORD GUESSING GAME ??*****************");
            Console.Write("\n");
            label:
            Console.Write("Enter word to be encrypted");
            Console.Write("\n");
            input = Console.ReadLine();
            try
            {
                EncryptWord encryptWord = new EncryptWord(input, caesar_cipher);
                EncryptWord1.driver.userInputOption(ref encryptWord);
            }
            catch (Exception e)
            {
                Console.Write("Received exception :: ");
                Console.Write(e.Source);
                Console.Write("\n");
                goto label;
            }
            
           

        }
    }
}
