using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfConsole.ViewModels
{
    public class ConsoleContent : INotifyPropertyChanged
    {
        private string _consoleInput = string.Empty;
        private ObservableCollection<string> _history = new ObservableCollection<string>();
        private ObservableCollection<string> _consoleOutput = new ObservableCollection<string>() { "WPF Console Emulator..." };
        private int _historyIndex = 0;


        public int HistoryIndex
        {
            get
            {
                return _historyIndex;
            }
            set
            {
                _historyIndex = value;
                OnPropertyChanged("HistoryIndex");
            }
        }

        public string ConsoleInput
        {
            get
            {
                return _consoleInput;
            }
            set
            {
                _consoleInput = value;
                OnPropertyChanged("ConsoleInput");
            }
        }

        public ObservableCollection<string> ConsoleOutput
        {
            get
            {
                return _consoleOutput;
            }
            set
            {
                _consoleOutput = value;
                OnPropertyChanged("ConsoleOutput");
            }
        }

        public ObservableCollection<string> History
        {
            get
            {
                return _history;
            }
            set
            {
                _history = value;
                OnPropertyChanged("History");
            }
        }

        public void RunCommand()
        {
            ConsoleOutput.Add(ConsoleInput);

            // Parse and execute command here
            ConsoleOutput.Add("Operation unknown.  Try 'help' for more info.");

           ConsoleInput = String.Empty;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
