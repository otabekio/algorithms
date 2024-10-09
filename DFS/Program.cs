Dictionary<string, List<string>> graph = new()
{
    { "A", new List<string>() {"C", "E"} },
    { "B", new List<string>() {"C", "F"} },
    { "C", new List<string>() {"A", "B", "D", "F"} },
    { "D", new List<string>() {"C", "F"} },
    { "E", new List<string>() {"A", "F"} },
    { "F", new List<string>() {"B", "C", "D", "E"}},
};

Stack<string> st = new();
st.Push("A");
HashSet<string> visited = new();
visited.Add("A");
while (st.Count > 0) {
    var curr = st.Pop();
    Console.Write(curr + " -> ");
    foreach (var neighbor in graph[curr]) {
        if (!visited.Contains(neighbor)) {
            st.Push(neighbor);
            visited.Add(neighbor);
        }
    }
}