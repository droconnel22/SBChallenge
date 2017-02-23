using System;
using System.Configuration;

namespace Shipbob.Service.Configuration
{
    public  class ServiceConfiguration : IServiceConfiguration
    {
        public int LoadItemCountFromDatabase
        {
            get
            {
              string loadItemsCount = ConfigurationManager.AppSettings["LoadItemsFromDatabase"];
                if (string.IsNullOrEmpty(loadItemsCount)) return 25;

                int result = 25;
                Int32.TryParse(loadItemsCount, out result);
                return result;
            }
        }
    }
}