using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text;
using System.Threading.Tasks;

namespace Millionare
{
    class Logic
    {
        public Dictionary<string, string[]> FillDictionary(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            Dictionary<string, string[]> result = new Dictionary<string, string[]>();
            while ((line = reader.ReadLine()) != null)
            {
                string[] arr = line.Split('?');
                result.Add(arr[0], arr[1].Split('_'));
            }
            return result;
        }

        public List<string> FillTrueAnswers(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            List<string> trueAnswers = new List<string>();
            while ((line = reader.ReadLine()) != null)
            {
                trueAnswers.Add(line);
            }
            return trueAnswers;
        }

        public Dictionary<string, int> FillTable(string path)
        {
            StreamReader reader = new StreamReader(path);
            Dictionary<string, int> scores = new Dictionary<string, int>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                scores.Add(line.Split(' ')[0], Convert.ToInt32(line.Split(' ')[1]));
            }
            scores = scores.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return scores;
        }

        public Button[] DeleteButton(Button[] buttons, string trueAnswer)
        {
            Random rnd = new Random();
            Button[] result = new Button[2];
            int first = rnd.Next(0,2);
            int second = rnd.Next(2,4);
        }

        public bool CheckButton(Button button, string trueAnswer)
        {
            if (button.Content.Equals(trueAnswer))
                return true;
            return false;
        }
    }
}
