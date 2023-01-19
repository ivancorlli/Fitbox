using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedKernell.src.ValueObject
{
    public sealed record TimeStamps
    {
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }

        public TimeStamps()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        private TimeStamps(DateTime updated)
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = updated;
        }

        public TimeStamps Updated()
        {
            return new TimeStamps(DateTime.Now);
        }

    }
}