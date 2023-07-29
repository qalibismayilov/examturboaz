using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp16.ViewModels;
using WpfApp3.Command;
using WpfApp3.Model;
using WpfApp3.ViewModels;

namespace WpfApp3.Views
{
    public partial class MainView : Window
    {
        private string selectedModel;

        private viewModel viewModel;
        public MainView()
        {
            InitializeComponent();

            viewModel = new viewModel();
            DataContext = viewModel;
        }

        private void CarImage_Click(object sender, MouseButtonEventArgs e)
        {
            Image clickedImage = sender as Image;
            if (clickedImage != null && clickedImage.Tag is string carTag)
            {
                CarInfo selectedCar = GetCarInfoByTag(carTag);
                if (selectedCar != null)
                {
                    CarDetailsView carDetailsView = new CarDetailsView(selectedCar);
                    carDetailsView.Show();
                }

                if (!string.IsNullOrEmpty(viewModel.SelectedMarka) && !string.IsNullOrEmpty(viewModel.SelectedModel))
                {
                    List<Image> imagesToRemove = new List<Image>();
                    foreach (UIElement element in imageStackPanel.Children)
                    {
                        if (element is Image image && image != clickedImage)
                        {
                            imagesToRemove.Add(image);
                        }
                    }

                    foreach (Image image in imagesToRemove)
                    {
                        imageStackPanel.Children.Remove(image);
                    }
                }
            }
        }

        private CarInfo GetCarInfoByTag(string carTag)
        {
            CarInfo selectedCar = null;

            switch (carTag)
            {
                case "priora":
                    selectedCar = new CarInfo
                    {
                       Model = " Lada Priora",
                       Motor = " mator - 1.6L Benzin",
                       Year = " il - 2005",
                       Kilometers = " km - 150000",
                       Price = " qiymet - 15000",
                       Color = " reng - white",
                       about = " haqqinda - oz masinim olub cicey kimi baxmisam\n bos bos yazib narahat elemiyin real aliciya endirim olacaq",
                       ImageSource = "/image/piris.jpg",
            };
                    break;



                case "tuareg":
                    selectedCar = new CarInfo
                    {
                        Model = " Wolksvagen Tuareg",
                        Motor = " mator - 3.2L benzin",
                        Year = " il - 2008",
                        Kilometers = " km - 180000",
                        Price = " qiymet - 25000",
                        Color = " reng - black",
                        about = " haqqinda - hec bir problemi yoxdur normal\n sur omrunun axrina qeder usta uzu gorme",
                        ImageSource = "/Image/tuareg.jpg",
                    };
                    break;



                case "4goz":
                    selectedCar = new CarInfo
                    {
                        Model = " Mercedes e320",
                        Motor = " motor - 3.2L benzin",
                        Year = " il - 1999",
                        Kilometers = " km - 123000",
                        Price = " qiymet - 10000",
                        Color = " reng - Grey",
                        about = " haqqinda - baki qebele ureyin isteyen kimi sur\n hec bir problemi yoxdu",
                        ImageSource = "/Image/4goz.jpg",
            };
                    break;

                case "e60":
                    selectedCar = new CarInfo
                    {
                        Model = " BMW e60",
                        Motor = " 5.5L Benzin",
                        Year = " il - 1999",
                        Kilometers = " km - 12000",
                        Price = " qiymet - 25000",
                        Color = " reng - purple",
                        about = " haqqinda - sport purjun stage 1 yukseldilib \nhec bir problemi yoxdur",
                        ImageSource = "/Image/60kuza.jpg",
            };
                    break;

                case "camry":
                    selectedCar = new CarInfo
                    {
                         Model = " Toyota camry",
                         Motor = " motor - 2.5L Benzin",
                         Year = " il - 2022",
                         Kilometers = " km - 0",
                         Price = " qiymet - 35000",
                         Color = " reng - white",
                         about = " haqqinda - cox rahat tam dayday masini bez problem",
                         ImageSource = "/Image/camry.jpg",
            };
                    break;



                case "2107":
                    selectedCar = new CarInfo
                    {
                        Model = " Vaz 2107",
                        Motor = " motor - 1.3L Benzin",
                        Year = " il - 1987",
                        Kilometers = " km - 200000",
                        Price = " qiymet - 5000",
                        Color = " carbon white",
                        about = " haqqinda - problemzisdir axir qiymeti budu",
                        ImageSource = "/Image/07.jpg",
            };
                    break;



                case "brabus":
                    selectedCar = new CarInfo
                    {
                        Model = " Mercedes brabus",
                        Motor = " motor - 6.5L Benzin",
                        Year = " il - 2021",
                        Kilometers = " km - 0",
                        Price = " qiymet - 350000",
                        Color = " reng - grey",
                        ImageSource = "/image/qalikk.jpg",
            };
                    break;



                case "sessot":
                    selectedCar = new CarInfo
                    {
                        Model = " Mercedes sessot",
                        Motor = " motor - 5.5L Benzin",
                        Year = " il - 1988",
                        Kilometers = " km - 200000",
                        Price = " qiymet - 15000",
                        Color = " reng - black",
                        about = " haqqinda - bilen bilir bu nece masindir alanada satanada allah\n xeyir versin",
                        ImageSource = "/image/download.jpg",
                    };
                    break;
 
                case "challenger":
                    selectedCar = new CarInfo
                    {
                        Model = " Dodge challenger",
                        Motor = " motor - 6.5L Benzin",
                        Year = " il - 2020",
                        Kilometers = " km - 0",
                        Price = " qiymet - 60000",
                        Color = " reng - dark grey",
                        ImageSource = "/image/dodge.jpg",
            };
                    break;

                default:
                    break;
            }

            return selectedCar;
        }

        private void Marka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is viewModel viewModel)
            {
                viewModel.modelNames.Clear();



                switch (viewModel.SelectedMarka)
                {
                    case "Mercedes":
                        viewModel.modelNames.Add("sessot");
                        viewModel.modelNames.Add("brabus");
                        viewModel.modelNames.Add("4goz");
                        break;
                    case "BMW":
                        viewModel.modelNames.Add("e60");
                        break;
                    case "Toyota":
                        viewModel.modelNames.Add("camry");
                        break;
                    case "Wolksvagen":
                        viewModel.modelNames.Add("tuareg");
                        break;
                    case "dodge":
                        viewModel.modelNames.Add("challenger");
                        break;
                    case "vaz":
                        viewModel.modelNames.Add("2107");
                        break;
                    case "lada":
                        viewModel.modelNames.Add("priora");
                        break;
                    default:
                        break;
                }
            }
        }

        private void Model_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
            {
                string selectedModel = comboBox.SelectedItem.ToString();


                if (viewModel != null)
                {
                    string imageSource = GetImageSourceByModel(selectedModel);


                    selectedModelImage.Source = new BitmapImage(new Uri(imageSource, UriKind.RelativeOrAbsolute));

                    imageStackPanel.Children.Clear();
                    Image selectedImage = new Image
                    {
                        Source = new BitmapImage(new Uri(imageSource, UriKind.RelativeOrAbsolute)),
                        Width = 154,
                        Height = 108,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top
                    };
                    selectedImage.MouseLeftButtonDown += CarImage_Click;
                    selectedImage.Tag = selectedModel;
                    imageStackPanel.Children.Add(selectedImage);
                }
            }
        }


        private string GetImageSourceByModel(string model)
        {
            switch (model)
            {
                case "4goz":
                    return "/Image/4goz.jpg";
                case "sessot":
                    return "/Image/download.jpg";
                case "brabus":
                    return "/Image/qalikk.jpg";
                case "e60":
                    return "/Image/60kuza.jpg";
                case "camry":
                    return "/Image/camry.jpg";
                case "2107":
                    return "/Image/07.jpg";
                case "challenger":
                    return "/Image/dodge.jpg";
                case "tuareg":
                    return "/Image/tuareg.jpg";
                case "priora":
                    return "/Image/piris.jpg";
                default: 
                    return "";
            }
        }
        public class CarInfo
        {
            public string? Model { get; set; }
            public string? Motor { get; set; }
            public string? Year { get; set; }
            public string? Kilometers { get; set; }
            public string? Price { get; set; }
            public string? Color { get; set; }
            public string? ImageSource { get; internal set; }
            public string? about { get; set; }
        }

        private void myImageButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri textResourceUri = new Uri("/images/red_text.png", UriKind.Relative);
            selectionText.Foreground = new SolidColorBrush(Colors.Red);

        }

        private void myImageButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri textResourceUri = new Uri("/images/SlateGray_text.png", UriKind.Relative);



            selectionText.Foreground = new SolidColorBrush(Colors.SlateGray);

        }


        private void myImageButton1_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri textResourceUri = new Uri("/images/red_text.png", UriKind.Relative);
            selectionText1.Foreground = new SolidColorBrush(Colors.Red);

        }

        private void myImageButton1_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri textResourceUri = new Uri("/images/SlateGray_text.png", UriKind.Relative);



            selectionText1.Foreground = new SolidColorBrush(Colors.SlateGray);
        }

        private void myImageButton2_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri textResourceUri = new Uri("/images/red_text.png", UriKind.Relative);
            selectionText2.Foreground = new SolidColorBrush(Colors.Red);

        }


        private void myImageButton2_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri textResourceUri = new Uri("/images/SlateGray_text.png", UriKind.Relative);


            selectionText2.Foreground = new SolidColorBrush(Colors.SlateGray);

        }

        private void ImageButton_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri heartResourceUri = new Uri("/Red_image/RedHeart.png", UriKind.Relative);
            Uri textResourceUri = new Uri("/Red_image/red_text.png", UriKind.Relative);
            heartImage.Source = new BitmapImage(heartResourceUri);
            selectionTextt.Foreground = new SolidColorBrush(Colors.Red);
        }



        private void ImageButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri heartResourceUri = new Uri("/Red_image/heart.png", UriKind.Relative);
            Uri textResourceUri = new Uri("/Red_image/SlateGray_text.png", UriKind.Relative);
            heartImage.Source = new BitmapImage(heartResourceUri);
            selectionTextt.Foreground = new SolidColorBrush(Colors.SlateGray);
        }



        private void ImageButtonn_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri heartResourceUri = new Uri("/Red_image/RedUser.png", UriKind.Relative);
            Uri textResourceUri = new Uri("/Red_image/red_text.png", UriKind.Relative);
            userImage.Source = new BitmapImage(heartResourceUri);
            selectionTexttu.Foreground = new SolidColorBrush(Colors.Red);
        }



        private void ImageButtonn_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri heartResourceUri = new Uri("/Red_image/user.png", UriKind.Relative);
            Uri textResourceUri = new Uri("/Red_image/SlateGray_text.png", UriKind.Relative);
            userImage.Source = new BitmapImage(heartResourceUri);
            selectionTexttu.Foreground = new SolidColorBrush(Colors.SlateGray);
        }
      
        
    }
}