using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataBaseWPF.Models;

namespace DataBaseWPF.Operations
{
    public class CityOperation : IOperations
    {
        private IOperations Shops = new ShopOperations();
        private IOperations Workers = new WorkerOperations();
        public void All(ObservableCollection<string> cityCollection, Shop[] allShops)
        {
            cityCollection.Clear();
            for (int i = 0; i < allShops.Length; i++)
            {
                if (cityCollection.Count == 0)
                {
                    cityCollection.Add(allShops[i].City);
                }
                for (int j = 0; j < cityCollection.Count; j++)
                {
                    if (cityCollection[j] == allShops[i].City)
                    {
                        break;
                    }
                    else if (j == cityCollection.Count - 1)
                    {
                        cityCollection.Add(allShops[i].City);
                    }
                }
            }
        }


        public void Select(ObservableCollection<string>[] collections, string city, Shop[] allShops)
        {
            List<Shop> SelectedShops = new List<Shop>();
            for (int i = 0; i < allShops.Length; i++)
            {
                if (allShops[i].City == city)
                {
                    SelectedShops.Add(allShops[i]);
                }
            }
            Shops.All(collections[1], SelectedShops.ToArray());
            Workers.All(collections[2], SelectedShops.ToArray());
        }

    }
}