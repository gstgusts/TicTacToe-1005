using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToeData;

namespace TicTacToeWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;
        public MainWindow()
        {
            InitializeComponent();
            _game = new Game();
            RefreshUi();
        }

        private void btn_0_0_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var name = button.Name;
            var parts = name.Split('_');

            var row = int.Parse(parts[1]);
            var col = int.Parse(parts[2]);

            var result = _game.PlaceCheckMark(row, col);

            RefreshUi();
        }

        private void RefreshUi()
        {
            btn_0_0.Content = GetFieldValue(0, 0);
            btn_0_1.Content = GetFieldValue(0, 1);
            btn_0_2.Content = GetFieldValue(0, 2);
            btn_1_0.Content = GetFieldValue(1, 0);
            btn_1_1.Content = GetFieldValue(1, 1);
            btn_1_2.Content = GetFieldValue(1, 2);
            btn_2_0.Content = GetFieldValue(2, 0);
            btn_2_1.Content = GetFieldValue(2, 1);
            btn_2_2.Content = GetFieldValue(2, 2);
        }

        private string GetFieldValue(int row, int col)
        {
            if(_game.GetFieldValue(row, col) == FieldTypeEnum.Empty)
            {
                return string.Empty;
            }

            return _game.GetFieldValue(row, col).ToString();
        }
    }
}
