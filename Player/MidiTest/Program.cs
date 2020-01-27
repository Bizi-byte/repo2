using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Sanford.Multimedia.Midi;
using Commons.Music.Midi;
using Commons.Music.Midi.WinMM;

using NAudio.Midi;

using Windows.Devices.Enumeration;
//using Windows.Devices.Midi;
using System.Runtime.InteropServices;




namespace MidiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            PrintMidi();
            //MidiToolkit();
            Naudio();
            
        }

        private static void Print(ChannelMessageBuilder b)
        {
            Console.WriteLine(b.Result);
        }

        private static void PrintMidi()
        {
            var access = MidiAccessManager.Default;

            if(access.Outputs.Count() != 0)
            {
                var output = access.OpenOutputAsync(access.Outputs.Last().Id).Result;

                Console.WriteLine(access.Outputs.Last().Name);
                Console.WriteLine(access.Outputs.Last().Id);
            }

        }

        private static void Naudio()
        {
            
            Console.WriteLine(MidiOut.NumberOfDevices);
            //MidiOut m = new MidiOut(0);
        }

        private static void MidiToolkit()
        {
            ChannelMessageBuilder b = new ChannelMessageBuilder();
            b.Command = ChannelCommand.NoteOn;
            b.MidiChannel = 0;
            b.Data1 = 80;
            b.Data2 = 127;
            b.Build();
            Print(b);

            ChannelMessageBuilder b2 = new ChannelMessageBuilder();
            b2.Command = ChannelCommand.NoteOff;
            b2.MidiChannel = 10;
            b2.Data1 = 35;
            b2.Data2 = 64;
            b2.Build();
            Print(b);

            MetaTextBuilder mb = new MetaTextBuilder();
            mb.Type = MetaType.InstrumentName;
            mb.Text = "drum";
            mb.Build();

            OutputDevice device = new OutputDevice(0);
            device.Send(b.Result);
            device.Close();

            OutputStream os = new OutputStream(0);
            os.Send(b.Result);
            os.StartPlaying();

            Thread.Sleep(5000);

            os.Close();

        }

        
        
    }
}
