using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Grid483W.Models;

namespace Grid483W
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainGrid : ContentPage
    {
        private int x_dim;
        private int y_dim;
        public MainGrid(int xdim, int ydim)
        {
            InitializeComponent();
            x_dim = xdim;
            y_dim = ydim;
            //for each key in the grid
            for (int i = 1; i < (ydim*2); i+=2) //for each row
            {
                for (int j = 0; j < xdim; j++) //for each column
                {
                    KeyInfo keyinfo = App.KeyDatabase.GetKey(i.ToString()+j.ToString()); //get the key
                    var button = new Button { };
                    var image = new Image { };
                    button.Margin = 1;
                    button.Padding = 1;
                    button.CornerRadius = 20;
                    button.FontSize = 12;
                    button.Clicked += Go_Item;
                    if (keyinfo != null)
                    {
                        button.Text = keyinfo.text;
                        image.Source = keyinfo.imagepath;
                        gridLayout.Children.Add(button, j, i+1);
                        gridLayout.Children.Add(image, j, i);
                    }
                    else
                    {
                        button.Text = "Create Key";
                        image.Source = "soundicon.png";
                        gridLayout.Children.Add(button, j, i+1);
                        gridLayout.Children.Add(image, j, i);
                    }
                }
            }
            
        }

        private async void Go_Item(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (editMode.IsToggled == false)
            {
                if (button.Text == "Create Key")
                {
                    int row = Grid.GetRow(button)-1;
                    int column = Grid.GetColumn(button);
                    await Navigation.PushAsync(new KeyEdit(row, column, y_dim, x_dim));
                }
                else
                {
                    await TextToSpeech.SpeakAsync(button.Text);
                }
            }

            if (editMode.IsToggled == true)
            {
                int row = Grid.GetRow(button)-1;
                int column = Grid.GetColumn(button);
                await Navigation.PushAsync(new KeyEdit(row, column, y_dim, x_dim));

            }
        }

        

        void OnToggledKey(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
          
        }
        async void GridButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GridEdit(x_dim, y_dim));
        }

        async void HelpButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Help:", "Add: Select 'Create Key' to make a new key. Then write voice 'Output' and select a picture" +
                             "\n\nEditing Keys: Turn 'Edit keys' on and select the key you wish to edit" +
                             "\n\nEditing Grid: Grid button allows you to set dimensions of grid ", "Close");
        }
    }
}