using PROG7312_POE_ST10119385_ChloeMoodley.Replace;
using PROG7312_POE_ST10119385_ChloeMoodley.Sign_In;
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
using System.Windows.Shapes;

namespace PROG7312_POE_ST10119385_ChloeMoodley.Status
{
    /// <summary>
    /// Interaction logic for Points.xaml
    /// </summary>
    public partial class Points : Window
    {
        public Points()
        {
            InitializeComponent();
        }

        private void replace_again_Click(object sender, RoutedEventArgs e)
        {
            //open next window (Stack Overflow, 2021)
            //Author: Peter Mortensen
            //link: https://stackoverflow.com/questions/11133947/how-do-i-open-a-second-window-from-the-first-window-in-wpf 

            Sort sort = new Sort();
            this.Close();
            sort.Show();
        }

        private void identify_again_Click(object sender, RoutedEventArgs e)
        {

        }

        private void find_again_Click(object sender, RoutedEventArgs e)
        {

        }

        private void next_butt_Click(object sender, RoutedEventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
            this.Close();   
            dashBoard.Show();
        }

        private void lastGame_Loaded(object sender, RoutedEventArgs e)
        {
            //lastGame.Text = Sort.points;

            //lastGame.Text = Sort.pointsList.ElementAt(0);
            //lastGame.Items.Add(Sort.pointsList.ToString());

/*            foreach (var item in Sort.pointsList)
            {
                lastGame.Items.Add(item.ElementAt(0));
            }*/

        }
    }
}
