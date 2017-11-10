using AirTrafficControl.Model;
using System.Collections.Generic;

namespace AirTrafficControl.ATC.Queue
{
    /// <summary>
    /// Stores aircraft in different buckets for faster dequeuing.
    /// </summary>
    public class AtcQueueBuckets : IAtcQueue
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AtcQueueBuckets()
        {
        }

        private Queue<Aircraft> queuePassengarLarge { get; } = new Queue<Aircraft>();

        private Queue<Aircraft> queuePassengarSmall { get; } = new Queue<Aircraft>();

        private Queue<Aircraft> queueCargoLarge { get; } = new Queue<Aircraft>();

        private Queue<Aircraft> queueCargoSmall { get; } = new Queue<Aircraft>();

        public Aircraft Dequeue()
        {
            Aircraft a = null;

            Queue<Aircraft> queue = null;
            if (queuePassengarLarge.Count > 0)
            {
                queue = queuePassengarLarge;
            }
            else if (queuePassengarSmall.Count > 0)
            {
                queue = queuePassengarSmall;
            }
            else if (queueCargoLarge.Count > 0)
            {
                queue = queueCargoLarge;
            }
            else if (queueCargoSmall.Count > 0)
            {
                queue = queueCargoSmall;
            }

            if (queue != null)
            {
                a = queue.Dequeue();
            }

            return a;
        }

        public void Enqueue(Aircraft a)
        {
            if (a == null) return;

            Queue<Aircraft> queue = null;
            if ((a.Type == AcType.Passenger) && (a.Size == AcSize.Large))
            {
                queue = queuePassengarLarge;
            }
            else if ((a.Type == AcType.Passenger) && (a.Size == AcSize.Small))
            {
                queue = queuePassengarSmall;
            }
            else if ((a.Type == AcType.Cargo) && (a.Size == AcSize.Large))
            {
                queue = queueCargoLarge;
            }
            else if ((a.Type == AcType.Cargo) && (a.Size == AcSize.Small))
            {
                queue = queueCargoSmall;
            }

            if (queue == null)
            {
                throw new AirTrafficControlException(string.Format("AtcQueueBuckets: Aircraft has invalid properties. Cannot Enqueue. {0}", a));
            }
            else
            {
                queue.Enqueue(a);
            }
        }

        public List<Aircraft> GetQueue()
        {
            List<Aircraft> queue = new List<Aircraft>();
            queue.AddRange(queuePassengarLarge);
            queue.AddRange(queuePassengarSmall);
            queue.AddRange(queueCargoLarge);
            queue.AddRange(queueCargoSmall);
            return queue;
        }
    }
}
