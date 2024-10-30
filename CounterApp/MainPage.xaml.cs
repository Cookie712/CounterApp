using Microsoft.Maui.Controls;

    namespace CounterApp
    {
    public partial class MainPage : ContentPage
    {
        private CounterManager counterManager;

        public MainPage()
        {
            InitializeComponent();
            counterManager = new CounterManager();
            BindingContext = counterManager;
        }

        private async void OnAddCounterClicked(object sender, EventArgs e)
        {
            string name = await DisplayPromptAsync("Nazwa Twojego licznika", "Podaj nazwę licznika:");
            if (int.TryParse(await DisplayPromptAsync("Wartość początkowa Twojego licznika", "Podaj wartość początkową licznika:"), out int initialValue))
            {
                string colorName = await DisplayActionSheet("Wybierz kolor", "Anuluj", null, "Pomarańczowy", "Zielony", "Różowy", "Fioletowy", "Czerwony", "Szary");

                if (colorName != null && colorName != "Anuluj")
                {
                    Color color = GetColorFromName(colorName);
                    counterManager.AddCounter(name, initialValue, color);
                }
            }
        }

        private Color GetColorFromName(string colorName)
        {
            return colorName switch
            {
                "Pomarańczowy" => Colors.Orange,
                "Zielony" => Colors.LightGreen,
                "Różowy" => Colors.LightPink,
                "Fioletowy" => Colors.MediumPurple,
                "Czerwony" => Colors.Coral,
                "Szary" => Colors.LightGray,
                _ => Colors.LightGray, 
            };
        }

        private void OnIncreaseClicked(object sender, EventArgs e)
        {
            var counter = (CounterModel)((Button)sender).CommandParameter;
            counter.Value++; 
            counterManager.UpdateCounter(counter); 
        }

        private void OnDecreaseClicked(object sender, EventArgs e)
        {
            var counter = (CounterModel)((Button)sender).CommandParameter;
            counter.Value--;
            counterManager.UpdateCounter(counter); 
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            var counter = (CounterModel)((Button)sender).CommandParameter;
            counter.Value = counter.InitialValue; 
            counterManager.UpdateCounter(counter); 
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            var counter = (CounterModel)((Button)sender).CommandParameter;
            counterManager.Counters.Remove(counter); 
            counterManager.SaveCounters();
        }
    }
}

