using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{

    /// <summary>
    /// Singleton
    /// </summary>

    public static class EventLoger
    {        
        private const string _filePath = "C:\\_temp\\EventsLog.txt";
        public static bool _saveToFileInstantly;
        public static List<string> _eventsList = null;

        public static void Initialize(bool saveToFileInstantly)
        {
            EventLoger._saveToFileInstantly = saveToFileInstantly;

            if (File.Exists(_filePath))
                _eventsList = File.ReadAllLines(_filePath).ToList();
            else
                _eventsList = new List<string>();
        }

        public static void AddEvent(string message)
        {
            _eventsList.Add(message);
            if (_saveToFileInstantly) Save();
        }

        public static void Save()
        {
            try
            {
                File.WriteAllLines(_filePath, _eventsList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
