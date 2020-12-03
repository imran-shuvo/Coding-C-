using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
                //0       0       NULL
            //1       1       0
            //11      11      1
            //2       2       0
            //21      21      2
            //211     211     21
            //22      22      2
            //3       3       0
            var nodes = new List<TreeNode> { 
                new TreeNode { id =   0, text =   "0", parent = null },
                new TreeNode { id =   1, text =   "1", parent =    0 },
                new TreeNode { id =  11, text =  "11", parent =    1 },
                new TreeNode { id =   2, text =   "2", parent =    0 },
                new TreeNode { id =  21, text =  "21", parent =    2 },
                new TreeNode { id = 211, text = "211", parent =   21 },
                new TreeNode { id =  22, text =  "22", parent =    2 },
                new TreeNode { id =   3, text =   "3", parent =    0 }
            };

            var tree = TreeBuilder.BuildTree(nodes);

            Console.ReadKey();
            
            
        }
       
    }

public class TreeNode
{
    public int id { get; set; }
    public string text { get; set; }
    public int? parent { get; set; }
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeNode> nodes) {
        if (nodes == null) return new Tree();
        var nodeList = nodes.ToList();
        var tree = FindTreeRoot(nodeList);
        BuildTree(tree, nodeList);
        return tree;
    }

    private static void BuildTree(Tree tree, IList<TreeNode> descendants) {
        var children = descendants.Where(node => node.parent == tree.Id).ToArray();
        foreach (var child in children) {
            var branch = Map(child);
            tree.Add(branch);
            descendants.Remove(child);
        }
        foreach (var branch in tree.Children) {
            BuildTree(branch, descendants);
        }
    }

    private static Tree FindTreeRoot(IList<TreeNode> nodes) {
        var rootNodes = nodes.Where(node => node.parent == null);
        if (rootNodes.Count() != 1) return new Tree();
        var rootNode = rootNodes.Single();
        nodes.Remove(rootNode);
        return Map(rootNode);
    }

    private static Tree Map(TreeNode node) {
        return new Tree {
            Id = node.id,
            Text = node.text,
        };
    }
}

public static class TreeExtensions
{
    public static IEnumerable<Tree> Descendants(this Tree value) {
        // a descendant is the node self and any descendant of the children
        if (value == null) yield break;
        yield return value;
        // depth-first pre-order tree walker
        foreach (var child in value.Children)
        foreach (var descendantOfChild in child.Descendants()) {
            yield return descendantOfChild;
        }
    }

    public static IEnumerable<Tree> Ancestors(this Tree value) {
        // an ancestor is the node self and any ancestor of the parent
        var ancestor = value;
        // post-order tree walker
        while (ancestor != null) {
            yield return ancestor;
            ancestor = ancestor.Parent;
        }
    }
}

public class Tree
{
    public int? Id { get; set; }
    public string Text { get; set; }
    protected List<Tree> _children;
    protected Tree _parent;

    public Tree() {
        Text = string.Empty;
    }

    public Tree Parent { get { return _parent; } }
    public Tree Root { get { return _parent == null ? this : _parent.Root; } }
    public int Depth { get { return this.Ancestors().Count() - 1; } }

    public IEnumerable<Tree> Children {
        get { return _children == null ? Enumerable.Empty<Tree>() : _children.ToArray(); }
    }

    public override string ToString() {
        return Text;
    }

    public void Add(Tree child) {
        if (child == null)
            throw new ArgumentNullException();
        if (child._parent != null)
            throw new InvalidOperationException("A tree node must be removed from its parent before adding as child.");
        if (this.Ancestors().Contains(child))
            throw new InvalidOperationException("A tree cannot be a cyclic graph.");
        if (_children == null) {
            _children = new List<Tree>();
        }
         Debug.Assert(!_children.Contains(child), "At this point, the node is definately not a child");
         child._parent = this;
        _children.Add(child);
    }

    public bool Remove(Tree child) {
        if (child == null)
            throw new ArgumentNullException();
        if (child._parent != this)
            return false;
         Debug.Assert(_children.Contains(child), "At this point, the node is definately a child");
         child._parent = null;
        _children.Remove(child);
        if (!_children.Any())
            _children = null;
        return true;
    }














}}
