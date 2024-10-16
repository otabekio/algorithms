public class UnionFind 
{
    int[] parent;
    int[] size;

    public UnionFind(int n) 
    {
        parent = new int[n];
        size = new int[n];

        for (int i = 0; i < n; i++) 
        {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int x) 
    {
        while (parent[x] != x) x = parent[x];
        return x;
    }

    public bool Union(int x, int y) 
    {
        var rootX = Find(x);
        var rootY = Find(y);

        if (rootX == rootY) return false;

        if (size[rootX] >= size[rootY]) 
        {
            parent[rootY] = rootX;
            size[rootX] += size[rootY];
        }
        else 
        {
            parent[rootX] = rootY;
            size[rootY] += size[rootX];
        }

        return true;
    }
}