using System;
using System.Collections.Generic;
using System.ComponentModel;
using TRGT.Models;
using TRGT.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TRGT.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}