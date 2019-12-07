﻿using System.Windows;
using System.Windows.Controls;
using DirectoryFileCount.ViewModels;

namespace DirectoryFileCount
{
    public partial class SignInView : Window
    {
        internal SignInView()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}