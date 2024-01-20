using CakesLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows;


namespace CakesWpf
{
    public partial class MainWindow : Window
    {
        //ObservableCollection для того чтобы все изменения отображались в интерфейсе
        //без set; чтобы использовалась одна коллекция для ингредиентов
        public ObservableCollection<Ingredient> Ingredients { get; } = new ObservableCollection<Ingredient>();

        //поля для того чтобы можно было обращаться к складу и кухне из разных методов
        private Storage _storage;
        private Kitchen _kitchen;
        public MainWindow()
        {
            //прорисовка графических элементов
            InitializeComponent();

            //создание и присвоение склада и кухни(объектов)
            _storage = new Storage();
            _kitchen = new Kitchen(_storage);

            //связываем код этого файла с кодом xaml
            DataContext = this;

            //берем раннее сохраненные ингредиенты и загружаем в свойство Ingredients
            var availableIngredients = _storage.GetAllIngredients();
            foreach (Ingredient ingredient in availableIngredients)
            {
                Ingredients.Add(ingredient);
            }
        }
    }
}