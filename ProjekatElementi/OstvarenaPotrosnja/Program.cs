using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OstvarenaPotrosnja
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IIspis> channel = new ChannelFactory<IIspis>("Servis");

            IIspis proxy = channel.CreateChannel();
        }
    }
}
