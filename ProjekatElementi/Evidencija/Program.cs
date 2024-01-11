using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Evidencija
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IEvidencija> channel =
                 new ChannelFactory<IEvidencija>("Servis");

            IEvidencija proxy = channel.CreateChannel();

            UIEvidencija ui = new UIEvidencija(proxy);
            ui.meni();

        }
    }
}
