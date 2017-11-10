using AirTrafficControl.Model;
using System.Collections.Generic;

namespace AirTrafficControl.ATC.Queue
{
    /// <summary>
    /// Supports queuing and dequeueing aircraft.
    /// </summary>
    public interface IAtcQueue
    {
        /// <summary>
        /// Queue aircraft.
        /// </summary>
        /// <param name="a">Aircraft</param>
        void Enqueue(Aircraft a);

        /// <summary>
        /// Dequeue aircraft in a certain order.
        /// </summary>
        /// <returns>Aircraft dequeued.</returns>
        Aircraft Dequeue();

        /// <summary>
        /// Returns queued aircraft.
        /// </summary>
        /// <returns>Queued aircraft.</returns>
        List<Aircraft> GetQueue();
    }
}
