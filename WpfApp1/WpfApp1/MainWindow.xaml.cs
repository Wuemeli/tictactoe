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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Button[] buttons;
        public string player = "x";
        public int counter;
        public int pointsx;
        public int pointso;
        public int draw;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[9] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };

        }

        public void Click(object sender, RoutedEventArgs arg)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            button.Content = player;
            Winchecker();
            Switchplayer();
            counter++;
        }

        private void Winchecker()
        {
            if (btn1.Content == player && btn2.Content == player && btn3.Content == player) Haswon();
            else if (btn4.Content == player && btn5.Content == player && btn6.Content == player) Haswon();
            else if (btn7.Content == player && btn8.Content == player && btn9.Content == player) Haswon();
            else if (btn1.Content == player && btn4.Content == player && btn7.Content == player) Haswon();
            else if (btn2.Content == player && btn5.Content == player && btn8.Content == player) Haswon();
            else if (btn3.Content == player && btn6.Content == player && btn9.Content == player) Haswon();
            else if (btn1.Content == player && btn5.Content == player && btn9.Content == player) Haswon();
            else if (btn7.Content == player && btn5.Content == player && btn3.Content == player) Haswon();
            else if (counter == 9) Draw();
            
        }

        private void Draw()
        {
            Restart();
            MessageBox.Show("Draw!!", caption: "Message");
            draw++;
            lbldraw.Content = $"Draw: {draw}";
        }

        private void Restart()
        {
            counter = 0;
            foreach (var btn in buttons)
            {
                btn.Content = string.Empty;
                btn.IsEnabled = true;
            }
        }

        private void Haswon()
        {
            Restart();
            MessageBox.Show($"{player} hat Gewonnen!!", caption: "Message");
            if (player == "x")
            {
                pointsx++;
                lblx.Content = $"Points X: {pointsx}";
            }

            if(player == "o")
            {
                pointso++;
                lblo.Content = $"Points O: {pointso}";
            }

        }
        private void Switchplayer()
        {
            if (player == "x") player = "o";
            else player = "x";
        }
    }
}
