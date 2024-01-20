using CakesLibrary.Models;
using System.Windows;


namespace CakesWpf
{
    public partial class MainWindow : Window
    {
        private Storage _storage;
        private Kitchen _kitchen;
        public MainWindow()
        {
            InitializeComponent();
            _storage = new Storage();
            _kitchen = new Kitchen(_storage);
        }
    }
}