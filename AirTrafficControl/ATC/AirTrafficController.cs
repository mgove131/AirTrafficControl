using AirTrafficControl.ATC;
using AirTrafficControl.Model.Request;
using System;

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

        }

        private void process(RequestDequeue req)
        {
            Console.WriteLine("RequestDequeue");
        }

        private void process(RequestEnqueue req)
        {
            Console.WriteLine("RequestEnqueue");
        }

        private void process(RequestStart req)
        {
            Console.WriteLine("RequestStart");
        }

        private void process(RequestStop req)
        {
            Console.WriteLine("RequestStop");
        }

        /// <summary>
        /// Processes Requests.
        /// </summary>
        /// <param name="req">Request</param>
        public void aqmRequestProcess(Request req)
        {
            if (req is RequestDequeue)
            {
                process((RequestDequeue)req);
            }
            else if (req is RequestEnqueue)
            {
                process((RequestEnqueue)req);
            }
            else if (req is RequestStart)
            {
                process((RequestStart)req);
            }
            else if (req is RequestStop)
            {
                process((RequestStop)req);
            }
            else
            {
                throw new AirTrafficControlException("Invalid Request");
            }
        }
    }
}
