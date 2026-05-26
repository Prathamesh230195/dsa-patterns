namespace DSAPatterns.BinarySearch;

// ============================================================
// PATTERN: BINARY SEARCH
// USE WHEN: Sorted array, find element, minimize/maximize
// IDEA: Cut search space in HALF each iteration → O(log n)
// ============================================================

public static class BinarySearchExamples
{
    // -------------------------------------------------------
    // EXAMPLE 1: Classic Binary Search
    // Problem: Find index of target in sorted array
    // Input: [1,3,5,7,9,11], target=7
    // Output: 3
    // -------------------------------------------------------
    public static int Search(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;  // Avoids overflow

            if (arr[mid] == target)
                return mid;              // 🎉 Found!
            else if (arr[mid] < target)
                left = mid + 1;          // Target is in right half
            else
                right = mid - 1;         // Target is in left half
        }
        return -1;                       // Not found
    }

    // -------------------------------------------------------
    // EXAMPLE 2: Search in Rotated Sorted Array
    // Problem: Array was rotated: [4,5,6,7,0,1,2], find 0
    // Output: 4
    // -------------------------------------------------------
    public static int SearchRotated(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target) return mid;

            // Left half is sorted
            if (arr[left] <= arr[mid])
            {
                if (target >= arr[left] && target < arr[mid])
                    right = mid - 1;     // Target in left sorted half
                else
                    left = mid + 1;
            }
            else // Right half is sorted
            {
                if (target > arr[mid] && target <= arr[right])
                    left = mid + 1;      // Target in right sorted half
                else
                    right = mid - 1;
            }
        }
        return -1;
    }

    // -------------------------------------------------------
    // EXAMPLE 3: Koko Eating Bananas (Binary Search on Answer)
    // Problem: Find minimum speed k so Koko eats all piles in h hours
    // Input: piles=[3,6,7,11], h=8 → Output: 4
    // -------------------------------------------------------
    public static int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1;
        int right = piles.Max();   // Max possible speed

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (CanFinish(piles, mid, h))
                right = mid;       // Maybe slower works too?
            else
                left = mid + 1;    // Too slow, need faster
        }
        return left;
    }

    private static bool CanFinish(int[] piles, int speed, int h)
    {
        int hours = 0;
        foreach (int pile in piles)
            hours += (int)Math.Ceiling((double)pile / speed);
        return hours <= h;
    }

    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n╔══════════════════════════════════╗");
        Console.WriteLine("║   🔍  BINARY SEARCH PATTERN      ║");
        Console.WriteLine("╚══════════════════════════════════╝\n");
        Console.ResetColor();

        Console.WriteLine("📌 Example 1: Classic Binary Search");
        int idx = Search(new[] { 1, 3, 5, 7, 9, 11 }, 7);
        Console.WriteLine($"   Array: [1,3,5,7,9,11], target=7");
        Console.WriteLine($"   Found at index: {idx} ✅\n");

        Console.WriteLine("📌 Example 2: Search in Rotated Array");
        int ridx = SearchRotated(new[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
        Console.WriteLine($"   Array: [4,5,6,7,0,1,2], target=0");
        Console.WriteLine($"   Found at index: {ridx} ✅\n");

        Console.WriteLine("📌 Example 3: Koko Eating Bananas");
        int speed = MinEatingSpeed(new[] { 3, 6, 7, 11 }, 8);
        Console.WriteLine($"   Piles: [3,6,7,11], hours=8");
        Console.WriteLine($"   Min speed: {speed} bananas/hour ✅\n");
    }
}
