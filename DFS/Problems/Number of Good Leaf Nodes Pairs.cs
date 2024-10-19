 public class TreeNode 
 {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) 
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    List<List<TreeNode>> list;
    public int CountPairs(TreeNode root, int distance) {
        list = new();
        Dfs(root, new());

        //Print(list);

        int n = list.Count;
        int count = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (ShortestDist(list[i], list[j]) <= distance) {
                    count++;
                }
            }
        }

        return count;
    }

    private void Dfs(TreeNode curr, List<TreeNode> path) {
        if (curr == null) {
            return;
        }

        path.Add(curr);

        if (curr.left == null && curr.right == null) {
            list.Add(path);
            return;
        }
        
        Dfs(curr.left, new(path));
        Dfs(curr.right, new(path));
    }

    int ShortestDist(List<TreeNode> list1, List<TreeNode> list2) {
        int n1 = list1.Count, n2 = list2.Count;
        int i1 = 0, i2 = 0;
        while (list1[i1] == list2[i2]) {
            i1++;
            i2++;
        }
        
        return n1 - i1 + n2 - i2;
    }

    void Print(List<TreeNode> list) {
        foreach (var item in list) Console.Write(item.val + " -> ");
        Console.Write("null\n");
    } 

    void Print(List<List<TreeNode>> list) {
        foreach (var item in list) {
            Print(item);
        }
    } 
}