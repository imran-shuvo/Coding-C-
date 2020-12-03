using System;
using System.Collections.Generic;

namespace postToPre
{
    class Program
    {
        static bool isOperator(char c){
            switch(c){
                case '+':
                case '-':
                case '*':
                case '^':
                case '/':
                    return true;
                


            }
               return false;
                
        }
        static string postToPre(string str){
            string result="";
            Stack<string> stack = new Stack<string>();
            for(int i=0;i<str.Length;i++){

                if(isOperator(str[i])){
                    string op1,op2;
                    op1 = stack.Pop();
                    op2 = stack.Pop();
                    string temp =  str[i]+op2+op1;
                    stack.Push(temp);

                }
                else{
                    stack.Push(Convert.ToString(str[i]));
                }
            }
            while(stack.Count>0)
            {
                result+=stack.Pop();
            }
            return result;

        }
        static void Main(string[] args)
        {
            string str = "abcd^e-fgh*+^*+i-";
            string s;
            s = postToPre(str);
            Console.WriteLine(s);

        }
    }
}
