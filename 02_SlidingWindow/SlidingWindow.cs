namespace DSAPatterns.SlidingWindow;

// ============================================================
// PATTERN: SLIDING WINDOW
// USE WHEN: Subarray/substring problems, contiguous elements
// IDEA: Move a "window" across array, add right / remove left
// ============================================================

public static class SlidingWindowExamples
{
    // -------------------------------------------------------
    // EXAMPLE 1: Max Sum Subarray of Size K
    // Problem: Find the maximum sum of k consecutive elements
    // Input: [2, 1, 5, 1, 3, 2], k=3
    // Output: 9  (subarray [5, 1, 3])
    // -------------------------------------------------------
    public static int MaxSumSubarray(int[] arr, int k)
    {
        int windowSum = 0;

        // Build first window
        for (int i = 0; i < k; i++)
            windowSum += arr[i];

        int maxSum = windowSum;

        // Slide the window: add right element, remove left element
        for (int i = k; i < arr.Length; i++)
        {
            windowSum += arr[i];         // Add new right element
            windowSum -= arr[i - k];     // Remove old left element
            maxSum = Math.Max(maxSum, windowSum);
        }
        return maxSum;
    }

    // -------------------------------------------------------
    // EXAMPLE 2: Longest Substring Without Repeating Characters
    // Problem: Find length of longest substring with no repeats
    // Input: "abcabcbb"
    // Output: 3  ("abc")
    // -------------------------------------------------------
    public static int LongestUniqueSubstring(string s)
    {
        var seen = new HashSet<char>();
        int left = 0;
        int maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            // Shrink window from left until no duplicate
            while (seen.Contains(s[right]))
            {
                seen.Remove(s[left]);
                left++;
            }

            seen.Add(s[right]);
            maxLen = Math.Max(maxLen, right - left + 1);
        }
        return maxLen;
    }

    // -------------------------------------------------------
    // EXAMPLE 3: Maximum Fruits in Two Baskets
    // Problem: Pick max fruits using only 2 types of fruit
    // Input: ['A','B','C','B','B','C']
    // Output: 5 (B,C,B,B,C — two types only)
    // -------------------------------------------------------
    public static int FruitsIntoBaskets(char[] fruits)
    {
        var basket = new Dictionary<char, int>();
        int left = 0;
        int maxFruits = 0;

        for (int right = 0; right < fruits.Length; right++)
        {
            // Add fruit to basket
            basket[fruits[right]] = basket.GetValueOrDefault(fruits[right]) + 1;

            // More than 2 types? Shrink from left
            while (basket.Count > 2)
            {
                basket[fruits[left]]--;
                if (basket[fruits[left]] == 0)
                    basket.Remove(fruits[left]);
                left++;
            }

            maxFruits = Math.Max(maxFruits, right - left + 1);
        }
        return maxFruits;
    }

    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n╔══════════════════════════════════╗");
        Console.WriteLine("║   🪟  SLIDING WINDOW PATTERN     ║");
        Console.WriteLine("╚══════════════════════════════════╝\n");
        Console.ResetColor();

        Console.WriteLine("📌 Example 1: Max Sum Subarray of Size K");
        int maxSum = MaxSumSubarray(new[] { 2, 1, 5, 1, 3, 2 }, 3);
        Console.WriteLine($"   Array: [2,1,5,1,3,2], k=3");
        Console.WriteLine($"   Max Sum: {maxSum} ✅\n");

        Console.WriteLine("📌 Example 2: Longest Substring Without Repeating");
        int len = LongestUniqueSubstring("abcabcbb");
        Console.WriteLine($"   String: 'abcabcbb'");
        Console.WriteLine($"   Length: {len} ✅\n");

        Console.WriteLine("📌 Example 3: Fruits Into Baskets");
        int fruits = FruitsIntoBaskets(new[] { 'A', 'B', 'C', 'B', 'B', 'C' });
        Console.WriteLine($"   Fruits: [A,B,C,B,B,C]");
        Console.WriteLine($"   Max fruits (2 types): {fruits} ✅\n");
    }
}
