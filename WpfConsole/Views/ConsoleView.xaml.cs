using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfConsole.ViewModels;

namespace WpfConsole.Views
{
    /// <summary>
    /// Interaction logic for ConsoleView.xaml
    /// </summary>
    public partial class ConsoleView : UserControl
    {

        private ConsoleContent _dc;

        public ConsoleView()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InputBlock.KeyDown += InputBlock_KeyDown;
            InputBlock.PreviewKeyUp += InputBlock_PreviewKeyUp;
            InputBlock.Focus();
            _dc = (ConsoleContent)DataContext;
        }

        private void InputBlock_PreviewKeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Down || e.Key == Key.Up)
            {
                if (_dc.History.Count == 0)
                    return;

                if (e.Key == Key.Up)
                {
                    _dc.HistoryIndex--;
                }

                if (e.Key == Key.Down)
                {
                    _dc.HistoryIndex++;
                }

                if (_dc.HistoryIndex > _dc.History.Count - 1)
                    _dc.HistoryIndex = _dc.History.Count - 1;

                if (_dc.HistoryIndex < 0)
                    _dc.HistoryIndex = 0;

                int pos = _dc.HistoryIndex;
                _dc.ConsoleInput = _dc.History.ElementAt(pos);
            }

            if (e.Key == Key.Escape)
            {
                _dc.ConsoleInput = string.Empty;
            }
        }

        void InputBlock_KeyDown(object sender, KeyEventArgs e)
        {

            _dc.ConsoleInput = InputBlock.Text;

            if (e.Key == Key.Enter && !string.IsNullOrEmpty(_dc.ConsoleInput))
            {
                _dc.History.Add(_dc.ConsoleInput);
                _dc.HistoryIndex = _dc.History.Count;
                _dc.RunCommand();
                InputBlock.Focus();
                Scroller.ScrollToBottom();
            }
        }
    }
}
