public class UnionFind
{
    private int[] parent; // Parent array to store the root of each node
    private int[] rank;   // Rank array to store the depth of trees
    private int count;    // To keep track of the number of disjoint sets (islands, components)

    // Constructor to initialize the Union-Find structure
    public UnionFind(int n)
    {
        parent = new int[n];
        rank = new int[n];
        count = n; // Initially, there are 'n' disjoint sets
        
        // Each node is its own parent at the start, and the rank is 0
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    // Find the root of the element 'x', with path compression
    public int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]); // Path compression: make x directly point to the root
        }
        return parent[x];
    }

    // Union two sets containing 'x' and 'y', return true if they were disjoint
    public bool Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        // If they are already in the same set, no need to union
        if (rootX == rootY)
        {
            return false;
        }

        // Union by rank: attach the shorter tree under the root of the taller tree
        if (rank[rootX] > rank[rootY])
        {
            parent[rootY] = rootX;
        }
        else if (rank[rootX] < rank[rootY])
        {
            parent[rootX] = rootY;
        }
        else
        {
            parent[rootY] = rootX;
            rank[rootX]++; // Only increment rank when the ranks are equal
        }

        count--; // Since we merged two sets, we decrease the count of disjoint sets
        return true;
    }

    // Return the number of disjoint sets (useful to count the number of connected components)
    public int GetCount()
    {
        return count;
    }
}
