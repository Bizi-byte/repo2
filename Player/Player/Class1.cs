using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playables;
using Factory;
using SingletonUtil;
using JsonParser;


namespace Player
{
    public class MusicPlayer
    {
        List<Tuple<IPlayable, int>> PlayList = new List<Tuple<IPlayable, int>>();
        CreatorFactory<IPlayable, string> Factory = new CreatorFactory<IPlayable, string>();

        public MusicPlayer()
        {
            Factory.Add("drum", Singleton<Drum>.Create);
            Factory.Add("piano", Singleton<Piano>.Create);
            Factory.Add("guitar", Singleton<Guitar>.Create);
        }
        public void Load(string musicFilePath)
        {
            List<Tuple<string, int>> parsedFile = new Parser(musicFilePath).ToPlay;

            foreach(Tuple<string, int> tuple in parsedFile)
            {
                PlayList.Add(new Tuple<IPlayable, int>(Factory.Create(tuple.Item1), tuple.Item2));
            }

        }

        public void Play()
        {
            foreach(Tuple<IPlayable, int> tuple in PlayList)
            {
                tuple.Item1.Play(tuple.Item2);
            }
        }
    }
}
