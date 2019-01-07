using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.ObjectModel;

namespace MVVMCashbox
{
    class JsonFileService<T> : IJsonFileInterface<T>
    {
        public ObservableCollection<T> Load(string filename)
        {
            ObservableCollection<T> products = new ObservableCollection<T>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<T>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                products = jsonFormatter.ReadObject(fs) as ObservableCollection<T>;
            }

            return products;
        }

        public void Save(string filename, ObservableCollection<T> products)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<T>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, products);
            }
        }
    }
}
