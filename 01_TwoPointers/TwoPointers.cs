namespace DSAPatterns.TwoPointers;

// ============================================================
// PATTERN: TWO POINTERS
// USE WHEN: Sorted array, finding pairs, palindrome checks
// IDEA: One pointer at start, one at end — move toward center
// ============================================================

public static class TwoPointersExamples
{
    // -------------------------------------------------------
    // EXAMPLE 1: Two Sum in Sorted Array
    // Problem: Find two numbers that add up to target
    // Input: [1, 2, 4, 6, 8], target = 9
    // Output: [0, 4] (indices)
    // -------------------------------------------------------
    public static int[] TwoSumSorted(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            int sum = arr[left] + arr[right];

            if (sum == target)
                return new[] { left, right };   // 🎉 Found!
            else if (sum < target)
                left++;                          // Need bigger → move right
            else
                right--;                         // Need smaller → move left
        }
        return Array.Empty<int>();               // Not found
    }

    // -------------------------------------------------------
    // EXAMPLE 2: Valid Palindrome
    // Problem: Is the string same forwards and backwards?
    // Input: "racecar" → true  |  "hello" → false
    // -------------------------------------------------------
    public static bool IsPalindrome(string word)
    {
        int left = 0;
        int right = word.Length - 1;

        while (left < right)
        {
            if (word[left] != word[right])
                return false;   // ❌ Mismatch found
            left++;
            right--;
        }
        return true;            // ✅ All characters matched
    }

    // -------------------------------------------------------
    // EXAMPLE 3: Container With Most Water
    // Problem: Find two lines that hold the most water
    // Input: heights = [1, 8, 6, 2, 5, 4, 8, 3, 7]
    // Output: 49
    // -------------------------------------------------------
    public static int MaxWater(int[] heights)
    {
        int left = 0;
        int right = heights.Length - 1;
        int maxWater = 0;

        while (left < right)
        {
            int width = right - left;
            int height = Math.Min(heights[left], heights[right]);
            int water = width * height;

            maxWater = Math.Max(maxWater, water);

            // Move the shorter side inward (try to find taller)
            if (heights[left] < heights[right])
                left++;
            else
                right--;
        }
        return maxWater;
    }

    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n╔══════════════════════════════════╗");
        Console.WriteLine("║   👆👆  TWO POINTERS PATTERN     ║");
        Console.WriteLine("╚══════════════════════════════════╝\n");
        Console.ResetColor();

        // Example 1
        Console.WriteLine("📌 Example 1: Two Sum in Sorted Array");
        int[] result = TwoSumSorted(new[] { 1, 2, 4, 6, 8 }, 9);
        Console.WriteLine($"   Array: [1, 2, 4, 6, 8], Target: 9");
        Console.WriteLine($"   Answer: indices [{result[0]}, {result[1]}]  → values {1} + {8} = 9 ✅\n");

        // Example 2
        Console.WriteLine("📌 Example 2: Valid Palindrome");
        Console.WriteLine($"   'racecar' → {IsPalindrome("racecar")} ✅");
        Console.WriteLine($"   'hello'   → {IsPalindrome("hello")} ✅\n");

        // Example 3
        Console.WriteLine("📌 Example 3: Container With Most Water");
        int water = MaxWater(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
        Console.WriteLine($"   Heights: [1,8,6,2,5,4,8,3,7]");
        Console.WriteLine($"   Max water: {water} ✅\n");
    }
}
