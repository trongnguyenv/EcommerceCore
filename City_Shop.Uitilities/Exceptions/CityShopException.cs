using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace City_Shop.Uitilities.Exceptions
{
    public class CityShopException : Exception
    {
        public CityShopException()
        {
        }

        public CityShopException(string message) : base(message)
        {
        }

        public CityShopException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
