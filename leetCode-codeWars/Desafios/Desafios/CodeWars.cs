using System.Reflection.PortableExecutable;

namespace Desafios;

internal class CodeWars
{
    public static string PingIt(string str) // Simple Pig Latin
    {
        var splitedStrings = str.Split(" ");
        for (int i = 0; i < splitedStrings.Length; i++)
        {
            if (splitedStrings[i].Length != 1)
            {
                List<char> wordArr = splitedStrings[i].ToList();
                char firstChar = wordArr[0];

                wordArr.Add(firstChar);
                wordArr.RemoveAt(0);

                splitedStrings[i] = new string(wordArr.ToArray()) + "ay";
            }


        }

        return string.Join(" ", splitedStrings);
    }
    public static string[] dirReduc(String[] arr) // Directions Reduction - CodeWars
    {
        List<string> directions = new List<string> { arr[0] };

        for (int i = 1; i < arr.Length; i++)
        {
            if (directions.Count == 0 || directions.Last() == arr[i])
            {
                directions.Add(arr[i]);
            }
            else
            {
                string lastDir = directions.Last();
                int lastDirIdx = directions.Count - 1;

                if (arr[i] == "SOUTH" && lastDir == "NORTH")
                {
                    directions.RemoveAt(lastDirIdx);
                }
                else if (arr[i] == "NORTH" && lastDir == "SOUTH")
                {
                    directions.RemoveAt(lastDirIdx);
                }
                else if (arr[i] == "WEST" && lastDir == "EAST")
                {
                    directions.RemoveAt(lastDirIdx);
                }
                else if (arr[i] == "EAST" && lastDir == "WEST")
                {
                    directions.RemoveAt(lastDirIdx);
                }
                else
                {
                    directions.Add(arr[i]);
                }
            }
        }

        return directions.ToArray();
    }
    public static string GetReadableTime(int seconds)
    {
        int h = 0, m = 0;
        int s = seconds % 60;

        if (seconds >= 3600)
        {
            h = seconds / 3600;
            m = seconds % 3600 / 60;
        }
        else if (seconds >= 60)
        {
            m = seconds / 60;
        }

        return $"{(h < 10 ? "0" + h : h)}:" +
            $"{(m < 10 ? "0" + m : m)}:" +
            $"{(s < 10 ? "0" + s : s)}";
    }
    public static string DuplicateEncode(string word) // Duplicate Encoder
    {
        var wordArr = word.ToLower().ToCharArray();

        Dictionary<char, bool> charRepeat = new Dictionary<char, bool>();

        for (int i = 0; i < wordArr.Length; i++)
        {
            if (charRepeat.ContainsKey(wordArr[i]))
            {
                charRepeat[wordArr[i]] = true;
            }
            else
            {
                charRepeat[wordArr[i]] = false;
            }
        }


        for (int i = 0; i < wordArr.Length; i++)
        {
            if (charRepeat[wordArr[i]] == true)
            {
                wordArr[i] = ')';
            }
            else wordArr[i] = '(';

        }


        return string.Join("", wordArr);
    }
    public static string FisrtNonRepeatingLetter(string s) // First non-repeating character
    {
        if (s.Length == 1) return s;

        char[] charArr = s.ToCharArray();
        char[] charArr2 = s.ToLower().ToCharArray();

        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in charArr2)
        {
            if (charCount.ContainsKey(c)) charCount[c]++;
            else charCount[c] = 0;
        }

        char first = charCount.FirstOrDefault(x => x.Value == 0).Key;
        var firstIndex = Array.IndexOf(charArr2, first);

        if (firstIndex == -1) return "";

        return s.Substring(firstIndex, 1);
    }
    public static string Stat(string s) // Statistics for ab Athletic Association
    {
        if (s == "") return s;

        List<string[]> results = s.Split(",").Select(x => x.Trim().Split("|")).ToList();
        List<int> resultsInSeconds = new List<int>();

        for (int i = 0; i < results.Count; i++)
        {
            int count = 0;
            for (int j = 0; j < results[i].Length; j++)
            {
                if (j == 0)
                    count += int.Parse(results[i][j]) * 3600;
                else if (j == 1)
                    count += int.Parse(results[i][j]) * 60;
                else count += int.Parse(results[i][j]);

            }

            resultsInSeconds.Add(count);
        }

        int rangeSeconds = resultsInSeconds.Max() - resultsInSeconds.Min();
        string rangeFormatedTime = TimeSpan.FromSeconds(rangeSeconds).ToString(@"hh\|mm\|ss");
        string range = $"Range: {rangeFormatedTime}";

        double sum = resultsInSeconds.Average();
        string avarageFormatedTime = TimeSpan.FromSeconds(sum).ToString(@"hh\|mm\|ss");
        string average = $"Average: {avarageFormatedTime}";

        List<int> sort = resultsInSeconds.OrderBy(n => n).ToList();
        double medianInSeconds;

        if (sort.Count() % 2 == 0)
        {
            int mid1 = sort.Count() / 2 - 1;
            int mid2 = sort.Count() / 2;
            medianInSeconds = (double)(sort[mid1] + sort[mid2]) / 2;
        }
        else
        {
            medianInSeconds = sort[sort.Count() / 2];
        }

        string medianFormatedTime = TimeSpan.FromSeconds(medianInSeconds).ToString(@"hh\|mm\|ss");
        string median = $"Median: {medianFormatedTime}";

        return $"{range} {average} {median}";
    }

    public static string ToUnderscore(int str)
    {
        return str.ToString();
    }

    public static string ToUnderscore(string str)
    {
        string snakeCase = str[0].ToString().ToLower();

        for (int i = 1; i < str.Length; i++)
        {
            if (((byte)str[i]) >= 65 && ((byte)str[i]) <= 90)
            {
                var current = "_" + str[i].ToString();
                snakeCase += current;
            }
            else
            {
                snakeCase += str[i].ToString();
            }
        }

        return snakeCase.ToLower();
    }
}
