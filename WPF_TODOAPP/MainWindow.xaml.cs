using System.Collections.ObjectModel;
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
    /// </summary>
    public partial class MainWindow : Window
    {
        public ContextManager ContextManager { get; set; }
        public ObservableCollection<ToDoEntity> ToDoList { get; set; }
        NewFileWindow newTodoWindow;
        EditWindow editTodoWindow;
        public MainWindow()
        {
            ToDoContext context = new();
            ContextManager = new ContextManager(context);
            ToDoList = new ObservableCollection<ToDoEntity>(ContextManager.GetAll());
            InitializeComponent();
            ToDoListBox.ItemsSource = ToDoList;
        }

        private void AddNewToDo(object sender, RoutedEventArgs e)
        {
            newTodoWindow = new(ContextManager);
            newTodoWindow.Closed += (s, e) =>
            {
                ToDoList.Clear();
                ContextManager.GetAll().ForEach(x => ToDoList.Add(x));
            };
            newTodoWindow.ShowDialog();
        }

        private void RemoveSelectedTodo(object sender, RoutedEventArgs e)
        {
            ToDoEntity? Selected = ToDoListBox.SelectedItem as ToDoEntity;
            if (Selected != null)
            {
                ContextManager.Remove(Selected);
                ToDoList.Remove(Selected);
            }
        }
        private void EditSelectedTodo(object sender, RoutedEventArgs e)
        {
            ToDoEntity? Selected = ToDoListBox.SelectedItem as ToDoEntity;
            if (Selected != null)
            {
                 
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox cbox && cbox.DataContext is ToDoEntity todo)
            {
                todo.IsDone = cbox.IsChecked == true;
                ContextManager.Update(todo);
            }
        }
    }
}