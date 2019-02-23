using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// Interfejs defniujący pracę urządzeń
    /// </summary>
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

    public class Controller
    {
        private int currentCH;
        private int previousCH;
        protected IHardware hardware;

        public Controller(IHardware hardware)
        {
            this.hardware = hardware;
            currentCH = -1;
            previousCH = -1;
        }

        public void TurnOn()
        {
            hardware.TurnOn();
        }

        public void TurnOff()
        {
            hardware.TurnOff();
        }

        public void SetChannel(int ch)
        {
            previousCH = currentCH;
            currentCH = ch;
            hardware.SetChannel(ch);
        }

        public void SetPreviousChannel()
        {
            SetChannel(previousCH);
        }
    }
}
