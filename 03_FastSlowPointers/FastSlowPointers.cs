namespace DSAPatterns.FastSlowPointers;

// ============================================================
// PATTERN: FAST & SLOW POINTERS (Tortoise & Hare)
// USE WHEN: Cycle detection, finding middle of linked list
// IDEA: Slow moves 1 step, Fast moves 2 steps
//       If cycle exists → they will MEET
// ============================================================

public class ListNode
{
    public int Val;
    public ListNode? Next;
    public ListNode(int val) { Val = val; }
}

public static class FastSlowExamples
{
    // -------------------------------------------------------
    // EXAMPLE 1: Detect Cycle in Linked List
    // Problem: Does 1→2→3→4→2 (loop) have a cycle?
    // Output: true
    // -------------------------------------------------------
    public static bool HasCycle(ListNode head)
    {
        ListNode? slow = head;
        ListNode? fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow!.Next;           // 🐢 1 step
            fast = fast.Next.Next;       // 🐰 2 steps

            if (slow == fast)
                return true;             // 🎉 They met → cycle!
        }
        return false;                    // fast reached end → no cycle
    }

    // -------------------------------------------------------
    // EXAMPLE 2: Find Middle of Linked List
    // Problem: 1→2→3→4→5  →  return node with value 3
    // Trick: When fast reaches end, slow is at middle!
    // -------------------------------------------------------
    public static ListNode FindMiddle(ListNode head)
    {
        ListNode slow = head;
        ListNode? fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next!;           // 🐢 1 step
            fast = fast.Next.Next;       // 🐰 2 steps
        }
        return slow;                     // 🎉 slow is at middle
    }

    // -------------------------------------------------------
    // EXAMPLE 3: Happy Number
    // Problem: Is 19 a happy number?
    //   19 → 1²+9² = 82 → 8²+2² = 68 → ... → 1  (happy!)
    //   Unhappy numbers cycle endlessly
    // -------------------------------------------------------
    public static bool IsHappy(int n)
    {
        int slow = n;
        int fast = GetNext(n);

        while (fast != 1 && slow != fast)
        {
            slow = GetNext(slow);                // 🐢 1 step
            fast = GetNext(GetNext(fast));        // 🐰 2 steps
        }
        return fast == 1;                         // reached 1 = happy!
    }

    private static int GetNext(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            sum += digit * digit;
            n /= 10;
        }
        return sum;
    }

    // Helper: Build linked list from array
    public static ListNode BuildList(int[] vals, int cycleAt = -1)
    {
        var nodes = vals.Select(v => new ListNode(v)).ToArray();
        for (int i = 0; i < nodes.Length - 1; i++)
            nodes[i].Next = nodes[i + 1];
        if (cycleAt >= 0)
            nodes[^1].Next = nodes[cycleAt]; // Create cycle
        return nodes[0];
    }

    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n╔══════════════════════════════════╗");
        Console.WriteLine("║  🐢🐰 FAST & SLOW POINTERS      ║");
        Console.WriteLine("╚══════════════════════════════════╝\n");
        Console.ResetColor();

        Console.WriteLine("📌 Example 1: Detect Cycle");
        var cyclic = BuildList(new[] { 1, 2, 3, 4, 5 }, cycleAt: 1); // 5 points back to node[1]=2
        var noCycle = BuildList(new[] { 1, 2, 3, 4, 5 });
        Console.WriteLine($"   List with cycle:    HasCycle = {HasCycle(cyclic)} ✅");
        Console.WriteLine($"   List without cycle: HasCycle = {HasCycle(noCycle)} ✅\n");

        Console.WriteLine("📌 Example 2: Find Middle");
        var list = BuildList(new[] { 1, 2, 3, 4, 5 });
        var mid = FindMiddle(list);
        Console.WriteLine($"   List: 1→2→3→4→5");
        Console.WriteLine($"   Middle: {mid.Val} ✅\n");

        Console.WriteLine("📌 Example 3: Happy Number");
        Console.WriteLine($"   IsHappy(19) = {IsHappy(19)} ✅");
        Console.WriteLine($"   IsHappy(4)  = {IsHappy(4)} ✅\n");
    }
}
