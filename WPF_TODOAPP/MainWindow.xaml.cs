using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_TODOAPP.Database;
using WPF_TODOAPP.Models;
using WPF_TODOAPP.Windows;

namespace WPF_TODOAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    public ContextManager contextManager { get; set; }
    public partial class MainWindow : Window
    {
        NewFileWindow newToDoWindow;
        public MainWindow()
        {
            ToDoContext context = new();
            ContextManager = new ContextManager(context);
            
            InitializeComponent();
            ToDoListBox.ItemsSource = ContextManager.GetAll();
        }

        private void Pridat_nove_Todo(object sender, RoutedEventArgs e)
        {
            newToDoWindow = new(ContextManager);
            newToDoWindow.Closed += (s, e) =>
            {
                ToDoListBox.ItemsSource = null;
                ToDoListBox.ItemsSource = ContextManager.GetAll();
            };
            newToDoWindow.ShowDialog();

        }
    }
}