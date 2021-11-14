using System;
using System.Collections.Generic;
using System.Text;

namespace NewDesignMillionAndUpTest.Utilities
{
    public class Constants
    {
        private const int waitSeconds = 60;
        public int WaitSeconds { get { return waitSeconds; } }

        private const string mockarooEndPoint = "https://api.mockaroo.com/api/ac46d8a0?count=1&key=cbb8613";
        public string MockarooEndPoint { get { return mockarooEndPoint; } }

        private const string mockDataAlternative = "[{\"first_name\":\"Desmund\",\"last_name\":\"Vaskov\",\"email\":\"dvaskov0@elpais.com\",\"phone_number\":\"6441052770\"}]";
        public string MockDataAlternative { get { return mockDataAlternative; } }
    }
}
