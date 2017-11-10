using AirTrafficControl.ATC;
using AirTrafficControl.Model;
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
            this.AircraftQueue = new ObservableCollectionFast<Aircraft>();
            SetOutput("UI running. Press start before queuing aircraft.");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private AirTrafficController airTrafficController;

        private AcType selectedAcType;
        public AcType SelectedAcType
        {
            get { return selectedAcType; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref selectedAcType, value, nameof(SelectedAcType)); }
        }

        private AcSize selectedAcSize;
        public AcSize SelectedAcSize
        {
            get { return selectedAcSize; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref selectedAcSize, value, nameof(SelectedAcSize)); }
        }


        private ObservableCollectionFast<Aircraft> aircraftQueue;
        public ObservableCollectionFast<Aircraft> AircraftQueue
        {
            get { return aircraftQueue; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref aircraftQueue, value, nameof(AircraftQueue)); }
        }

        private string output;
        /// <summary>
        /// Used to show output messages.
        /// </summary>
        public string Output
        {
            get { return output; }
            set { PropertyChangedUtil.SetField(this, PropertyChanged, ref output, value, nameof(Output)); }
        }

        private void SetOutput(string str)
        {
            Output = str;
        }

        private void SetOutput(string format, params object[] args)
        {
            SetOutput(string.Format(format, args));
        }

        private void UpdateAircraftQueue()
        {
            AircraftQueue.Clear();
            AircraftQueue.AddRange(airTrafficController.GetQueue());
        }

        private void HandleAirTrafficControlException(AirTrafficControlException ex)
        {
            Output = ex.Message;
        }

        /// <summary>
        /// Call to request dequeue.
        /// 
        /// System must be started
        /// </summary>
        public void RequestDequeue()
        {
            try
            {
                var r = new RequestDequeue();
                airTrafficController.aqmRequestProcess(r);
                Aircraft a = r.Aircraft;

                if (a == null)
                {
                    SetOutput("Queue is empty.");
                }
                else
                {
                    SetOutput("Dequeued: {0}", a);
                }

            }
            catch (AirTrafficControlException aex)
            {
                HandleAirTrafficControlException(aex);
            }

            UpdateAircraftQueue();
        }

        /// <summary>
        /// Call to request enqueue.
        /// 
        /// System must be started.
        /// 
        /// Uses SelectedAcType and SelectedAcSize.
        /// </summary>
        public void RequestEnqueue()
        {
            try
            {
                Aircraft a = new Aircraft(SelectedAcType, SelectedAcSize);
                var r = new RequestEnqueue(a);
                airTrafficController.aqmRequestProcess(r);
                SetOutput("Enqueued: {0}", a);
            }
            catch (AirTrafficControlException aex)
            {
                HandleAirTrafficControlException(aex);
            }

            UpdateAircraftQueue();
        }

        /// <summary>
        /// Call to request start.
        /// </summary>
        public void RequestStart()
        {
            try
            {
                var r = new RequestStart();
                airTrafficController.aqmRequestProcess(r);
                SetOutput("Started");
            }
            catch (AirTrafficControlException aex)
            {
                HandleAirTrafficControlException(aex);
            }

            UpdateAircraftQueue();
        }

        /// <summary>
        /// Call to request stop.
        /// </summary>
        public void RequestStop()
        {
            try
            {
                var r = new RequestStop();
                airTrafficController.aqmRequestProcess(r);
                SetOutput("Stopped");
            }
            catch (AirTrafficControlException aex)
            {
                HandleAirTrafficControlException(aex);
            }

            UpdateAircraftQueue();
        }
    }
}
