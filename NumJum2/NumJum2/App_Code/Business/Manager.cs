using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumJum2.Domain;
using NumJum2.Services;

namespace NumJum2.Business
{
    public abstract class Manager
    {
        private Factory factory = Factory.GetInstance();

        protected IService GetService(String name)
        {
            return factory.GetService(name);
        }
    }
}
