using System.Collections.Generic;

namespace VirtualLibrary.DataSources
{
    interface IExternalDataSource<T>
    {
        IList<T> GetList();

        //void RemoveElement(T element);

        void AddElement(T element);

        //void UpdateElement(T element);
    }
}
