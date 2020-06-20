using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App.CardTools.Extention
{
    public static class CollectionExtention
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
    }
}
