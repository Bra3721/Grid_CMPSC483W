using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Grid483W
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridEdit : ContentPage
    {
        public GridEdit(int prev_x, int prev_y)
        {
            InitializeComponent();
            y.Placeholder = "Rows (Enter use value between 1 and 5)";
            x.Placeholder = "Columns (Enter value between 1 and 6)";
        }

        private async void NewGrid(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int colnum = Int32.Parse(x.Text);
            int rownum = Int32.Parse(y.Text);
            await Navigation.PushAsync(new MainGrid(colnum, rownum));
        }
    }
}