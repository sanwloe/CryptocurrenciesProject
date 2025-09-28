using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.Common.Utils
{
    public class SortCollection<T> : ObservableCollection<T>
    {
        private IList<T> Source { get; set; } = [];
        public SortCollection(IList<T> list) : base(list)
        {
            Source = list;
        }
        ///<summary>
        /// true - show element,
        /// false - hide element
        ///</summary>
        public void Sort(Func<T, bool> f)
        {
            var elements = Source.Where(item => f(item));
            this.ClearItems();
            foreach (var item in elements)
            {
                this.Add(item);
            }
        }
        public void Refresh()
        {
            this.ClearItems();
            foreach (var item in Source)
            {
                this.Add(item);
            }
        }
    }
}
