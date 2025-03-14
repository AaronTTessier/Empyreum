﻿using Empyreum.Data;
using Empyreum.Models;
using Empyreum.ViewModel;
using Flurl.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;

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
            viewModel.OwnedItems = new ObservableCollection<Item>(ItemData.GetItems());
            viewModel.characters = new ObservableCollection<Character>(CharacterData.GetCharacters());
            viewModel.OwnedCharItems = new ObservableCollection<Item>();
            viewModel.BufferItemList = new List<Item>();

            this.DataContext = viewModel;
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
            ItemData.AddItemToDb(selectedItem);
        }

        private void removeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.viewModel.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete.", "Item Deletion Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (this.viewModel.SearchedItems.Contains(this.viewModel.SelectedItem))
            {
                return;
            }

            Item selectedItem = this.viewModel.SelectedItem;

            this.viewModel.OwnedItems.Remove(selectedItem);
            this.viewModel.SearchedItems.Add(selectedItem);
            ItemData.RemoveItemFromDb(selectedItem);
        }

        private async void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            int counter = 0;
            viewModel.SearchedItems.Clear();
            if (e.Key == Key.Enter)
            {
                ResultLbl.Content = "";

                if (string.IsNullOrEmpty(searchTextBox.Text))
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

        private void addCharBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text) || string.IsNullOrEmpty(LastName.Text) || string.IsNullOrEmpty(Race.Text) || string.IsNullOrEmpty(Clan.Text) || string.IsNullOrEmpty(PhysicalDC.Text) || string.IsNullOrEmpty(LogicalDC.Text))
            {
                MessageBox.Show("Error: Make sure all Character fields have valid information.", "Character Add Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Character charToAdd = new Character()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Race = Race.Text,
                Clan = Clan.Text,
                Gender = (CharGender)(int)Gender.SelectedIndex,
                Birthday = (CharBirthday)(int)Birthday.SelectedIndex,
                Deity = (CharDeity)(int)Deity.SelectedIndex,
                Job = (CharJob)(int)Job.SelectedIndex,
                PhysicalDCName = PhysicalDC.Text,
                LogicalDCName = LogicalDC.Text
            };

            this.viewModel.characters.Add(charToAdd);
            CharacterData.AddCharToDb(charToAdd);
        }

        private void removeCharBtn_Click(object sender, RoutedEventArgs e)
        {
            if(this.viewModel.SelectedChar == null)
            {
                MessageBox.Show("Please select a Character to delete.", "Character Deletion Error",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            Character selectedChar = this.viewModel.SelectedChar;
            this.viewModel.characters.Remove(selectedChar);
            CharacterData.RemoveCharFromDb(selectedChar);
        }

        private void addItemToCharBtn_Click(object sender, RoutedEventArgs e)
        {
            if(this.viewModel.SelectedOwnedItem == null)
            {
                MessageBox.Show("Please select an item to add to character.", "Item Ownership Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (this.viewModel.OwnedCharItems.Contains(this.viewModel.SelectedOwnedItem))
            {
                MessageBox.Show("This item already is owned by this character.", "Item Ownership Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.viewModel.OwnedCharItems.Add(viewModel.SelectedOwnedItem);
            CharacterData.AddItemToChar((Character)CharacterCmbBx.SelectedItem, viewModel.SelectedOwnedItem);
            this.viewModel.OwnedItems.Remove(viewModel.SelectedOwnedItem);
        }

        private void removeItemFromCharBtn_Click(object sender, RoutedEventArgs e)
        {
            if(this.viewModel.SelectedOwnedItem == null)
            {
                MessageBox.Show("Please select an item to remove from this character.", "Item Deletion Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            CharacterData.RemoveItemFromChar((Character)CharacterCmbBx.SelectedItem, viewModel.SelectedOwnedItem);
            ItemData.RemoveItemFromDb(viewModel.SelectedOwnedItem);
            this.viewModel.OwnedItems.Remove(viewModel.SelectedOwnedItem);
            this.viewModel.OwnedCharItems.Remove(viewModel.SelectedOwnedItem);
        }

        private void OnCharSelectChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.viewModel.OwnedCharItems.Clear();
            //this.viewModel.BufferItemList.AddRange(CharacterData.GetCharacterItems((Character)CharacterCmbBx.SelectedItem));
            foreach(Item item in CharacterData.GetCharacterItems((Character)CharacterCmbBx.SelectedItem))
            {
                this.viewModel.OwnedCharItems.Add(item);
            }
            
        }
    }
}