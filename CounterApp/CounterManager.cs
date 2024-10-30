using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Storage;

namespace CounterApp
{
    public class CounterManager
    {
        private const string FileName = "counters.json";
        private string FilePath => Path.Combine(FileSystem.AppDataDirectory, FileName);

        public ObservableCollection<CounterModel> Counters { get; private set; }

        public CounterManager()
        {
            Counters = new ObservableCollection<CounterModel>();
            LoadCounters();
        }

        public void AddCounter(string name, int initialValue, Color color)
        {
            var counter = new CounterModel(name, initialValue, color);
            Counters.Add(counter);
            SaveCounters();
        }

        public void UpdateCounter(CounterModel counter)
        {
            SaveCounters();
        }

        private void LoadCounters()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                var counters = JsonSerializer.Deserialize<List<CounterModel>>(json);
                if (counters != null)
                {
                    Counters.Clear();
                    foreach (var counter in counters)
                    {
                        Counters.Add(counter);
                    }
                }
            }
        }

        public void SaveCounters()
        {
            var json = JsonSerializer.Serialize(Counters);
            File.WriteAllText(FilePath, json);
        }
    }
}
