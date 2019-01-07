using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace MVVMCashbox
{
    [DataContract]
    class Score
    {
        [DataMember]
        private string scoreShortDateString;
        [DataMember]
        private string scoreLongTimeString;
        [DataMember]
        private ObservableCollection<Product> products;

        public string ScoreShortDateString
        {
            get
            {
                return scoreShortDateString;
            }

            set
            {
                scoreShortDateString = value;
            }
        }

        public string ScoreLongTimeString
        {
            get
            {
                return scoreLongTimeString;
            }

            set
            {
                scoreLongTimeString = value;
            }
        }

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }

            set
            {
                products = value;
            }
        }

       
    }
}
