using System;
using System.Collections.Generic;

namespace LinkList
{


    class Graph{

           public  LinkedList<int>[] alist;

           public Graph(int v){
               alist = new LinkedList<int>[v];

               for(int i=0;i<alist.Length;i++)
               {
                   alist[i] = new LinkedList<int>();
               }

           }
           public void addEdge(int u,int v){
               alist[u].AddLast(v);

           }
           public void Bfs(){
               
               bool[] visited = new bool[100];
               for(int i=0;i<7;i++){
                    visited[i] =false;
               }

               Queue<int> queue = new Queue<int>();
               queue.Enqueue(2);
               visited[2] = true;
               
               while(queue.Count>0){
                   Console.WriteLine(" num of queues {0} ",queue.Count);
                   int src = queue.Dequeue();
                   
                   Console.Write(" {0}",src);
                   foreach(int i in alist[src]){

                       if(!visited[i]){

                             queue.Enqueue(i);
                           visited[i] = true;
                       }

                   }

               }

               



           }




    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(10);
            g.addEdge(0, 1);  
            g.addEdge(0, 2);  
            g.addEdge(1, 2);  
            g.addEdge(2, 0);  
            g.addEdge(2, 3);  
            g.addEdge(3, 3);
            g.Bfs();
        }
    }
}
