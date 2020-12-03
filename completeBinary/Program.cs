using System;

namespace completeBinary
{
      class Node{
            public int key;
            public  Node left,right;

            public Node(int data){
                key = data;
                left=right =null;
                
            }

        }


    class Tree{
        
       public Node root;

        public Node insertvalue(int[] a,Node root,int i){

                if(i<a.Length){
                    Node temp = new Node(a[i]);
                    root = temp;
                    root.left = insertvalue(a,root.left,2*i+1);
                    root.right = insertvalue(a,root.right,2*i+2);
                }
                return root;

        }
      

    }
    class Program
    {

       static void inorder(Node root){
            if(root==null)
                return ;
            
            inorder(root.left);
            Console.WriteLine(root.key);
            inorder(root.right);
        }
        static void Main(string[] args)
        {
            int[]a= {1, 2, 3, 4, 5, 6, 6, 6, 6};
            Tree tree = new Tree();
            
            tree.root = tree.insertvalue(a,tree.root,0);
            inorder(tree.root);
        }
    }
}
