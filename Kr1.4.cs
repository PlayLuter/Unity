using System;
using System.Collections.Generic;

class MorseCode
{
    private static Dictionary<char, string> morseAlphabet = new Dictionary<char, string>
    {
        {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."},
        {'E', "."}, {'F', "..-."}, {'G', "--."}, {'H', "...."},
        {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
        {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."},
        {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
        {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
        {'Y', "-.--"}, {'Z', "--.."},
        {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"},
        {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."},
        {'8', "---.."}, {'9', "----."},
        {' ', "/"}
    };

    private static Dictionary<string, char> reverseMorseAlphabet = new Dictionary<string, char>();

    static MorseCode()
    {
        foreach (var pair in morseAlphabet)
        {
            reverseMorseAlphabet[pair.Value] = pair.Key;
        }
    }

    public static string Encode(string plainText)
    {
        string encoded = "";
        foreach (char c in plainText.ToUpper())
        {
            if (morseAlphabet.ContainsKey(c))
            {
                encoded += morseAlphabet[c] + " ";
            }
        }
        return encoded.Trim();
    }

    public static string Decode(string morseCode)
    {
        string decoded = "";
        foreach (string code in morseCode.Split(' '))
        {
            if (reverseMorseAlphabet.ContainsKey(code))
            {
                decoded += reverseMorseAlphabet[code];
            }
            else if (code == "/")
            {
                decoded += " ";
            }
        }
        return decoded;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string textToEncode = Console.ReadLine();
        string encodedText = MorseCode.Encode(textToEncode);
        Console.WriteLine($"Encoded: {encodedText}");

        string morseToDecode = encodedText; // используем ранее зашифрованный текст
        string decodedText = MorseCode.Decode(morseToDecode);
        Console.WriteLine($"Decoded: {decodedText}");
        Console.ReadLine();
    }
}

