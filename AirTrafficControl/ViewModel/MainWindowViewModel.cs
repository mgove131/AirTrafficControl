using AirTrafficControl.Model.Request;
using AirTrafficControl.ViewModel.ATC;
using System.ComponentModel;

namespace AirTrafficControl.ViewModel
{
    /// <summary>
    /// MainWindow ViewModel.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindowViewModel()
        {
            this.airTrafficController = new AirTrafficController();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private AirTrafficController airTrafficController;

        private string output;
        /// <summary>
        /// Used to show output messages.
        /// </summary>
        public string Output
        {
            get { return output; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref output, value, nameof(Output)); }
        }

        /// <summary>
        /// Call to request dequeue.
        /// 
        /// System must be started
        /// </summary>
        public void RequestDequeue()
        {
            Request r = new RequestDequeue();
            airTrafficController.aqmRequestProcess(r);
        }

        /// <summary>
        /// Call to request enqueue.
        /// 
        /// System must be started.
        /// </summary>
        public void RequestEnqueue()
        {
            airTrafficController.aqmRequestProcess(new RequestEnqueue());
        }

        /// <summary>
        /// Call to request start.
        /// </summary>
        public void RequestStart()
        {
            airTrafficController.aqmRequestProcess(new RequestStart());
        }

        /// <summary>
        /// Call to request stop.
        /// </summary>
        public void RequestStop()
        {
            airTrafficController.aqmRequestProcess(new RequestStop());
        }
    }
}
