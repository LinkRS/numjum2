using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Text;
using NumJum2.Domain;

namespace NumJum2.Services
{
    public class Factory
    {
        // Constructors
        private Factory() { }
        private static Factory factory = new Factory();
        public static Factory GetInstance()
        {
            return factory;
        }

        // Service Methods
        public IService GetService(string serviceName)
        {
            Type type;
            Object obj = null;

            try
            {
                type = Type.GetType(GetImplName(serviceName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: {0}", e);
                throw e;
            }
            return (IService)obj;
        }
        private string GetImplName(string serviceName)
        {
            // Updated from MSE680 to use web.config
            return ConfigurationManager.AppSettings[serviceName];
        }

    }
}
