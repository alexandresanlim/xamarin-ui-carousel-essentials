using App.CardTools.Models;
using App.CardTools.Models.Icon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.CardTools.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommand.Execute(null);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                ToolsList = new ObservableCollection<ToolsMenu>();
                ToolsList.Clear();
                var items = new List<ToolsMenu>()
                {
                    new ToolsMenu
                    {
                         Text = "Connection",
                         PrimaryColor = Color.FromHex("#4ac7cb"),
                         OnPrimaryColor = Color.FromHex("#FFFFFF"),
                         SecondaryColor = Color.FromHex("#6b1230"),
                         OnSecondaryColor = Color.FromHex("#FFFFFF"),
                         Icon = FontAwesomeSolid.Wifi
                    },
                    new ToolsMenu
                    {
                         Text = "Connection"
                    },
                    new ToolsMenu
                    {
                         Text = "Connection"
                    }
                };

                //await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    ToolsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Command LoadItemsCommand { get; set; }

        private ObservableCollection<ToolsMenu> _toolsList;
        public ObservableCollection<ToolsMenu> ToolsList
        {
            set { SetProperty(ref _toolsList, value); }
            get { return _toolsList; }
        }
    }
}
