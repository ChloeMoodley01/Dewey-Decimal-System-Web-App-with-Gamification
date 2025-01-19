using PROG7312_POE_ST10119385_ChloeMoodley.FindCallNumbers;
using PROG7312_POE_ST10119385_ChloeMoodley.Identify;
using PROG7312_POE_ST10119385_ChloeMoodley.Replace;
using System;
using System.CodeDom.Compiler;
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

namespace PROG7312_POE_ST10119385_ChloeMoodley.Sign_In
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void replace_butt_Click(object sender, RoutedEventArgs e)
        {
            //open next window (Stack Overflow, 2021)
            //Author: Peter Mortensen
            //link: https://stackoverflow.com/questions/11133947/how-do-i-open-a-second-window-from-the-first-window-in-wpf 


            Sort sort = new Sort();
            this.Close();
            sort.Show();
        }

        private void find_butt_Click(object sender, RoutedEventArgs e)
        {
            //open next window (Stack Overflow, 2021)
            //Author: Peter Mortensen
            //link: https://stackoverflow.com/questions/11133947/how-do-i-open-a-second-window-from-the-first-window-in-wpf 


            FindCallNum find = new FindCallNum();
            this.Close();
            find.Show();
        }

        private void identify_butt_Click(object sender, RoutedEventArgs e)
        {
            //open next window (Stack Overflow, 2021)
            //Author: Peter Mortensen
            //link: https://stackoverflow.com/questions/11133947/how-do-i-open-a-second-window-from-the-first-window-in-wpf 


            Match_Columns mc = new Match_Columns();
            this.Close();
            mc.Show();
        }
    }
}
