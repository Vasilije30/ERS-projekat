using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Model;
using ConsoleApp14;
using System.IO;

namespace Ucitavanje
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IModel> channel =
                 new ChannelFactory<IModel>("ServiceName");

             IModel proxy = channel.CreateChannel();

             Console.ReadLine();
             UIHandler handler = new UIHandler();
             handler.meni();
        }
    }

}

