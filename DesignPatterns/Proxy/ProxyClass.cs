using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{

    public interface IHardware
    {
        void TurnOn();
        void TurnOff();
        void SetChannel(int ch);
    }

    public class TV : IHardware
    {
        public void SetChannel(int ch)
        {
            Console.WriteLine(String.Format("Kanał zmieniony na: {0}", ch));
        }

        public void TurnOff()
        {
            Console.WriteLine(String.Format("Telewizor został wyłączony."));
        }

        public void TurnOn()
        {
            Console.WriteLine(String.Format("Telewizor został włączony."));
        }
    }

    public class Radio : IHardware
    {
        public void SetChannel(int ch)
        {
            Console.WriteLine(String.Format("Kanał zmieniony na: {0}", ch));
        }

        public void TurnOff()
        {
            Console.WriteLine(String.Format("Radio zostało wyłączone."));
        }

        public void TurnOn()
        {
            Console.WriteLine(String.Format("Radio zostało włączone."));
        }
    }

    public class ProxyController
    {
        private int currentCH;
        private int previousCH;
        protected IHardware[] _hardware;

        protected IHardware[] Hardware
        {
            get
            {
                if (_hardware == null) _hardware = new IHardware[2]
                {
                    new Radio(), new TV()
                };
                return _hardware;
            }
        }

        public ProxyController()
        {
            this._hardware = Hardware;
            currentCH = -1;
            previousCH = -1;
        }

        public void TurnOn()
        {
            foreach (IHardware hw in _hardware)
            {
                hw.TurnOn();
            }
        }

        public void TurnOff()
        {
            foreach (var hw in _hardware)
            {
                hw.TurnOff();
            }
        }

        public void SetChannel(int ch)
        {
            previousCH = currentCH;
            currentCH = ch;
            foreach (var hw in _hardware)
            {
                hw.SetChannel(ch);
            }
        }

        public void SetPreviousChannel()
        {
            SetChannel(previousCH);
        }
    }

}
