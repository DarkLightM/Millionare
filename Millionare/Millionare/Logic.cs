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
    }
}
