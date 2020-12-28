using System.Collections.ObjectModel;
using DataBaseWPF.Models;

namespace DataBaseWPF.Operations
{
    public class ShopOperations : IOperations
    {
        private IOperations Worker = new WorkerOperations();
        public void All(ObservableCollection<string> shopsCollection, Shop[] shops)
        {
            shopsCollection.Clear();
            for (int i = 0; i < shops.Length; i++)
            {
                shopsCollection.Add(shops[i].Name);
            }

        }
        public void Select(ObservableCollection<string>[] collections, string shop, Shop[] allShops)
        {
            for (int i = 0; i < allShops.Length; i++)
            {
                if (allShops[i].Name == shop)
                {
                    Shop[] selectShop = new[] {allShops[i]};
                    Worker.All(collections[2], selectShop);
                    break;
                }
            }

        }


    }
}