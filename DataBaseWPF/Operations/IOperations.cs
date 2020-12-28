using System.Collections.ObjectModel;
using DataBaseWPF.Models;

namespace DataBaseWPF.Operations
{
    public interface IOperations
    {
        void All(ObservableCollection<string> collection, Shop[] allShops);
        void Select(ObservableCollection<string>[] collections, string item, Shop[] allShops);
    }
}