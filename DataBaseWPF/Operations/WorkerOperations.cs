using System.Collections.ObjectModel;
using DataBaseWPF.Models;

namespace DataBaseWPF.Operations
{
    public class WorkerOperations : IOperations
    {
        public void All(ObservableCollection<string> workersCollection, Shop[] shops)
        {
            workersCollection.Clear();
            for (int i = 0; i < shops.Length; i++)
            {
                for (int j = 0; j < shops[i].Workers.Length; j++)
                {
                    workersCollection.Add(shops[i].Workers[j]);
                }
            }

        }

        public void Select(ObservableCollection<string>[] collections, string item, Shop[] allShops)
        {
            throw new System.NotImplementedException();
        }
    }
}