// using System;

// namespace tree_traverse
// {

//     class Node{

//          public int data;
//          public Node left,right;
//          public Node(int key){
//             data = key;
//             left=right=null;

//           }

//     }
//     class Program
//     {
//         Node root;

//         Program(){
//             root =null;

//         }

//         void inorder(Node node){
//             if(node==null)
//                 return;
            
//             inorder(node.left);
//             Console.WriteLine(node.data+" ");
//             inorder(node.right);
//         }


//         static void Main(string[] args)
//         {
//             Program ob = new Program();
//             Node root = new Node(1);
//             root.left = new Node(2);
//             root.right = new Node(3);
//             root.left.left = new Node(4);
//             root.left.right = new Node(5);
   
//             ob.inorder(root);
//         }
//     }
// }
