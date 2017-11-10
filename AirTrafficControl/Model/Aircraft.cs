﻿namespace AirTrafficControl.Model
{
    /// <summary>
    /// Represents an air craft.
    /// </summary>
    public class Aircraft
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static Aircraft()
        {
            ID = 0;
        }

        /// <summary>
        /// Static ID used to keep track of the Aircraft ID.
        /// </summary>
        private static int ID;

        /// <summary>
        /// Gets the correct ID for an Aircraft.
        /// </summary>
        /// <returns>ID</returns>
        private static int getNextId()
        {
            return ++ID;
        }

        /// <summary>
        /// Aircraft type.
        /// </summary>
        public enum AcType { Passenger, Cargo };

        /// <summary>
        /// Aircraft size.
        /// </summary>
        public enum AcSize { Small, Large };

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="type">Aircraft type</param>
        /// <param name="size">Aircraft size</param>
        public Aircraft(AcType type, AcSize size)
        {
            this.Id = getNextId();
            this.Type = type;
            this.Size = size;
        }

        public int Id { get; private set; }

        public AcType Type { get; private set; }

        public AcSize Size { get; private set; }
    }
}
