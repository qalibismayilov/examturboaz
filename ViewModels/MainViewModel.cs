using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp3.Command;
using WpfApp3.Model;
using WpfApp3.Views;



namespace WpfApp16.ViewModels
{
    public class viewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> markaNames { get; set; }
        public ObservableCollection<string> modelNames { get; set; }



        private string selectedMarka;
        public string SelectedMarka
        {
            get { return selectedMarka; }
            set
            {
                if (selectedMarka != value)
                {
                    selectedMarka = value;
                    OnPropertyChanged(nameof(SelectedMarka));

                    UpdateModelNames();
                }
            }
        }
        public string SelectedModel { get; set; }



        public viewModel()
        {



            markaNames = new ObservableCollection<string>
            {
                "Mercedes",
                "BMW",
                "Toyota",
                "Wolksvagen",
                "dodge",
                "vaz",
                "lada"
            };



            modelNames = new ObservableCollection<string>();
        }
        private void UpdateModelNames()
        {
        
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}