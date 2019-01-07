using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MVVMCashbox
{
    interface IJsonFileInterface<T>
    {
        ObservableCollection<T> Load(string filename);
        void Save(string filename, ObservableCollection<T> products);
    }
}
