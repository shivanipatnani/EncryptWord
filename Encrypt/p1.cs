/*============================================================================
 * Name        : p1.cs
 * Author      : Shivani
 * Version     : 1.0
 * Copyright   : Your copyright notice
 *
 * ======================= DESCRIPTION ========================================
 * This driver will test all the functionality of the EncryptWord class and allows the user play the guess game.The expectations of
* the functionality are defined below.
 *
 * ======================= HOW TO EXECUTE THIS DRIVER ========================================
 *Tests all the possible conditions and functionality
* You will choose a number between 0 and 7 to perform a specific functionality described below.

* 0) exit the application.

*
* 1) encrypt ->
 * Description : Expect that a valid input is encrypted or the error message is logged to the console.
 * Preconditions : The input word has already passed validation checks and will be encrypted.
 * Postconditions : The length of the encryptedword is the same as the input word.Can be chained with other calls.
 *
 *
 * 2) encryptOFF ->
 * Description : subsequent calls to encrypt will not encrypt the word.
 *
 * 3) encryptON ->
 * Description : subsequent calls to encrypt will continue encrypting the word.This is enabled by default.
 *
 * 4) encryptRESET -> will print the original word to the console and reset the next word to encrypt to the original word.
 * Description : will print the original word to the console and reset the next word to encrypt to the original word.
 *
 * 5) stats ->
 * Description : Shows statistics such as close and distant guesses and average guess value.
 *
 * 6) guessShiftValue ->
 * Description : Take an input guess value and compare it with the shift used for encryption.
 * Assumption : Only non zero numeric numbers are allowed.
 *
 * 7) Enter a new word to create a new EncryptWord object.
 *
 * ======================= INPUT ==============================================
 * VALID INPUT : words made of 4 or more lower case alphabets is considered a valid input.
 *
 * INVALID INPUT :
 * 1) Words with less than 4 characters
 * 2) Words with special characters other than alphabets.
 * If the program receives an invalid input, a runtime exception will be thrown.
 *
 * ======================= EXPECTED FUNCTIONALITY ========================================
 * run all the valid and invalid conditions and start the game by taking the inputs from user
 *

 *============================================================================
 */
using System;

namespace EncryptWord1
{
    public class p1
    {
       
        public static readonly int ALPHABET_COUNT = 26;
        public static void testValidEncryption()
        {
            /**testing valid words with lenght more that 4**/
            int guessWord;
            Console.Write("\n******************Testing Senarios*******************");
            Console.Write("\n");
            var rnd = new Random(5);
            guessWord = rnd.Next();
            EncryptWord encryptValidWord1 = new EncryptWord("abcd", guessWord);
            encryptValidWord1.encrypt();
            /**guess valid word**/

            Console.Write("Attempting cipher shift guess with value ");
            Console.Write(rnd.Next(1) % ALPHABET_COUNT);
            Console.Write("\n");
            encryptValidWord1.guessShiftValue(rnd.Next(1));


            Console.Write("Attempting cipher shift guess with value ");
            Console.Write(rnd.Next(2) % ALPHABET_COUNT);
            Console.Write("\n");
            encryptValidWord1.guessShiftValue(rnd.Next(rnd.Next(2) % ALPHABET_COUNT));


            Console.Write("Attempting cipher shift guess with value ");
            Console.Write(rnd.Next(3) % ALPHABET_COUNT);
            Console.Write("\n");
            encryptValidWord1.guessShiftValue(rnd.Next(3));

            Console.Write("Attempting cipher shift guess with value ");
            Console.Write(guessWord % ALPHABET_COUNT);
            Console.Write("\n");
            encryptValidWord1.guessShiftValue(guessWord % ALPHABET_COUNT);


            encryptValidWord1.stats();

            EncryptWord encryptValidWord2 = new EncryptWord("yzaze", rnd.Next(4));
            encryptValidWord2.encrypt();

            /**large word test**/
            EncryptWord encryptLargeWord = new EncryptWord("thisisavalidwordwithverylongnumberofcharactersanditwillwork", rnd.Next(5));
            encryptLargeWord.encrypt();

            /**testing encryption off***/
            EncryptWord encryptWordOFF = new EncryptWord("testingoff", rnd.Next(0));
            encryptWordOFF.encryptOFF();
            encryptWordOFF.encrypt();

            /**testing encryption on***/
            EncryptWord encryptWordON = new EncryptWord("testingon", rnd.Next(0));
            encryptWordON.encryptON();
            encryptWordON.encrypt();

        }
        /**
         * Test all the  invalid valid functionality of EncryptWord.
         *  multi pass encryption
         */
        public static void testInvalidInputEncryption()
        {
            Console.Write("\n***************Invalid Inputs*******************");
            Console.Write("\n");
            var rnd = new Random(5);
            int caesar_cipher = rnd.Next(5);
            try
            {
                EncryptWord encryptWord = new EncryptWord("h3l* ", caesar_cipher);
                encryptWord.encrypt();
            }
            catch (Exception e)
            {
                Console.Write("Received exception for input h31* ");
                Console.Write(e.Source);
                Console.Write("\n");
            }
            try
            {
                EncryptWord encryptWord = new EncryptWord("12345", caesar_cipher);
                encryptWord.encrypt();
            }
            catch (Exception e)
            {
                Console.Write("Received exception for input 12345 ");
                Console.Write(e.Source);
                Console.Write("\n");
            }
            try
            {
                EncryptWord encryptWord = new EncryptWord("a", caesar_cipher);
                encryptWord.encrypt();
            }
            catch (Exception e)
            {
                Console.Write("Received exception for input a ");
                Console.Write(e.Source);
                Console.Write("\n");
            }

        }
        
        //user inputs
        public static void userInputOption(ref EncryptWord encryptword)
        {
            int inputOption;
            string input;
            var rnd = new Random(5);
            while (true)
            {
                Console.Write("Select an option");
                Console.Write("\n");
                Console.Write("0 --> EXITs the application ");
                Console.Write("\n");
                Console.Write("1 --> ENCRYPT the word  ");
                Console.Write("\n");
                Console.Write("2 --> Turns OFF the encryption  ");
                Console.Write("\n");
                Console.Write("3 --> Turns ON the encryption  ");
                Console.Write("\n");
                Console.Write("4 --> RESET the word to initially given word. ");
                Console.Write("\n");
                Console.Write("5 --> Shows the Statistics of guesses performed.");
                Console.Write("\n");
                Console.Write("6 --> Guess the shift value");
                Console.Write("\n");
                Console.Write("7 --> Enter a new value");
                Console.Write("\n");

                //checking the user inputs and responds according to the selection                
                inputOption = int.Parse(Console.ReadLine());
                switch (inputOption)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        encryptword.encrypt();
                        break;
                    case 2:
                        encryptword.encryptOFF();
                        break;
                    case 3:
                        encryptword.encryptON();
                        break;
                    case 4:
                        encryptword.encryptRESET();
                        break;
                    case 5:
                        encryptword.stats();
                        break;
                    case 6:
                        Console.Write("Guess a value");
                        Console.Write("\n");
                        int guess;
                        guess = int.Parse(Console.ReadLine());
                        encryptword.guessShiftValue(guess);
                        break;
                    case 7:
                        Console.Write("Enter a new word");
                        Console.Write("\n");
                        input = Console.ReadLine();
                        encryptword = new EncryptWord(input, rnd.Next());
                        break;

                    default:
                        Console.Write("Enter proper option");
                        Console.Write("\n");
                        break;
                }
            }
        }

        

    }
}
