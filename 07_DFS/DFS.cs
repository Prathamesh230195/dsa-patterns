namespace DSAPatterns.DFS;

// ============================================================
// PATTERN: DFS (Depth First Search)
// USE WHEN: Tree traversal, all paths, backtracking, cycles
// IDEA: Go as DEEP as possible, then backtrack. Uses recursion.
// ============================================================

public class DFSTreeNode
{
    public int Val;
    public DFSTreeNode? Left, Right;
    public DFSTreeNode(int val) { Val = val; }
}

public static class DFSExamples
{
    // -------------------------------------------------------
    // EXAMPLE 1: Max Depth of Binary Tree
    // Problem: What is the height of this tree?
    // Input: [3,9,20,null,null,15,7]
    // Output: 3
    // -------------------------------------------------------
    public static int MaxDepth(DFSTreeNode? root)
    {
        if (root == null) return 0;    // Base case: empty = depth 0

        int leftDepth = MaxDepth(root.Left);     // 🌲 Go left
        int rightDepth = MaxDepth(root.Right);   // 🌲 Go right

        return 1 + Math.Max(leftDepth, rightDepth);  // Current + deeper side
    }

    // -------------------------------------------------------
    // EXAMPLE 2: Path Sum
    // Problem: Does tree have root-to-leaf path summing to target?
    // Input: root=[5,4,8,11,null,13,4], targetSum=22
    // Output: true  (5→4→11→2 = 22... or 5→4→11→2)
    // -------------------------------------------------------
    public static bool HasPathSum(DFSTreeNode? root, int targetSum)
    {
        if (root == null) return false;

        // Reached a leaf node
        if (root.Left == null && root.Right == null)
            return root.Val == targetSum;   // Does remaining sum match?

        int remaining = targetSum - root.Val;

        // Try left OR right path
        return HasPathSum(root.Left, remaining) || HasPathSum(root.Right, remaining);
    }

    // -------------------------------------------------------
    // EXAMPLE 3: All Paths From Source to Target (Graph)
    // Problem: Find ALL paths from node 0 to last node
    // Input: graph = [[1,2],[3],[3],[]]
    // Output: [[0,1,3],[0,2,3]]
    // -------------------------------------------------------
    public static List<List<int>> AllPaths(int[][] graph)
    {
        var result = new List<List<int>>();
        var path = new List<int> { 0 }; // Start at node 0
        DFSPath(graph, 0, path, result);
        return result;
    }

    private static void DFSPath(int[][] graph, int node, List<int> path, List<List<int>> result)
    {
        if (node == graph.Length - 1)
        {
            result.Add(new List<int>(path)); // 🎉 Reached target! Save path
            return;
        }

        foreach (int neighbor in graph[node])
        {
            path.Add(neighbor);              // Choose
            DFSPath(graph, neighbor, path, result);
            path.RemoveAt(path.Count - 1);  // Unchoose (backtrack)
        }
    }

    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\n╔══════════════════════════════════╗");
        Console.WriteLine("║   🌲  DFS PATTERN                ║");
        Console.WriteLine("╚══════════════════════════════════╝\n");
        Console.ResetColor();

        Console.WriteLine("📌 Example 1: Max Depth of Tree");
        var root = new DFSTreeNode(3)
        {
            Left = new DFSTreeNode(9),
            Right = new DFSTreeNode(20) { Left = new DFSTreeNode(15), Right = new DFSTreeNode(7) }
        };
        Console.WriteLine($"   Tree: [3,9,20,null,null,15,7]");
        Console.WriteLine($"   Max Depth: {MaxDepth(root)} ✅\n");

        Console.WriteLine("📌 Example 2: Path Sum");
        var pathRoot = new DFSTreeNode(5)
        {
            Left = new DFSTreeNode(4) { Left = new DFSTreeNode(11) { Left = new DFSTreeNode(7), Right = new DFSTreeNode(2) } },
            Right = new DFSTreeNode(8) { Left = new DFSTreeNode(13), Right = new DFSTreeNode(4) { Right = new DFSTreeNode(1) } }
        };
        Console.WriteLine($"   HasPathSum(22): {HasPathSum(pathRoot, 22)} ✅\n");

        Console.WriteLine("📌 Example 3: All Paths Source to Target");
        int[][] graph = new[] { new[]{1,2}, new[]{3}, new[]{3}, Array.Empty<int>() };
        var paths = AllPaths(graph);
        Console.WriteLine($"   Graph: 0→[1,2], 1→[3], 2→[3]");
        foreach (var p in paths)
            Console.WriteLine($"   Path: {string.Join("→", p)}");
        Console.WriteLine("   ✅\n");
    }
}
