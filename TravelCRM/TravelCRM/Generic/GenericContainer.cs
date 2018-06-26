using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelCRM.Generic
{
    public interface IGenericConatiner
    {
        dynamic Data { get; }
    }

    public class GenericContainer<T> : IGenericConatiner
    {
        T _Data { get; set; }

        public GenericContainer(T data)
        {
            _Data = data;

        }

        dynamic IGenericConatiner.Data
        {
            get { return _Data; }
        }
    }


    public class GenericContainer
    {
        public static GenericContainer<T> Create<T>(T data)
        {
            return new GenericContainer<T>(data);
        }
    }
}
