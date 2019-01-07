using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MVVMCashbox
{
    class AdminViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> products;
        private Product selectedProduct;
        private Command addCommand;
        private Command deleteCommand;

        public AdminViewModel()
        {
            Products = new ObservableCollection<Product>();
        }

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public Command AddCommand
        {
            get
            {
                return addCommand != null ? addCommand : addCommand = new Command( (obj) =>
                  {
                      Product product = new Product();
                      Products.Insert(0, product);
                      SelectedProduct = product;
                  } );
            }
        }
        
        public Command DeleteCommand
        {
            get
            {
                return deleteCommand != null ? deleteCommand : deleteCommand = new Command( (obj) =>
                    {
                        Product product = obj as Product;
                        if (product != null)
                        {
                            Products.Remove(product);
                        }
                    }, (obj) => Products.Count > 0 );
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
