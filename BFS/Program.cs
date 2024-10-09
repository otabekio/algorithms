Dictionary<string, List<string>> graph = new()
{
    { "A", new List<string>() {"C", "E"} },
    { "B", new List<string>() {"C", "F"} },
    { "C", new List<string>() {"A", "B", "D", "F"} },
    { "D", new List<string>() {"C", "F"} },
    { "E", new List<string>() {"A", "F"} },
    { "F", new List<string>() {"B", "C", "D", "E"}},
};

Queue<string> queue = new();
queue.Enqueue("A");

HashSet<string> visited = new();
visited.Add("A");

while (queue.Count > 0) {
    var curr = queue.Dequeue();
    if (!visited.Contains(curr)) {
        Console.Write(curr + " -> ");
        visited.Add(neighbor);
    }

    foreach (var neighbor in graph[curr]) {
        if (!visited.Contains(neighbor)) {
            queue.Enqueue(neighbor);
        }
    }
}