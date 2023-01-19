using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Helpers;

namespace WpfApp1.Models.ViewModels
{
    class MainViewModel: ObservableObject
    {
        private object _currentView;
        public RelayCommand CustomersViewCommand { get; set; }
        public RelayCommand CreateCustomerViewCommand { get; set; }
        public CustomerViewModel CustomersViewModel { get; set; }
        public CreateCustomerViewModel CreateCustomerViewModel { get; set; }

        public MainViewModel()
        {
            
        }
    }
}
