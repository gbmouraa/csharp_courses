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
    public static string[] dirReduc(String[] arr) // Directions Reduction - não passa  em todos testes ainda*
    {

        Dictionary<string, int> y = new Dictionary<string, int> { { "NORTH", 0 }, { "SOUTH", 0 } };
        Dictionary<string, int> x = new Dictionary<string, int> { { "WEST", 0 }, { "EAST", 0 } };

        foreach (string s in arr)
        {
            if (s == "NORTH" || s == "SOUTH") y[s]++;
            else x[s]++;
        }

        if (y["NORTH"] == y["SOUTH"] && x["WEST"] == x["EAST"]) return arr;

        Dictionary<string, int> filteredXAndY = new Dictionary<string, int>();

        if (y["NORTH"] != y["SOUTH"])
        {
            Dictionary<string, int> filteredY = new Dictionary<string, int>();
            var dir = y.MaxBy(y => y.Value).Key;
            filteredXAndY.Add(dir, y[dir]);
        }

        if (x["WEST"] != x["EAST"])
        {
            Dictionary<string, int> filteredX = new Dictionary<string, int>();
            var dir = x.MaxBy(x => x.Value).Key;
            filteredXAndY.Add(dir, x[dir]);
        }

        if (filteredXAndY.Count == 1) return [filteredXAndY.ElementAt(0).Key];

        return [filteredXAndY.MaxBy(x => x.Value).Key];
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
}
