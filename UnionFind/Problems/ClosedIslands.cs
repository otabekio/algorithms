// https://leetcode.com/problems/number-of-closed-islands/

public class Solution {
    public int ClosedIsland(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        var uf = new UnionFind(m * n);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) {
                    uf.SetLand(i*n + j);
                }
                    
                if (i == 0 || i == m - 1 || j == 0 || j == n - 1) {
                    uf.SetBorder(i*n + j);
                } 
                
                if (grid[i][j] == 0) {                    
                    // neighbor -> (i-1, j) & (i, j-1)
                    if (i-1 >= 0 && grid[i-1][j] == 0) {
                        uf.Union(i*n + j, (i-1)*n + j);
                    }

                    if (j-1 >= 0 && grid[i][j-1] == 0) {
                        uf.Union(i*n + j, i*n + j-1);
                    }
                }
            }
        }

        return uf.GetCount();
    }
}

public class UnionFind {
    int[] parent;
    bool[] land;
    bool[] border;

    public UnionFind(int n) {
        land = new bool[n];
        parent = new int[n];
        border = new bool[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        } 
    }

    public void SetBorder(int i) {
        border[i] = true;
    }

    public void SetLand(int i) {
        land[i] = true;
    }

    public int Find(int x) {
        while (parent[x] != x) x = parent[x];
        return x;
    }

    public void Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX == rootY) 
            return;
        
        if (border[rootX]) {
            parent[rootY] = rootX;
            return;
        }

        if (border[rootY]) {
            parent[rootX] = rootY;
            return;
        }

        parent[rootY] = rootX;
    }

    public int GetCount() {
        int count = 0;
        for (int i = 0; i < parent.Length; i++) {
            if (land[i] && i == parent[i] && !border[i]) {
                count   ++;
            }
        }

        return count;
    }
} 