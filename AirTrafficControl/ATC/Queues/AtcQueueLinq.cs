using AirTrafficControl.Model;
using System.Collections.Generic;
using System.Linq;

namespace AirTrafficControl.ATC.Queues
{
    /// <summary>
    /// Usues Linq to dequeue planes.
    /// </summary>
    public class AtcQueueLinq : IAtcQueue
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AtcQueueLinq()
        {
        }

        private List<Aircraft> queue { get; } = new List<Aircraft>();

        public Aircraft Dequeue()
        {
            Aircraft aircraft;

            aircraft = queue.FirstOrDefault((a) => (a.Type == AcType.Passenger) && (a.Size == AcSize.Large));

            if (aircraft == null)
            {
                aircraft = queue.FirstOrDefault((a) => (a.Type == AcType.Passenger) && (a.Size == AcSize.Small));
            }

            if (aircraft == null)
            {
                aircraft = queue.FirstOrDefault((a) => (a.Type == AcType.Cargo) && (a.Size == AcSize.Large));
            }

            if (aircraft == null)
            {
                aircraft = queue.FirstOrDefault((a) => (a.Type == AcType.Cargo) && (a.Size == AcSize.Small));
            }

            if (aircraft != null)
            {
                //if we found one, remove it from the queue
                queue.Remove(aircraft);
            }

            return aircraft;
        }

        public void Enqueue(Aircraft a)
        {
            if (a == null) return;

            queue.Add(a);
        }

        public List<Aircraft> GetQueue()
        {
            return new List<Aircraft>(queue);
        }
    }
}
