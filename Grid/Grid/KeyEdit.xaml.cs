using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Grid483W.Models;
using Plugin.Media;
using Xamarin.Essentials;

namespace Grid483W
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KeyEdit : ContentPage
    {
        private int Row;
        private int Column;
        private string RowCol;
        private string PicPath;
        private int Rownum;
        private int Colnum;
        public KeyEdit(int row, int column, int rownum, int colnum)
        {
            InitializeComponent();
            Output.Text = "Output Text";
            Row = row;
            Column = column;
            Rownum = rownum;
            Colnum = colnum;
            RowCol = row.ToString() + column.ToString(); //used to find keys in the database
        }

        
        private async void Finish(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            KeyInfo keyinfo = App.KeyDatabase.GetKey(RowCol);

            //if row and column in database, update
            //else add it to db
            if (keyinfo == null)
            {
                //build the new key
                if(NewImage.Source != null)
                {
                    KeyInfo newkey = new KeyInfo(Output.Text, RowCol, Row, Column, PicPath);
                    App.KeyDatabase.SaveKey(newkey);
                }
                else
                {
                    KeyInfo newkey = new KeyInfo(Output.Text, RowCol, Row, Column, "soundicon.png");
                    App.KeyDatabase.SaveKey(newkey);
                }
                await Navigation.PushAsync(new MainGrid(Colnum, Rownum));
                
            }
            else
            {
                //update
                keyinfo.text = Output.Text;
                if(NewImage.Source != null)
                {
                    keyinfo.imagepath = PicPath;
                }
                App.KeyDatabase.SaveKey(keyinfo);
                await Navigation.PushAsync(new MainGrid(Colnum, Rownum));
            }

        }

        private async void Upload(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                //error case
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                CompressionQuality = 40
            });
            NewImage.Source = file.Path;
            PicPath = file.Path;
        }
    }
}