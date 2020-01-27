using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midi;

namespace Playables
{
    public interface IPlayable
    {
        void Play(int duration);
    }

    public class Drum : IPlayable
    {
        public void Play(int duration)
        {
            Console.WriteLine("drum is playing for {0} seconds", duration);

            
            
        }
    }

    public class Piano : IPlayable
    {
        public void Play(int duration)
        {
            Console.WriteLine("piano is playing for {0} seconds", duration);
        }
    }

    public class Guitar : IPlayable
    {
        public void Play(int duration)
        {
            Console.WriteLine("guitar is playing for {0} seconds", duration);
        }
    }
}
