using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public class GiftException : Exception
    {
        public GiftException(string message) : base(message) { }
    }

    public class InvalidWeightException : GiftException
    {
        public InvalidWeightException(string message) : base(message) { }
    }

    public class InvalidSweetnessLevelException : GiftException
    {
        public InvalidSweetnessLevelException(string message) : base(message) { }
    }

    public class InvalidCocoaPercentageException : GiftException
    {
        public InvalidCocoaPercentageException(string message) : base(message) { }
    }
    public class InvalidCaramelHardLevel : GiftException
    {
        public InvalidCaramelHardLevel(string message) : base(message) { }
    }

}
