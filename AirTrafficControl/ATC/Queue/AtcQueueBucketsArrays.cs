using AirTrafficControl.Model;
using System;
using System.Collections.Generic;

namespace AirTrafficControl.ATC.Queue
{
    /// <summary>
    /// Stores aircraft in different buckets for faster dequeuing.
    /// This doesn't have hardcoded queues, so adding more queues is easier.
    /// This uses arrays to make the code even cleaner.
    /// 
    /// Enums values must be 0 bases. Also, they should listed from highest to lowest priority.
    /// </summary>
    public class AtcQueueBucketsArrays : IAtcQueue
    {
        public AtcQueueBucketsArrays()
        {
            int typesCount = Enum.GetNames(typeof(AcType)).Length;
            int sizesCount = Enum.GetNames(typeof(AcSize)).Length;

            this.queues = new Queue<Aircraft>[typesCount][];
            for (int i1 = 0; i1 < typesCount; i1++)
            {
                this.queues[i1] = new Queue<Aircraft>[sizesCount];
                for (int i2 = 0; i2 < typesCount; i2++)
                {
                    this.queues[i1][i2] = new Queue<Aircraft>();
                }
            }
        }

        private readonly Queue<Aircraft>[][] queues;

        public Aircraft Dequeue()
        {
            Aircraft a = null;

            foreach (var q1 in queues)
            {
                foreach (var q2 in q1)
                {
                    if (q2.Count > 0)
                    {
                        a = q2.Dequeue();
                        break;
                    }
                }

                //can't label loops to break outer loop, so need this null check
                if (a != null) break;
            }

            return a;
        }

        public void Enqueue(Aircraft a)
        {
            queues[(int)a.Type][(int)a.Size].Enqueue(a);
        }

        public List<Aircraft> GetQueue()
        {
            List<Aircraft> queue = new List<Aircraft>();

            foreach (var q1 in queues)
            {
                foreach (var q2 in q1)
                {
                    queue.AddRange(q2);
                }
            }

            return queue;
        }
    }
}
