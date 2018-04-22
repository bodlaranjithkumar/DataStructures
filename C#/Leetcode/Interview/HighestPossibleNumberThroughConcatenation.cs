namespace LeetcodeSolutions.Interview
{
    public class HighestPossibleNumberThroughConcatenation
    {
        // Form the highest possible number from array of numbers.
        static string Concatenate(string[] arr)
        {
            if (arr == null || arr.Length == 0)
                return "";

            // Sort in descending order
            // Reference: https://stackoverflow.com/questions/16331850/array-sort-in-with-nontrivial-comparison-function
            System.Array.Sort(arr, (str1, str2) =>
            {
                return (str2 + str1).CompareTo(str1 + str2);
            });

            string res = string.Join("", arr);

            if (string.IsNullOrEmpty(res) || res[0] == '0')
                return "0";

            return res;
        }
    }
}
