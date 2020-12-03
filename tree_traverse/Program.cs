using System;

namespace tree_traverse
{

    class Node{
        public int key;
        public Node right,left;
        
        public Node(int data){
            key = data;
            right = left = null;
        }
    }
class Program{

    
   void preorder(Node node){

       if(node==null)
        return;
        Console.WriteLine(node.key);
        preorder(node.left);
        preorder(node.right);

   }

   

    static void Main(string[] args)
    {
       Program tree = new Program();

       Node root  = new Node(1);
       root.left = new Node(2);
       root.right = new Node(3);
       root.left.left = new Node(4);
       root.left.right = new Node(5);
       tree.preorder(root);
       
        
        
    }
    
    }
}