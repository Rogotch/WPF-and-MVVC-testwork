using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using System.Windows.Input;
using DataBaseWPF.Operations;

namespace DataBaseWPF.Models
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Shop[] _mainDatabase;
        private string _selectedCity;
        private string _selectedShop;
        private string _selectedWorker;

        public ObservableCollection<string> Cities { get; set; }
        public ObservableCollection<string> Shops { get; set; }
        public ObservableCollection<string> Workers { get; set; }

        public ObservableCollection<string>[] AllCollections;

        private IOperations _Cities = new CityOperation();
        private IOperations _Shops = new ShopOperations();
        private IOperations _Workers = new WorkerOperations();

        public string SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity= value;
                _Cities.Select(AllCollections, _selectedCity, _mainDatabase);
                OnPropertyChanged("SelectedCity");
            }
        }
        public string SelectedShop
        {
            get { return _selectedShop; }
            set
            {
                _selectedShop = value;
                _Shops.Select(AllCollections, _selectedShop, _mainDatabase);
                OnPropertyChanged("SelectedShop");
            }
        }
        public string SelectedWorker
        {
            get { return _selectedWorker; }
            set
            {
                _selectedWorker = value;
                OnPropertyChanged("SelectedWorker");
            }
        }

        public ApplicationViewModel()
        {
            _mainDatabase = new[]
            {
                new Shop("Москва", "A1", new[] {"Василий Петрович", "Александр Генадьевич", "Александр Иванович"}),
                new Shop("Санкт-Петербург", "A2", new[] {"Валерий Антонович", "Максим Александрович", "Виталий Александрович"}),
                new Shop("Москва", "A3", new[] {"Антон Валерьевич", "Дмитрий Максимович", "Кирилл Витальевич"}),
                new Shop("Череповец", "A4", new[] {"Мария Петровна", "Михаил Дмитриевич", "Елизавета Ивановна"}),
                new Shop("Вологда", "A5", new[] {"Пётр Антонович", "Генадий Михайлович", "Катерина Владиславовна"}),
                new Shop("Череповец", "A6", new[] {"Антон Васильевич", "Виталий Генадьевич", "Владимир Кириллович"}),
                new Shop("Магнитогорск", "A7", new[] {"Ольга Генадьевна", "Кирилл Витальевич", "Евгений Владимирович"}),
                new Shop("Москва", "A8", new[] {"Генадий Кириллович", "Любовь Михайловна", "Владимир Евгеньевич"})
            };
            Cities = new ObservableCollection<string>();
            Shops = new ObservableCollection<string>();
            Workers = new ObservableCollection<string>();
            AllCollections = new[] { Cities, Shops, Workers };
            _Cities.All(Cities, _mainDatabase);
            _Shops.All(Shops, _mainDatabase);
            _Workers.All(Workers, _mainDatabase);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}