using AirTrafficControl.ATC;
using AirTrafficControl.ATC.Queue;
using AirTrafficControl.Model;
using AirTrafficControl.Model.Request;
using System.Collections.Generic;

namespace AirTrafficControl.ViewModel.ATC
{
    /// <summary>
    /// Air-traffic control system is defined to manage a queue of aircraft(AC) in an airport.
    /// </summary>
    public class AirTrafficController
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AirTrafficController()
        {
            this.Queue = new AtcQueueLinq();
            this.IsRunning = false;
        }

        private IAtcQueue Queue { get; set; }

        public bool IsRunning { get; private set; }

        private void EnsureStopped()
        {
            if (IsRunning)
            {
                throw new AirTrafficControlException("Request failed. AirTrafficController should be stopped.");
            }
        }

        private void EnsureStarted()
        {
            if (!IsRunning)
            {
                throw new AirTrafficControlException("Request failed. AirTrafficController should be started.");
            }
        }

        private void Process(RequestDequeue req)
        {
            EnsureStarted();
            req.Aircraft = Queue.Dequeue();
        }

        private void Process(RequestEnqueue req)
        {
            EnsureStarted();
            Queue.Enqueue(req.Aircraft);
        }

        private void Process(RequestStart req)
        {
            EnsureStopped();
            IsRunning = true;
        }

        private void Process(RequestStop req)
        {
            EnsureStarted();
            IsRunning = false;
        }

        /// <summary>
        /// Processes Requests.
        /// </summary>
        /// <param name="req">Request</param>
        public void aqmRequestProcess(Request req)
        {
            if (req is RequestDequeue)
            {
                Process((RequestDequeue)req);
            }
            else if (req is RequestEnqueue)
            {
                Process((RequestEnqueue)req);
            }
            else if (req is RequestStart)
            {
                Process((RequestStart)req);
            }
            else if (req is RequestStop)
            {
                Process((RequestStop)req);
            }
            else
            {
                throw new AirTrafficControlException("Invalid Request");
            }
        }

        /// <summary>
        /// Returns queued aircraft.
        /// </summary>
        /// <returns>Queued aircraft.</returns>
        public List<Aircraft> GetQueue()
        {
            return Queue.GetQueue();
        }
    }
}
