using System;
using System.Collections.Generic;

class Solution
{
    //public static void Main(String[] args)
    //{
    //    m_sourceData = Newtonsoft.Json.JsonConvert.DeserializeObject<ValidationData>("{'States': ['alabama', 'alaska', 'arizona', 'arkansas', 'california', 'colorado', 'connecticut', 'delaware', 'district of columbia', 'florida', 'georgia', 'hawaii', 'idaho', 'illinois', 'indiana', 'iowa', 'kansas', 'kentucky', 'louisiana', 'maine', 'maryland', 'massachusetts', 'michigan', 'minnesota', 'mississippi', 'missouri', 'montana', 'nebraska', 'nevada', 'new hampshire', 'new jersey', 'new mexico', 'new york', 'north carolina', 'north dakota', 'ohio', 'oklahoma', 'oregon', 'pennsylvania', 'rhode island', 'south carolina', 'south dakota', 'tennessee', 'texas', 'utah', 'vermont', 'virginia', 'washington', 'west virginia', 'wisconsin', 'wyoming'],'Cities': ['george', 'george west', 'highland park', 'new york', 'portland', 'san francisco', 'holly view forest', 'holly view forest-highland park', 'minneapolis-saint paul', 'west', 'winston-salem', 'y', 'carmel-by-the-sea']}");
    //    string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
    //    string res;
    //    string inputData = "Minneapolis-Saint-Paul-Minnesota";  //Portland-Oregon
    //    AddUserDefinedTestCities();
    //    res = ParseCityState(inputData);
    //    Console.WriteLine($"Result: {res}");
    //    Console.ReadLine();
    //}

    private class ValidationData
    {
        public HashSet<string> States { get; set; }
        public HashSet<string> Cities { get; set; }
    }

    static ValidationData m_sourceData;

    static void AddValidCity(string city)
    {
        m_sourceData.Cities.Add(city.ToLower());
    }

    static void AddUserDefinedTestCities()
    {
        AddValidCity("Portland");
        AddValidCity("Seattle");
        AddValidCity("New York");
        AddValidCity("Winston-Salem");
        AddValidCity("Minneapolis-Saint Paul");
    }

    static bool ValidateState(string state)
    {
        //this is the full list of all 50 united stats plus district of columbia
        return m_sourceData.States.Contains(state.ToLower());
    }

    /// <summary>
    /// checks the list of valid cities. not case-sensitive
    /// </summary>
    static bool ValidateCity(string city)
    {
        //this is a list of city names including those given in the problem statement and examples
        return m_sourceData.Cities.Contains(city.ToLower());
    }

    enum LocationType
    {
        City,
        State
    }

    static string GetLocationName(LocationType locationType, string[] words, int index)
    {
        // Base Case
        if (index + 1 == words.Length)
        {
            return String.Join("", words);
        }
        bool[] bools = { false, true };
        foreach (var addDash in bools)
        {
            string s = addDash ? "-" : " ";

            if (words[index] != null)
            {
                string word = words[index].Trim();
                words[index] = word + s;

                string name = GetLocationName(locationType, words, index + 1);
                if (ValidateName(locationType, name.Trim()))
                {
                    return name;
                }
            }
        }
        return "";
    }

    static string ParseCityState(string hyphenatedcitystate)
    {
        string[] words = hyphenatedcitystate.Split(new char[] { '-' });

        string[] citySubArray = new string[words.Length];
        string[] stateSubArray = new string[words.Length];

        if (words.Length >= 2)
        {
            for (int index = 0; index < words.Length; index++)
            {
                Array.Copy(words, 0, citySubArray, 0, index + 1);
                string city = GetLocationName(LocationType.City, citySubArray, 0);

                Array.Copy(words, index + 1, stateSubArray, 0, words.Length - index - 1);
                string state = GetLocationName(LocationType.State, stateSubArray, 0);

                if (!String.IsNullOrEmpty(city) && !String.IsNullOrEmpty(state))
                {
                    return city + ", " + state;
                }
            }
        }

        throw new Exception("Invalid Input");
    }

    static bool ValidateName(LocationType locationType, string name)
    {
        if (locationType == LocationType.City && ValidateCity(name) || locationType == LocationType.State && ValidateState(name))
        {
            return true;
        }

        return false;
    }
}