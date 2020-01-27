using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace JsonParser
{
    public class MusicPart
    {
        public string Instrument;
        public int Duration;
        public MusicPart(string instrument, int duration)
        {
            Instrument = instrument;
            Duration = duration;
        }
    }
    public class Parser
    {
        public List<Tuple<string, int>> ToPlay = new List<Tuple<string, int>>();
        public Parser(string path)
        {
            FileStream f = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(f);
            string json = sr.ReadToEnd();
            //Console.WriteLine(json);

            JObject o = JObject.Parse(@json);
            JArray play = (JArray)o["play"];

            for (int i = 0; i < play.Count; ++i)
            {
                ToPlay.Add(new Tuple<string, int>((string)play[i]["instrument"], (int)play[i]["duration"]));
                //Console.WriteLine("{0}, {1}", part.Item1, part.Item2);
            }
        }

        
    }
}
