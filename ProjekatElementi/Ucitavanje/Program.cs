using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Model;

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
        }
    }

}

