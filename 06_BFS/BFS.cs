namespace DSAPatterns.BFS;

// ============================================================
// PATTERN: BFS (Breadth First Search)
// USE WHEN: Shortest path, level-by-level traversal, spreading
// IDEA: Use a QUEUE. Visit all neighbors before going deeper.
// ============================================================

public class TreeNode
{
    public int Val;
    public TreeNode? Left, Right;
    public TreeNode(int val) { Val = val; }
}

public static class BFSExamples
{
    // -------------------------------------------------------
    // EXAMPLE 1: Binary Tree Level Order Traversal
    // Problem: Print nodes level by level
    // Input: Tree with root=3, left=9, right=20, etc.
    // Output: [[3],[9,20],[15,7]]
    // -------------------------------------------------------
    public static List<List<int>> LevelOrder(TreeNode? root)
    {
        var result = new List<List<int>>();
        if (root == null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            var level = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.Val);

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
            result.Add(level);
        }
        return result;
    }

    // -------------------------------------------------------
    // EXAMPLE 2: Number of Islands
    // Problem: Count islands in a grid (1=land, 0=water)
    // Input: grid of 1s and 0s
    // Output: number of distinct islands
    // -------------------------------------------------------
    public static int NumIslands(char[][] grid)
    {
        int islands = 0;
        int rows = grid.Length, cols = grid[0].Length;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '1')
                {
                    islands++;
                    BFSSink(grid, r, c, rows, cols); // Sink the island
                }
            }
        }
        return islands;
    }

    private static void BFSSink(char[][] grid, int r, int c, int rows, int cols)
    {
        var queue = new Queue<(int, int)>();
        queue.Enqueue((r, c));
        grid[r][c] = '0'; // Mark visited

        int[][] dirs = new[] { new[]{0,1}, new[]{0,-1}, new[]{1,0}, new[]{-1,0} };

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();
            foreach (var d in dirs)
            {
                int nr = row + d[0], nc = col + d[1];
                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == '1')
                {
                    grid[nr][nc] = '0';
                    queue.Enqueue((nr, nc));
                }
            }
        }
    }

    // -------------------------------------------------------
    // EXAMPLE 3: Rotting Oranges
    // Problem: How many minutes until all oranges rot?
    //   0=empty, 1=fresh, 2=rotten. Rotten spreads each minute.
    // -------------------------------------------------------
    public static int OrangesRotting(int[][] grid)
    {
        var queue = new Queue<(int, int)>();
        int fresh = 0;
        int rows = grid.Length, cols = grid[0].Length;

        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 2) queue.Enqueue((r, c));
                if (grid[r][c] == 1) fresh++;
            }

        if (fresh == 0) return 0;

        int minutes = 0;
        int[][] dirs = new[] { new[]{0,1}, new[]{0,-1}, new[]{1,0}, new[]{-1,0} };

        while (queue.Count > 0 && fresh > 0)
        {
            minutes++;
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var (r, c) = queue.Dequeue();
                foreach (var d in dirs)
                {
                    int nr = r + d[0], nc = c + d[1];
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 1)
                    {
                        grid[nr][nc] = 2;
                        fresh--;
                        queue.Enqueue((nr, nc));
                    }
                }
            }
        }
        return fresh == 0 ? minutes : -1;
    }

    public static void Run()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n╔══════════════════════════════════╗");
        Console.WriteLine("║   🌊  BFS PATTERN                ║");
        Console.WriteLine("╚══════════════════════════════════╝\n");
        Console.ResetColor();

        Console.WriteLine("📌 Example 1: Level Order Tree Traversal");
        var root = new TreeNode(3)
        {
            Left = new TreeNode(9),
            Right = new TreeNode(20) { Left = new TreeNode(15), Right = new TreeNode(7) }
        };
        var levels = LevelOrder(root);
        foreach (var level in levels)
            Console.WriteLine($"   Level: [{string.Join(", ", level)}]");
        Console.WriteLine("   ✅\n");

        Console.WriteLine("📌 Example 2: Number of Islands");
        char[][] grid = new[]
        {
            new[]{'1','1','0','0'},
            new[]{'1','1','0','0'},
            new[]{'0','0','1','0'},
            new[]{'0','0','0','1'}
        };
        Console.WriteLine($"   Islands count: {NumIslands(grid)} ✅\n");

        Console.WriteLine("📌 Example 3: Rotting Oranges");
        int[][] oranges = new[] { new[]{2,1,1}, new[]{1,1,0}, new[]{0,1,1} };
        Console.WriteLine($"   Minutes to rot all: {OrangesRotting(oranges)} ✅\n");
    }
}
