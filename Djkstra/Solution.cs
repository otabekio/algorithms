public class Solution 
{
    public int NetworkDelayTime(int[][] times, int n, int k) 
    {
        var adj = new List<List<(int node, int w)>>();
        for (int i = 0; i <= n; i++) adj.Add(new List<(int, int)>());
        foreach (var time in times) 
        {
            adj[time[0]].Add((time[1], time[2]));
        }
        var dist = new int[n + 1];
        Array.Fill(dist, int.MaxValue);
        dist[k] = 0;
        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k, 0);
        var visited = new bool[n + 1];
        while (pq.Count > 0) 
        {
            var curr = pq.Dequeue();
            if (visited[curr]) continue;
            visited[curr] = true;
            foreach (var nei in adj[curr]) 
            {
                if (!visited[nei.node]) 
                {
                    dist[nei.node] = Math.Min(dist[nei.node], dist[curr] + nei.w);
                    pq.Enqueue(nei.node, dist[nei.node]);
                }
            }
        }
        
        int max = 0;
        for (int i = 1; i <= n; i++) max = Math.Max(max, dist[i]);
        return max == int.MaxValue ? -1 : max;
    }
}