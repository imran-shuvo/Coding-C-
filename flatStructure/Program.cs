using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace flatStructure
{
   

    class Node
{
    public int ParentId { get; private set; }
    public int Id { get; private set; }
    public string Label { get; private set; }
    public Node Parent { get; set; }
    public List<Node> Children { get; } = new List<Node>();

    public Node(int parentId, int id, string lable)
    {
        ParentId = parentId;
        Id = id;
        Label = lable;
    }

    public void AddChild(Node child)
    {
        child.Parent = this;
        Children.Add(child);
    }

    public void Trace(int indent = 1)
    {
        Enumerable.Range(0, indent).ToList().ForEach(i => Console.Write(" - "));
        Console.WriteLine(Label);
        Children.ForEach(c => c.Trace(indent + 1));
    }
}

    class Program
    {
        
        static void Main(string[] args)
        {
            var data = new List<Node>() {
            new Node { ParentId = 0, Id = 1, Label = "parent" },
            new Node { ParentId = 1, Id = 2, Label = "child 1" },
            new Node { ParentId = 1, Id = 3, Label = "child 2" },
            new Node { ParentId = 2, Id = 4, Label = "grand child 1" },
            new Node { ParentId = 2, Id = 5, Label = "grand child 2" } };

            Dictionary<int, Node> nodes = data.ToDictionary(d => d.Id, d => new Node(d.ParentId, d.Id, d.Label));
            foreach (var node in nodes.Skip(1))
                nodes[node.Value.ParentId].AddChild(node.Value);
           
        }
    }
}
