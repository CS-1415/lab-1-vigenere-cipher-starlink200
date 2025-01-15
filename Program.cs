using System.Diagnostics;
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
            isValid = TestIsLowercaseLetter(userKey);
        }
        while(!isValid);
        ShiftLetters(userKey, userPhrase);
    }
    public static bool TestIsLowercaseLetter(char letter)
    {
        // Debug.Assert(TestIsLowercaseLetter('a'));
        // Debug.Assert(TestIsLowercaseLetter('b'));
        // Debug.Assert(TestIsLowercaseLetter('z'));
        // Debug.Assert(!TestIsLowercaseLetter('A'));
        // Debug.Assert(!TestIsLowercaseLetter('`'));
        // Debug.Assert(!TestIsLowercaseLetter('{'));
        if(!letter.ToString().ToLower().Equals(letter.ToString()))
            {
                Console.WriteLine("Returned false");
                return false;
            }
        return true;
    }

    static bool IsValidPhrase(string phrase)
    {
        //Debug.Assert(!IsValidPhrase("Your mom is cool"));
        //Debug.Assert(IsValidPhrase("your mom is cool"));
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