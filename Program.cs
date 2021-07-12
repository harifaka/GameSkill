using System;
using System.Text;

using System.Collections.Generic;
using FileCreator;
namespace GameSkills
{
    class Program
    {
        private static ParameterHelper parameters;
        private static ParameterHelper content;
        private static List<string> skillLabels;
        private static List<string> infos;
        private static  List<string> champs;
        private static int goodAnswer;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello - This is a questioner game, what ask based on the database !");
            System.Threading.Thread.Sleep(500);
            goodAnswer = 0;
            
            parameters = new ParameterHelper(".config");
            infos = parameters.getFileLines();
            //Console.WriteLine(parameters.GenerateInfo());

            //Console.WriteLine(parameters.getFilePath());
            //content = new ParameterHelper("lolkepessegek.csv");
            content = new ParameterHelper("latinkifejezesek.csv");
            champs = content.getFileLines();
            //Console.WriteLine(content.GenerateInfo());

            skillLabels = new List<string>();
            foreach (var item in champs[0].Split(";"))
            {
                if(item.Length>0) skillLabels.Add(item);
            }
            int questionNum = Int32.Parse(parameters.getQuestionNumber());
            System.Threading.Thread.Sleep(500);
            for (int i = 0; i < questionNum; i++)
            {
                Console.Clear();
                Console.WriteLine("-------"+"The "+(i+1)+"/"+questionNum + " question is:"+"-------");
                DoQuestion();
                System.Threading.Thread.Sleep(1500);
            }

            string result = Environment.NewLine;
            Console.Clear();
            result += "CONGRATULATION!" + Environment.NewLine;
            result += goodAnswer + " good answer from "+ questionNum + Environment.NewLine;
            //CreateFiles();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(result);
            System.Threading.Thread.Sleep(1000);

            //Console.WriteLine("Goodbye League of Legends champion ability questioner");
            //System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
        
        static void DoQuestion(){
            Random rnd = new Random();
            int randSkill = rnd.Next(skillLabels.Count-1)+1;
            int randChamp = rnd.Next(champs.Count-1)+1;
            string question = "What is the " + skillLabels[randSkill]+ " skill of"+ Environment.NewLine;
            question+= champs[randChamp].Split(";")[0] + "?" + Environment.NewLine;
            question = champs[randChamp].Split(";")[0] + " - " + skillLabels[randSkill] + Environment.NewLine;
            string ability = champs[randChamp].Split(";")[randSkill];
            if(parameters.getCheat()){
               question+= "Help: " + ability;
            }
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            if(answer.ToLower().Equals(ability.ToLower().Trim())){
                Console.WriteLine("Correct!");
                goodAnswer++;
            } else {
                Console.WriteLine("Incorrect!");
                Console.WriteLine("Your asnwer was: " + answer);
                Console.WriteLine("The correct answer is: "+ ability + Environment.NewLine);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        }
        static void CreateFiles()
        {
            List<string> files = new List<string>();
            files.Add("first.list");
            FileCreator.FileCreator.CreateFiles(files, "newfilelist.txt", null);
        }
    }
}
