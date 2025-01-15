using System.Diagnostics;
// Name: Caleb Roskelley
// Project 1 Vigenere Cipher
// Prof Lewellan
// Due Date: 01/15/2025
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello! This program will encrypt custom messages using a encryption key of your choice");
        bool isValid;
        string userPhrase;
        char userKey;
        do
        {
            Console.WriteLine("Please provide your message, only lowercase letters. No symbols.");
            userPhrase = Console.ReadLine();
            isValid = IsValidPhrase(userPhrase);

        }
        while(!isValid);
        do
        {
            Console.WriteLine("Now please provide 1 lowercase letter as an encryption key.");
            userKey = (char) Console.Read();
            isValid = IsLowercaseLetter(userKey);
        }
        while(!isValid);
        ShiftLetters(userKey, userPhrase);
    }

    public static bool IsLowercaseLetter(char letter)
    {
        if(!letter.ToString().ToLower().Equals(letter.ToString()))
            {
                Console.WriteLine("Returned false");
                return false;
            }
        return true;
    }

    static bool IsValidPhrase(string phrase)
    {
        foreach(char letter in phrase)
        {
            if(!letter.ToString().ToLower().Equals(letter.ToString()))
            {
                Console.WriteLine("Returned false");
                return false;
            }
        }
        return true;
    }

    static void ShiftLetters(char key, string phrase)
    {
        int keyValue = (int) key - 97;
        string newPhrase = "";
        foreach(char letter in phrase)
        {
            int letterValue = (int) letter;
            if(letter.Equals(' '))
            {
                newPhrase += " ";
            }
            else
            {
                if(letterValue + keyValue <= 122)
                {
                    newPhrase += (char)(letterValue + keyValue);
                }
                else{
                    newPhrase += (char)(123 - letterValue + keyValue + 97);
                }
            }
        }
        Console.WriteLine(newPhrase);
    }
}