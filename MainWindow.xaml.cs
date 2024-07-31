using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Python.Runtime;
using Empyreum.Models;
using Empyreum.ViewModel;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace Empyreum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            this.viewModel = new MainWindowViewModel();
            viewModel.SearchedItems = new ObservableCollection<Item>();
            viewModel.OwnedItems = new ObservableCollection<Item>();
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.viewModel.SelectedItem == null)
            {
                return;
            }
            if (this.viewModel.OwnedItems.Contains(this.viewModel.SelectedItem))
            {
                return;
            }

            Item selectedItem = this.viewModel.SelectedItem;

            this.viewModel.SearchedItems.Remove(selectedItem);
            this.viewModel.OwnedItems.Add(selectedItem);
        }

        private void removeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.viewModel.SelectedItem == null)
            {
                return;
            }
            if (this.viewModel.SearchedItems.Contains(this.viewModel.SelectedItem))
            {
                return;
            }

            Item selectedItem = this.viewModel.SelectedItem;

            this.viewModel.OwnedItems.Remove(selectedItem);
            this.viewModel.SearchedItems.Add(selectedItem);
        }

        private async void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            int counter = 0;
            viewModel.SearchedItems.Clear();
            if (e.Key == Key.Enter)
            {
                ResultLbl.Content = "";

                if(string.IsNullOrEmpty(searchTextBox.Text))
                {
                    ResultLbl.Content = "No text entered.";
                }
                else
                {
                    HttpResponseMessage req = (await $"https://xivapi.com/search?string={searchTextBox.Text}&indexes=item&Columns=ID,Name,Description,Icon".GetAsync()).ResponseMessage;
                    dynamic item = JsonConvert.DeserializeObject(req.Content.ReadAsStringAsync().Result);

                    for (int i = 0; i < item.Results.Count; i++)
                    {
                        viewModel.SearchedItems.Add(new Item { ID = item.Results[i].ID, Name = item.Results[i].Name, Description = item.Results[i].Description, Icon = item.Results[i].Icon });
                        counter++;
                    }

                    ResultLbl.Content = $"Results Found: {counter}";
                }
            }
        }
    }
}