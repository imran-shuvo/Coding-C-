using System;
using System.Collections;

namespace HelloWorld1
{       


    class StackMy
    {

        public ArrayList list;
        public int top;
        

        public StackMy(){
            list = new ArrayList();
            top = -1;

        }
        public void push(object num){
            list.Add(num);
            top++;
        }
        public object pop(){
            if(top<0)
            {
                 Console.Write("the stack is empty");
                 return 0;

            }
               
            else
            {
                 list.RemoveAt(top);
                 top--;
                 return list[top];

            }
           
        }
        public object count(){
            return list.Count;
        }
        
        public object peek(){
            return list[top];
        }
        public void clear(){
            list.Clear();
        }



    }


    class Program
    {
        static void Main(string[] args)
        {
            StackMy stack1 = new StackMy();
          
            stack1.push(4);
            stack1.push(5);


            Console.WriteLine(stack1.peek());
            stack1.pop();
            Console.WriteLine(stack1.peek());


        }
    }
}
