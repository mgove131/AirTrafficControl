using AirTrafficControl.Model;
using System;
using System.Collections.Generic;

namespace AirTrafficControl.ATC.Queue
{
    /// <summary>
    /// Stores aircraft in different buckets for faster dequeuing.
    /// This doesn't have hardcoded queues, so adding more queues is easier.
    /// </summary>
    public class AtcQueueBucketsExpandable : IAtcQueue
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AtcQueueBucketsExpandable()
        {
            int numQueues = Enum.GetNames(typeof(AcType)).Length * Enum.GetNames(typeof(AcSize)).Length;
            for (int i = 0; i < numQueues; i++)
            {
                queues.Add(new Queue<Aircraft>());
            }
        }

        /// <summary>
        /// Contains all the buckets needed. Highest priority should be first in the list.
        /// </summary>
        private List<Queue<Aircraft>> queues { get; } = new List<Queue<Aircraft>>();

        public Aircraft Dequeue()
        {
            Aircraft a = null;

            foreach (Queue<Aircraft> q in queues)
            {
                if (q.Count > 0)
                {
                    a = q.Dequeue();
                    break;
                }
            }

            return a;
        }

        public void Enqueue(Aircraft a)
        {
            if (a == null) return;

            Queue<Aircraft> queue = null;
            if ((a.Type == AcType.Passenger) && (a.Size == AcSize.Large))
            {
                queue = queues[0];
            }
            else if ((a.Type == AcType.Passenger) && (a.Size == AcSize.Small))
            {
                queue = queues[1];
            }
            else if ((a.Type == AcType.Cargo) && (a.Size == AcSize.Large))
            {
                queue = queues[2];
            }
            else if ((a.Type == AcType.Cargo) && (a.Size == AcSize.Small))
            {
                queue = queues[3];
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
            foreach (Queue<Aircraft> q in queues)
            {
                queue.AddRange(q);
            }
            return queue;
        }
    }
}
