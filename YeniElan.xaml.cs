using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp3.Views;

namespace WpfApp3
{
    public partial class YeniElan : Window
    {
        public ObservableCollection<string> Photos { get; set; } = new ObservableCollection<string>();

        public YeniElan()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SelectPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                Photos.Add(openFileDialog.FileName);
            }
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            string modelText = model.Text;
            string haqqindaText = Haqqinda.Text;
            string qiymetText = Qiymet.Text;
            string rengText = reng.Text;
            string kmText = Km.Text;


            MainView mainView = Application.Current.MainWindow as MainView;
            mainView?.AddCar(modelText, haqqindaText, qiymetText, rengText, kmText, Photos);

      
            this.Close();
        }
    }
}
