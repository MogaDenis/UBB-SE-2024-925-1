namespace NamespaceCBlurred_Frontend
{
    public partial class MainPage : ContentPage
    {
        public int Count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Count++;

            if (Count == 1)
            {
                CounterBtn.Text = $"Clicked {Count} time";
            }
            else
            {
                CounterBtn.Text = $"Clicked {Count} times";
            }

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
