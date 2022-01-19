using System.ComponentModel;
using TRGT.ViewModels;
using Xamarin.Forms;

namespace TRGT.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}