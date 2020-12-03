using System;

namespace alignLeft
{
    class Program
    {
        public static  string[] words;
        public static  string[] result;
        public static string final(int line,int start,int end,int lineSize){
             string sav = "";


            for(int j=start;j<end;j++)
            {
                if(j!=(end-1))
                    sav+=Program.words[j]+" ";
                else
                {
                    sav+=Program.words[j];
                }
            }
            for(int j=1;j<=line;j++)
            {
                if(j%2==1)
                    sav = sav + " ";
                else
                {
                    sav = " "+sav;
                }
            }


            return sav;
        }

        public static string leftAlign(int count,int lineSize){
            
             int curLineLen = 0;
             int wordCount = 0;
             int wordstart = 0;
             int c=0;

            for(int i=0;i<count;i++)
            {
                
                Program.result = new string[10000];
               
               
               int check = curLineLen+Program.words[i].Length+wordCount;
               ++wordCount;
                


                if(check==lineSize){

                    
                   
                    Console.WriteLine(final(0,wordstart,wordstart+wordCount,lineSize));
                    
                    wordstart = i+1;
                    wordCount = 0;
                    curLineLen=0;

                     
                     

                }
                else if(check>lineSize){
                   
                    
                    
                    int line = lineSize - (check-Program.words[i].Length-1);
                      Console.WriteLine(final(line,wordstart,wordstart+wordCount-1,lineSize));
                    

                    
                    


                    wordstart = i;
                    wordCount=1;
                    curLineLen =Program.words[i].Length;

                   

                }
                else{
                   
                 
                     curLineLen+=Program.words[i].Length;

                }
               
               


                
            }
            if(curLineLen!=0)
            {
                int line = lineSize - (curLineLen+wordCount);
                Console.WriteLine(final(line,wordstart,wordstart+wordCount,lineSize));
                    
            }

            // for(int i=0;i<c;i++)
            // {
            //     Console.WriteLine(Program.result[i]);
            // }
            return "ab0";
               

        }
        static void Main(string[] args)
        {
            string str = "A paragraph is a series of related sentences developing a central idea, called the topic. Try to think about paragraphs in terms of thematic unity: a paragraph is a sentence or a group of sentences that supports one central, unified idea. Paragraphs add one idea at a time to your broader argument.";
            string word = "";
            int count=0;
            Program.words = new string[10000];
            for(int i=0;i<str.Length;i++)
            {
                if(str[i]!=' '){
                    word+=str[i];
                }
                else
                {
                   Program.words[count++] = word;
                   word="";
                    
                }
            }
           
            leftAlign(count,20);


            
        }
    }
}
