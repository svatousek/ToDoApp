using System.ComponentModel;

namespace WPF_TODOAPP.Models
{
    public class ToDoEntity : INotifyPropertyChanged
    {
        private bool _isDone;

        public int Id { get; set; }
        public bool IsDone
        {
            get => _isDone;
            set
            {
                _isDone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDone)));
            }
        }
        public string Title { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString() => Title;
    }
}
