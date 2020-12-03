using System;
using System.Collections.Generic;

namespace infixToPost
{
    class Program

    {
      static int priority(char c){

                switch (c)
                {
                    case '+':
                    case '-':
                        return 1;
                    case '*':
                    case '/':
                        return 2;
                    
                    case '^':
                        return 3;         
                    
                }
                return -1;
        }


      static string inToPost(string str){

          Stack<char> stack = new Stack<char>();
          string result="";

              for(int i=0;i<str.Length;i++)
              {
                  
                   if(str[i]=='('){
                       stack.Push(str[i]);
                   }
                   else if(str[i]==')')
                   {
                       while(stack.Count>0&&stack.Peek()!='(')
                        {
                            result+=stack.Pop();
                        }
                        if(stack.Peek()=='(')
                            stack.Pop();
                        
                        
                   }
                   else if(str[i]=='*'||str[i]=='/'||str[i]=='+'||str[i]=='-'||str[i]=='^'){

                         while(stack.Count>0&&priority(stack.Peek()) >= priority(str[i]) )
                         {
                             result+=stack.Pop();
                         }
                         stack.Push(str[i]);

                   }
                   else
                   {
                       result+=str[i];
                   }




              }
              while(stack.Count>0){
                  result+=stack.Pop();
                  
              }

            return result;

        }

        static void Main(string[] args)
        {
            string str = "a+b*(c^d-e)^(f+g*h)-i";
            string  s;
            s = inToPost(str);
            Console.Write(s);
        }
    }
}
