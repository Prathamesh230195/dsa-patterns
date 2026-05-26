namespace DSAPatterns.HashMap;

// ============================================================
// PATTERN: HASH MAP / SET
// USE WHEN: Count frequency, fast lookup, find pairs/duplicates
// IDEA: Store elements in dictionary for O(1) access
// ============================================================

public static class HashMapExamples
{
    // -------------------------------------------------------
    // EXAMPLE 1: Two Sum (Unsorted)
    // Problem: Find indices of two numbers summing to target
    // Input: [2,7,4,5], target=9
    // Output: [0, 1]  (2+7=9)
    // -------------------------------------------------------
    public static int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>(); // number → index

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (map.ContainsKey(complement))
                return new[] { map[complement], i };  // 🎉 Found pair!

            map[nums[i]] = i;   // Store for future lookup
        }
        return Array.Empty<int>();
    }

    // -------------------------------------------------------
    // EXAMPLE 2: Group Anagrams
    // Problem: Group strings that are anagrams of each other
    // Input: ["eat","tea","tan","ate","nat","bat"]
    // Output: [["eat","tea","ate"],["tan","nat"],["bat"]]
    // -------------------------------------------------------
    public static List<List<string>> GroupAnagrams(string[] words)
    {
        var map = new Dictionary<string, List<string>>();

        foreach (string word in words)
        {
            // Sort the word → anagrams have same sorted key
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            string key = new(chars);   // "eat" → "aet", "tea" → "aet"

            if (!map.ContainsKey(key))
                map[key] = new List<string>();

            map[key].Add(word);
        }
        return map.Values.ToList();
    }

    // -------------------------------------------------------
    // EXAMPLE 3: Longest Consecutive Sequence
    // Problem: Find longest streak of consecutive numbers
    // Input: [100,4,200,1,3,2]
    // Output: 4  (1,2,3,4)
    // -------------------------------------------------------
    public static int LongestConsecutive(int[] nums)
    {
        var set = new HashSet<int>(nums);
        int maxLen = 0;

        foreach (int num in set)
        {
            // Only start counting from the BEGINNING of a sequence
            if (!set.Contains(num - 1))
            {
                int current = num;
                int streak = 1;

                while (set.Contains(current + 1))
                {
                    current++;
                    streak++;
                }
                maxLen = Math.Max(maxLen, streak);
            }
        }
        return maxLen;
    }

    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n╔══════════════════════════════════╗");
        Console.WriteLine("║   🗂️  HASH MAP PATTERN            ║");
        Console.WriteLine("╚══════════════════════════════════╝\n");
        Console.ResetColor();

        Console.WriteLine("📌 Example 1: Two Sum");
        int[] result = TwoSum(new[] { 2, 7, 4, 5 }, 9);
        Console.WriteLine($"   Array: [2,7,4,5], target=9");
        Console.WriteLine($"   Indices: [{result[0]}, {result[1]}] ✅\n");

        Console.WriteLine("📌 Example 2: Group Anagrams");
        var groups = GroupAnagrams(new[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        Console.WriteLine($"   Input: [eat,tea,tan,ate,nat,bat]");
        foreach (var g in groups)
            Console.WriteLine($"   Group: [{string.Join(", ", g)}]");
        Console.WriteLine("   ✅\n");

        Console.WriteLine("📌 Example 3: Longest Consecutive Sequence");
        int seq = LongestConsecutive(new[] { 100, 4, 200, 1, 3, 2 });
        Console.WriteLine($"   Array: [100,4,200,1,3,2]");
        Console.WriteLine($"   Longest streak: {seq} ✅\n");
    }
}
