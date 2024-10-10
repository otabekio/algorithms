// https://leetcode.com/problems/network-delay-time/

// input
int[][] times = [[2,1,1],[2,3,1],[3,4,1]];
int n = 4;
int k = 2;

// output
var solution = new Solution();
var result = solution.NetworkDelayTime(times, n, k);

Console.WriteLine(result); // 2