

public class SlidingWindow
{
    public int LengthOfLongestSubstring(string s)
    {

        char[] Input = s.ToCharArray();
        int min_length = s.Length;
        List<Char> set = new List<char>();
        //start points to the start of sub string in List
        //end points to the end of the sub string in List
        //current_min points to the length of the longest sub string
        int start = 0, end = 0, result = 0;

        //repeat the loop untill the end of string
        while (end < Input.Length)
        {
            if (!set.Contains(Input[end]))
            {
                //add to list if it does not contain the char
                set.Add(Input[end++]);
                result = Math.Max(result, set.Count());
            }
            else
            {
                //remove from the list if it contain the char
                set.Remove(Input[start++]);
            }
        }
        return result; //return the length of the longest sub string
    }

}
public class Program
{
    public static void Main(string[] args)
    {
        SlidingWindow s = new SlidingWindow();
        Console.WriteLine("Enter the Input String ");
        string input = Console.ReadLine();
        int output = s.LengthOfLongestSubstring(input);
        Console.WriteLine("Length of the longest sub string is " + output);

    }
}
