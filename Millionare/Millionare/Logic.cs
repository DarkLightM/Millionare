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
            reader.Close();
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
            reader.Close();
            return trueAnswers;
        }

        public Dictionary<string, string> FillTable(string path)
        {
            StreamReader reader = new StreamReader(path);
            Dictionary<string, string> scores = new Dictionary<string, string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                scores.Add(line.Split(' ')[0], line.Split(' ')[1]);
            }
            scores = scores.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            reader.Close();
            return scores;
        }

        public Button[] HideButton(Button[] buttons, string trueAnswer)
        {
            int pos = 0;
            Button[] result = new Button[2];
            for (int i = 0; i < 4; i++)
            {
                if (buttons[i].Content.Equals(trueAnswer))
                    pos = i;
            }
            if (pos < 2)
            {
                result[0] = buttons[2];
                result[1] = buttons[3];
            }
            else
            {
                result[0] = buttons[0];
                result[1] = buttons[1];
            }
            return result;
        }

        public void FillInScores(string path, string name, string scoresToWrite)
        {
            Dictionary<string, string> scores = FillTable(path);
            if (scores.ContainsKey(name))
                scores[name] = scoresToWrite;
            else
                scores.Add(name, scoresToWrite);
            StreamWriter writer = new StreamWriter(path);
            foreach (var pair in scores)
            {
                writer.WriteLine(pair.Key + " " + pair.Value.ToString());
            }
            writer.Close();
        }
    }
}
