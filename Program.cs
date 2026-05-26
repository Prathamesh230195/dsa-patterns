// ╔══════════════════════════════════════════════════════════════╗
// ║           DSA PATTERNS — Complete C# Guide                  ║
// ║    8 Patterns × 3 Examples Each = 24 Problems Solved        ║
// ╚══════════════════════════════════════════════════════════════╝

using DSAPatterns.TwoPointers;
using DSAPatterns.SlidingWindow;
using DSAPatterns.FastSlowPointers;
using DSAPatterns.BinarySearch;
using DSAPatterns.HashMap;
using DSAPatterns.BFS;
using DSAPatterns.DFS;
using DSAPatterns.DynamicProgramming;

Console.Clear();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("╔══════════════════════════════════════════════════════╗");
Console.WriteLine("║          🧠  DSA PATTERNS IN C#                     ║");
Console.WriteLine("║      8 Patterns  ·  24 Examples  ·  All Solved      ║");
Console.WriteLine("╚══════════════════════════════════════════════════════╝");
Console.ResetColor();

Console.WriteLine("\nChoose a pattern to run (or press ENTER to run ALL):");
Console.WriteLine("  [1] 👆👆 Two Pointers");
Console.WriteLine("  [2] 🪟  Sliding Window");
Console.WriteLine("  [3] 🐢🐰 Fast & Slow Pointers");
Console.WriteLine("  [4] 🔍  Binary Search");
Console.WriteLine("  [5] 🗂️  Hash Map");
Console.WriteLine("  [6] 🌊  BFS");
Console.WriteLine("  [7] 🌲  DFS");
Console.WriteLine("  [8] 🧩  Dynamic Programming");
Console.WriteLine("  [0] ⚡ Run ALL Patterns");

Console.Write("\nYour choice: ");
string? input = Console.ReadLine()?.Trim();

Console.WriteLine();

switch (input)
{
    case "1":
        TwoPointersExamples.Run();
        break;
    case "2":
        SlidingWindowExamples.Run();
        break;
    case "3":
        FastSlowExamples.Run();
        break;
    case "4":
        BinarySearchExamples.Run();
        break;
    case "5":
        HashMapExamples.Run();
        break;
    case "6":
        BFSExamples.Run();
        break;
    case "7":
        DFSExamples.Run();
        break;
    case "8":
        DPExamples.Run();
        break;
    default:
        // Run ALL patterns
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Running all 8 patterns...\n");
        Console.ResetColor();

        TwoPointersExamples.Run();
        SlidingWindowExamples.Run();
        FastSlowExamples.Run();
        BinarySearchExamples.Run();
        HashMapExamples.Run();
        BFSExamples.Run();
        DFSExamples.Run();
        DPExamples.Run();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("╔══════════════════════════════════════════════════════╗");
        Console.WriteLine("║  ✅  All 8 patterns ran successfully! You're a DSA   ║");
        Console.WriteLine("║     wizard now. Go solve LeetCode problems! 💪       ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════╝");
        Console.ResetColor();
        break;
}
