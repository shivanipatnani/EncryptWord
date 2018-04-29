/*============================================================================
// Name        : EncryptWord.cs
// Author      : Shivani Patnani
// Version     : 1.0
// Copyright   : Your copyright notice
* ======================= DESCRIPTION ========================================
* The EncryptWord class takes an input word and a cipher value.It encrypts the word in the following manner.
*
* SAMPLE :
* With a shift of ‘3’, for example, the letter ‘a’ will be encrypted as ‘d’; ‘b’ encrypted as ‘e’, … ,‘w’ as
* 'z’, ‘x’ as ‘a’, ‘y’ as ‘b’ and ‘z’ as ‘c’.
* Given word "abcd"  and a cipher 3 : the output will be "defg".
*
* ======================= SUPPORTED FUNCTIONALITY ========================================
* encrypt ->
* Description : Expect that a valid input is encrypted or the error message is logged to the console.
*
* encryptON ->
* Description : subsequent calls to encrypt will continue encrypting the word.This is enabled by default.

* encryptOFF ->
* Description : subsequent calls to encrypt will not encrypt the word.
*
* guessShiftValue ->
* Description : Take an input guess value and compare it with the shift used for encryption.
*
* encryptRESET ->
* Description : will print the original word to the console and reset the next word to encrypt to the original word.
*
* stats -> print a series of stats with number of high, low guesses and mean guess value.
*
* ======================= ASSUMPTIONS ============================================
* Only Lower case alphabets are used.Even if Capital case letters are passed, they are converted to lowercase
* and encrypted.
*
* Cipher value is any valid positive integer between 1 and integer max value.
*
* All outputs are printed to the console.
* Incase of illegal input runtime error is thrown.
*
* ======================= POSSIBLE STATES ========================================
* Given a string inputword and an integer cipher -> there are the following potential states
* Invalid inputword -> runtime error is thrown.
* EncryptWord -> encrypt() -> EncryptedState
* EncryptedState -> encrypt() -> EncryptedState
* EncryptedState -> encryptOFF() -> EncryptedState
* EncryptedState -> encryptON() -> EncryptedState
* EncryptedState -> encryptRESET() -> EncryptWord(originalstate)
* EncryptWord -> guessShiftValue() -> EncryptWord
* EncryptedState -> guessShiftValue() -> EncryptedState
*
* Description: 
* "For each class, a concise overview of the class, its functionality,
* legal states, any dependencies, anticipated use.Define data processed.
* Document what is legal input, illegal input, what output is given."
*
*============================================================================
=============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Linq;

public class EncryptWord
{
    /**
	 * Create an instance of EncryptWord with input word and assign the cipher shift.
	 * string : The word to be encrypted.
	 * int : the cipher shift to be used by this object.
	 * Acceptable Input : words formed using alphabets are valid.
	 * Invalid Input : Words with length less than 4, words with special characters.
	 * Assumptions : All alphabets are converted to lower case and then encrypted.
	 * If the input is invalid throws new Runtime Exception.
	 */
    string encryptedWord;
    bool isEncryptionEnabled = true;
    int meanGuess, numOfGuess, minGuess, maxGuess, tempcipherShift;
    const int LOWER_BOUND = 10;
    const int ALPHABET_COUNT = 26;
    const char FINAL_ALPHABET = 'z';

    //word length will be checked
    public EncryptWord(string word, int cipherShift)
    {
        if (word.Length < 4)
        {
            throw new System.Exception("Invalid word " + word + ". Please enter a valid word with atleast 4 charecters.");
        }
        for (int i = 0; i < word.Length; ++i)
        {
            if (!Char.IsLetter(word[i]))
            {
                throw new System.Exception("Input contains special characters. Please enter a word with alphabets only");

            }
        }
        this.word = word;
        encryptedWord = "";
        this.cipherShift = cipherShift % ALPHABET_COUNT;
        meanGuess = 0;
        numOfGuess = 0;
        minGuess = 0;
        maxGuess = 0;
        tempcipherShift = 0;
    }

    /**
	 * Encrypt the word with the encryption functionality.
	 * returns the encrypted string.
	 */

    /**
	 * Description : Shift each character in the word by the given cipher shift.
	 * If encryption is turned off, no encryption is performed.
	 */

    public string encrypt()
    {
        if (isEncryptionEnabled == false)
        {
            printMessage("The encrypted word is::" + encryptedWord);
            return encryptedWord;
        }

        string word = this.word;
        if (!string.IsNullOrEmpty(encryptedWord))
        {
            word = encryptedWord;
        }
       
        for (int i = 0; i < word.Length; ++i)
        {

            if (word[i] + cipherShift <= FINAL_ALPHABET)
            {
                encryptedWord = word[i] + Convert.ToString(cipherShift);
               

            }
            else
            {
                encryptedWord = word[i] + Convert.ToString(cipherShift - ALPHABET_COUNT);
                

            }
        }
        printMessage("The encrypted word of '" + word + "' is::" + encryptedWord);
        encryptedWord = encryptedWord.ToLower();
        return encryptedWord;
    }

    //It prints the messages in the output console
    public void printMessage(string message)
    {
        Console.Write(message);
        Console.Write("\n");
    }

    /**
	 * Compare the input with the original cipher value.
	 * int : the guessed shift value.
	 * returns if the guessed value is true or false.
	 */

    /**
	 * Description : Evaluate the guessed shift value and determine if
	 * the guessed value is a close guess or a far guess. If the difference
	 * between the actual shift and the guess value is less than the Lower Bound
	 * of 10, the guess is a highGuess or it is a low guess.
	 */
    public bool guessShiftValue(int guess_shift_value)
    {
        bool returnValue = false;
        string message;
        numOfGuess++;
        tempcipherShift += cipherShift;
        int guessRange = Math.Abs(cipherShift - guess_shift_value);
        if (guessRange <= LOWER_BOUND)
        {
            maxGuess++;
            message = "You are close keep guessing!!!";
            if (guessRange == 0)
            {
                message = "You guessed correctly. Congrats!!!";
                returnValue = true;
            }
        }
        else
        {
            message = "Better Luck Next Time!!!";
            minGuess++;
        }
        Console.Write(message);
        Console.Write("\n");
        return returnValue;
    }

    /**
	 * Enable encryption for the word.
	 */
    public void encryptOFF()
    {
        printMessage("Encryption is Turned OFF");
        isEncryptionEnabled = false;
    }

    /**
	 * Disable encryption for the word.
	 */
    public void encryptON()
    {
        printMessage("Encryption is Turned ON");
        isEncryptionEnabled = true;
    }

    /**
	 * Reset word to the original passed word.
	 */
    public void encryptRESET()
    {
        encryptedWord = this.word;
        printMessage("Encryption is has been RESET to::" + encryptedWord);
    }

    /**
	 * Print statistics associated with cipher shift guesses.
	 */
    public void stats()
    {
        if (numOfGuess > 0)
        {
            meanGuess = tempcipherShift / numOfGuess;

        }
        else
        {
            meanGuess = 0;
        }
        Console.Write("****Statistics of the guesses****");
        Console.Write("\n");
        Console.Write("Number of guess ::");
        Console.Write(numOfGuess);
        Console.Write("\n");
        Console.Write("Number of high guess ::");
        Console.Write(maxGuess);
        Console.Write("\n");
        Console.Write("Number of low guess ::");
        Console.Write(minGuess);
        Console.Write("\n");
        Console.Write("Number of Average guess ::");
        Console.Write(meanGuess);
        Console.Write("\n");
        Console.Write("************************************");
        Console.Write("\n");

    }


    private string word;
    private int cipherShift;
}