using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace GameSkills
{
    class ParameterHelper
    {
        private string path;
        private string rawLines;
        private List<string> parametes;
        public ParameterHelper(string path)
        {
            this.path = path;
            parametes = null;
        }

        public List<string> getFileLines(){
            if(path == null){
                Console.WriteLine("The path is not valid!");
            } else
            if(parametes == null){
                parametes = new List<string>();
                try{
                    foreach (var item in File.ReadAllLines(path))
                    {
                        parametes.Add(item);
                    }
                }
                catch (Exception e)
                {
                    String err = e.Message;
                    if(err.IndexOf("Could not find")>=0){
                        Console.Write("The folder ["+ path +"] is not valid! ");
                        Console.WriteLine("Please add a correct path and restart the software!");
                        System.Threading.Thread.Sleep(2500);
                        return null;
                    } else {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return parametes;
        }

        public string GenerateInfo(){
            int count = parametes.Count;
            string ret = "The number of lines is "+ count;
            return ret;
        }

        public string getFilePath(){
            string ret = "";
            foreach (var item in parametes)
            {
                if(item.ToLower().Contains("file")){
                    ret=item.Split(":")[1];
                }
            }
            return ret;
        }
        public string getQuestionNumber(){
            string ret = "";
            foreach (var item in parametes)
            {
                if(item.ToLower().Contains("question")){
                    ret=item.Split(":")[1];
                }
            }
            return ret;
        }
        public bool getCheat(){
            bool ret = false;
            foreach (var item in parametes)
            {
                if(item.ToLower().Contains("cheat")){
                    ret=true;
                }
            }
            return ret;
        }

    }
}