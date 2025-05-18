using System;
using System.Collections.Generic;

class Program
{
    static string OldPhonePad(string input)
    {
        var keypadMapping = new Dictionary<int, string>
        {
            { 1, "&'(" },
            { 2, "abc" },
            { 3, "def" },
            { 4, "ghi" },
            { 5, "jkl" },
            { 6, "mno" },
            { 7, "pqrs" },
            { 8, "tuv" },
            { 9, "wxyz" }
        };

        string result = "";
        int lastKey = -1;
        int pressCount = 0;

        foreach (char ch in input)
        {
            if (char.IsDigit(ch))
            {
                int key = int.Parse(ch.ToString());

                if (key == lastKey)
                {
                    pressCount++;
                }
                else
                {
                    if (lastKey != -1)
                    {
                        string letters = keypadMapping[lastKey];
                        int letterIndex = (pressCount - 1) % letters.Length;
                        result += letters[letterIndex];
                    }
                    lastKey = key;
                    pressCount = 1;
                }
            }
            else if (ch == ' ')
            {
                if (lastKey != -1)
                {
                    string letters = keypadMapping[lastKey];
                    int letterIndex = (pressCount - 1) % letters.Length;
                    result += letters[letterIndex];
                    lastKey = -1;
                    pressCount = 0;
                }
            }
            else if (ch == '*')
            {
                if (lastKey != -1)
                {
                    string letters = keypadMapping[lastKey];
                    int letterIndex = (pressCount - 1) % letters.Length;
                    result += letters[letterIndex];
                    lastKey = -1;
                    pressCount = 0;
                }

                if (result.Length > 0)
                    result = result.Substring(0, result.Length - 1);
            }
            else if (ch == '#')
            {
                if (lastKey != -1)
                {
                    string letters = keypadMapping[lastKey];
                    int letterIndex = (pressCount - 1) % letters.Length;
                    result += letters[letterIndex];
                }
                break;
            }
        }

        return result.ToUpper();
    }

    static void Main()
    {
        Console.WriteLine(OldPhonePad("33#")); // "E"
        Console.WriteLine(OldPhonePad("227*#")); // "B"
        Console.WriteLine(OldPhonePad("4433555 555666#")); // "HELLO"
        Console.WriteLine(OldPhonePad("8 88777444666*664#")); // "TURING"


        Console.WriteLine(OldPhonePad("244623#")); // "AHMAD"
        Console.WriteLine(OldPhonePad("888226633*8#")); // "VBNET"
        Console.WriteLine(OldPhonePad("888226633* 338#")); // "VBNET"

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
