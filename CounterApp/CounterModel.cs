using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace CounterApp
{
    public class CounterModel : INotifyPropertyChanged
    {
        private string name;
        private int counterValue;
        private int initialValue;
        private string colorHex; 

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Value
        {
            get => counterValue;
            set
            {
                counterValue = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public int InitialValue
        {
            get => initialValue;
            private set => initialValue = value;
        }

        public string ColorHex 
        {
            get => colorHex;
            set
            {
                colorHex = value;
                OnPropertyChanged(nameof(ColorHex));
            }
        }

        public Color Color => Color.FromHex(ColorHex); 

        public CounterModel(string name, int initialValue, Color color)
        {
            Name = name;
            InitialValue = initialValue;
            Value = initialValue;
            ColorHex = color.ToHex();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
