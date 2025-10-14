using System.Windows;
using WPF_TODOAPP.Database;
using WPF_TODOAPP.Models;
using WPF_TODOAPP.Windows;

namespace WPF_TODOAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ContextManager ContextManager { get; set; }
        private NewFileWindow newToDoWindow;

        public MainWindow()
        {
            InitializeComponent();

            ToDoContext context = new();
            ContextManager = new ContextManager(context);

            RefreshToDoList();
        }

        private void RefreshToDoList()
        {
            ToDoListBox.ItemsSource = null;
            ToDoListBox.ItemsSource = ContextManager.GetAll();
        }

        private void Pridat_nove_Todo(object sender, RoutedEventArgs e)
        {
            //chybí kod
        }

        private void Odebrat_Todo(object sender, RoutedEventArgs e)
        {
            if (ToDoListBox.SelectedItem is ToDoEntity selected)
            {
                ContextManager.Remove(selected);
                RefreshToDoList();
            }
            else
            {
                MessageBox.Show("Co chces odstranit ty pico co??", "Chyba tveho mozkového výplodu", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Edit_Todo(object sender, RoutedEventArgs e)
        {
            if (ToDoListBox.SelectedItem is ToDoEntity selected)
            {
                //chybí kod
            }
            else
            {
                MessageBox.Show("Co chces menit ty pico co??", "Chyba tveho mozkového výplodu", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
