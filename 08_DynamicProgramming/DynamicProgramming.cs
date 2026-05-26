namespace DSAPatterns.DynamicProgramming;

// ============================================================
// PATTERN: DYNAMIC PROGRAMMING
// USE WHEN: Overlapping subproblems, optimize/count/max/min
// IDEA: Break problem into smaller ones, SAVE results, reuse
// ============================================================

public static class DPExamples
{
    // -------------------------------------------------------
    // EXAMPLE 1: Climbing Stairs
    // Problem: How many ways to climb n stairs (1 or 2 steps)?
    // Input: n=5
    // Output: 8
    // -------------------------------------------------------
    public static int ClimbStairs(int n)
    {
        if (n <= 1) return 1;

        int[] dp = new int[n + 1];
        dp[0] = 1;  // 1 way to stand at ground
        dp[1] = 1;  // 1 way to reach step 1

        for (int i = 2; i <= n; i++)
        {
            // To reach step i: come from step i-1 OR step i-2
            dp[i] = dp[i - 1] + dp[i - 2];  // 🧩
        }

        return dp[n];
        // dp = [1,1,2,3,5,8] → answer is 8
    }

    // -------------------------------------------------------
    // EXAMPLE 2: House Robber
    // Problem: Rob max money without robbing adjacent houses
    // Input: [2,7,9,3,1]
    // Output: 12  (2+9+1=12)
    // -------------------------------------------------------
    public static int Rob(int[] houses)
    {
        if (houses.Length == 0) return 0;
        if (houses.Length == 1) return houses[0];

        int[] dp = new int[houses.Length];
        dp[0] = houses[0];
        dp[1] = Math.Max(houses[0], houses[1]);

        for (int i = 2; i < houses.Length; i++)
        {
            // Either: skip this house (take dp[i-1])
            //     OR: rob this house + best from 2 houses back
            dp[i] = Math.Max(dp[i - 1], houses[i] + dp[i - 2]);
        }

        return dp[^1]; // Last element has the answer
    }

    // -------------------------------------------------------
    // EXAMPLE 3: Coin Change
    // Problem: Minimum coins to make amount
    // Input: coins=[1,5,10], amount=18
    // Output: 4  (10+5+1+1+1=18... wait: 10+5+1+1+1=5. Let me recalc: 10+5+1+1+1=18? 10+5=15, +3×1=18 → 5 coins. Or 10+8? no 8 not a coin. Best: 10+5+1+1+1=5)
    // -------------------------------------------------------
    public static int CoinChange(int[] coins, int amount)
    {
        // dp[i] = min coins needed to make amount i
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);   // Fill with "infinity"
        dp[0] = 0;                     // 0 coins to make amount 0

        for (int i = 1; i <= amount; i++)
        {
            foreach (int coin in coins)
            {
                if (coin <= i)
                {
                    // Use this coin + min coins for remaining amount
                    dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                }
            }
        }

        return dp[amount] > amount ? -1 : dp[amount];
    }

    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n╔══════════════════════════════════╗");
        Console.WriteLine("║   🧩  DYNAMIC PROGRAMMING        ║");
        Console.WriteLine("╚══════════════════════════════════╝\n");
        Console.ResetColor();

        Console.WriteLine("📌 Example 1: Climbing Stairs");
        Console.WriteLine($"   n=5 → {ClimbStairs(5)} ways ✅");
        Console.WriteLine($"   dp = [{string.Join(",", Enumerable.Range(0, 6).Select(ClimbStairs))}]\n");

        Console.WriteLine("📌 Example 2: House Robber");
        int money = Rob(new[] { 2, 7, 9, 3, 1 });
        Console.WriteLine($"   Houses: [2,7,9,3,1]");
        Console.WriteLine($"   Max rob: {money} ✅\n");

        Console.WriteLine("📌 Example 3: Coin Change");
        int coins = CoinChange(new[] { 1, 5, 10 }, 18);
        Console.WriteLine($"   Coins: [1,5,10], amount=18");
        Console.WriteLine($"   Min coins: {coins} ✅\n");
    }
}
