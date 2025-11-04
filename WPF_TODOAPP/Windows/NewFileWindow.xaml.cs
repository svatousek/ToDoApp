using System.Windows;
using WPF_TODOAPP.Models;

namespace WPF_TODOAPP.Windows
{
    /// <summary>
    /// Interakční logika pro NewFileWindow.xaml
    /// </summary>
    public partial class NewFileWindow : Window
    {
        private readonly ContextManager _contextManager;
        public NewFileWindow(ContextManager manager)
        {
            _contextManager = manager;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text;
            bool isDone = IsDoneInput.IsChecked.Value;

            ToDoEntity todo = new ToDoEntity { IsDone = isDone, Title=title };
            _contextManager.Add(todo);

            this.Close();

        }
    }
}
