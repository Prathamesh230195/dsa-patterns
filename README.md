# 🧠 DSA Patterns in C#

> **8 Essential DSA Patterns** with **3 real examples each** — explained for humans, not robots.

## 📁 Project Structure

```
DSAPatterns/
├── Program.cs                          ← Entry point (run this!)
├── DSAPatterns.csproj
│
├── 01_TwoPointers/
│   └── TwoPointers.cs                  ← TwoSumSorted, IsPalindrome, MaxWater
│
├── 02_SlidingWindow/
│   └── SlidingWindow.cs                ← MaxSumSubarray, LongestUnique, FruitsIntoBaskets
│
├── 03_FastSlowPointers/
│   └── FastSlowPointers.cs             ← HasCycle, FindMiddle, IsHappy
│
├── 04_BinarySearch/
│   └── BinarySearch.cs                 ← Search, SearchRotated, KokoEatingBananas
│
├── 05_HashMap/
│   └── HashMap.cs                      ← TwoSum, GroupAnagrams, LongestConsecutive
│
├── 06_BFS/
│   └── BFS.cs                          ← LevelOrder, NumIslands, OrangesRotting
│
├── 07_DFS/
│   └── DFS.cs                          ← MaxDepth, HasPathSum, AllPaths
│
└── 08_DynamicProgramming/
    └── DynamicProgramming.cs           ← ClimbStairs, HouseRobber, CoinChange
```

## 🚀 How to Run

```bash
cd DSAPatterns
dotnet run
```

## 🗺️ Pattern Cheat Sheet

| Keyword in Problem | Use This Pattern |
|--------------------|-----------------|
| Sorted array + find pair | **Two Pointers** |
| Subarray / substring | **Sliding Window** |
| Linked list cycle / middle | **Fast & Slow Pointers** |
| Sorted + search efficiently | **Binary Search** |
| Count / lookup / duplicate | **Hash Map** |
| Shortest path / min steps | **BFS** |
| All paths / tree traversal | **DFS** |
| Max/Min/Count ways | **Dynamic Programming** |

## 📚 Patterns Overview

### 👆👆 1. Two Pointers
Put one pointer at the start, one at the end. Move them toward each other.
- **Examples:** Two Sum (sorted), Palindrome check, Container With Most Water

### 🪟 2. Sliding Window
A moving window of fixed or variable size across the array.
- **Examples:** Max sum subarray, Longest unique substring, Fruits into baskets

### 🐢🐰 3. Fast & Slow Pointers
Slow moves 1 step, Fast moves 2. They meet if there's a cycle.
- **Examples:** Detect cycle, Find middle, Happy number

### 🔍 4. Binary Search
Cut the search space in half each time. Only works on sorted data.
- **Examples:** Classic search, Rotated array, Koko eating bananas

### 🗂️ 5. Hash Map
O(1) lookup. Store what you've seen for instant access later.
- **Examples:** Two Sum (unsorted), Group anagrams, Longest consecutive

### 🌊 6. BFS (Breadth First Search)
Explore level by level using a Queue. Best for shortest paths.
- **Examples:** Level order traversal, Number of islands, Rotting oranges

### 🌲 7. DFS (Depth First Search)
Go deep before going wide using recursion. Best for all paths.
- **Examples:** Max depth, Path sum, All paths source to target

### 🧩 8. Dynamic Programming
Save answers to subproblems, reuse them. Never solve twice.
- **Examples:** Climbing stairs, House robber, Coin change

## 🛠️ Requirements
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
