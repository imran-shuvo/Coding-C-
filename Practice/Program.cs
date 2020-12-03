using System;
using System.Collections;
using System.Collections.Generic;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            
            LinkedList<int>[] alist = new LinkedList<int>[5];
            for(int i=0;i<5;i++){
                alist[i] = new LinkedList<int>();
            }
            alist[0].AddLast(4);
            alist[0].AddLast(5);
            foreach(int i in alist[0]){
                Console.Write(" {0}",i);
            }

            
           
            
        }
    }
}
