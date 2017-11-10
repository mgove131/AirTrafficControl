using AirTrafficControl.ViewModel;
using System.Windows;

namespace AirTrafficControl.View
{
    /// <summary>
    /// MainWindow.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += (sender, e) =>
            {
                this.DataContext = ViewModel;
            };
        }

        private MainWindowViewModel ViewModel { get; } = new MainWindowViewModel();

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RequestStart();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RequestStop();
        }

        private void EnqueueButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RequestEnqueue();
        }

        private void DequeueButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RequestDequeue();
        }
    }
}
