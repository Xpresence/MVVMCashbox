using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVMCashbox
{
    public class DataViewModel
    {
        public Dictionary<string, int> ProductsCount { get; private set; }

        public Dictionary<string, int> Sells { get; private set; }

        public Dictionary<string, int> SellsProducts { get; private set; }


        public  DataViewModel()
        {

            _scores = new JsonFileService<Score>().Load(@"..\..\data/scores.json");
            _products = new JsonFileService<Product>().Load(@"..\..\data/data.json");

            ProductsCount = _products.ToDictionary(item => item.Name, item => item.Count);

            Sells = _scores.Select(item => new KeyValuePair<string, int>(
                item.ScoreShortDateString,
                item.Products.Sum(p => (p.Cost * p.Count)))).GroupBy(item => item.Key).ToDictionary(item => item.Key, item => item.Sum(p => p.Value));

            SellsProducts = new Dictionary<string, int>();

            foreach (var score in _scores)
            {
                foreach (var product in score.Products)
                {
                    if (!SellsProducts.ContainsKey(product.Name))
                    {
                        SellsProducts.Add(product.Name, 0);
                    }

                    SellsProducts[product.Name] += product.Count;
                }
            }

        }

        private ObservableCollection<Score> _scores;
        private ObservableCollection<Product> _products;
    }
}
