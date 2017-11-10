namespace AirTrafficControl.Model.Request
{
    /// <summary>
    /// Enqueue aircraft used to insert a new AC into the system.
    /// </summary>
    public class RequestEnqueue : Request
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="a">Aircraft to enqueu</param>
        public RequestEnqueue(Aircraft a)
        {
            this.Aircraft = a;
        }

        public Aircraft Aircraft { get; private set; }
    }
}
