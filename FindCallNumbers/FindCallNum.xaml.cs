using PROG7312_POE_ST10119385_ChloeMoodley.Replace;
using PROG7312_POE_ST10119385_ChloeMoodley.Sign_In;
using PROG7312_POE_ST10119385_ChloeMoodley.Status;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;


namespace PROG7312_POE_ST10119385_ChloeMoodley.FindCallNumbers
{
    /// <summary>
    /// Interaction logic for FindCallNum.xaml
    /// </summary>
    public partial class FindCallNum : Window
    {
        //list to store the call numbers textbox data (Troelsen & Japikse, 2017)
        List<string> lev1 = new List<string>();
        //list to store the call numbers textbox data (Troelsen & Japikse, 2017)
        List<string> lev2 = new List<string>();
        //list to store the call numbers textbox data (Troelsen & Japikse, 2017)
        List<string> lev3 = new List<string>();

        public static Dictionary<string, string> slv31 = new Dictionary<string, string>();
        public static Dictionary<string, string> slv32 = new Dictionary<string, string>();

        List<string> newData1 = new List<string>();
        List<string> newData2 = new List<string>();

        ArrayList toplevelval = new ArrayList();
        ArrayList toplevelval2 = new ArrayList();

        string numGiven = "";

        string result = "";

        string ans;
        string ans1;

        public FindCallNum()
        {
            InitializeComponent();

            // We can access ListViewPeople here because that's the Name of our list
            // using the x:Name property in the designer.
            //ListViewPeople.ItemsSource = CSV("MultiLevel");

            CSV("MultiLevel");
            poplist();
            popSortedList();
            gameGen1();
            boxAssign();

        }

        //method made to read csv file in visual studio
        //Code modified from Stack Overflow (2022)
        //Link: https://stackoverflow.com/questions/21813461/reading-a-csv-file-into-wpf-application-c
        public IEnumerable<CallNumbersClass> CSV(string fileTitle)
        {

            // Creation of objects (Troelsen and Japikse, 2017)
            CallNumbersClass num = new CallNumbersClass();
            TreeNode<CallNumbersClass> tree = new TreeNode<CallNumbersClass>(num);

            // File extension here to make ensure it's a .csv file, error checking
            //csv file saved in bin file in the source code
            string[] check = File.ReadAllLines(System.IO.Path.ChangeExtension(fileTitle, ".csv"));

            // lines.Select allows me to project each line as a find num.
            //Code modified from Stack Overflow (2022)
            //Link: https://stackoverflow.com/questions/21813461/reading-a-csv-file-into-wpf-application-c
            return check.Select(line =>
            {
                string[] cat = line.Split(';');
                //MessageBox.Show("CAT 1" + cat[1].Count());

                //return all data in order if it is called
                return new CallNumbersClass(cat[0], cat[1], cat[2]);
            });
        }

        public void poplist()
        {
            // Creation of objects (Troelsen and Japikse, 2017)
            CallNumbersClass num = new CallNumbersClass();
            TreeNode<CallNumbersClass> store = new TreeNode<CallNumbersClass>(num);

            // add data to tree from CSV file, modifed by Troelsen and Japikse (2017) and Stack Overflow (2022)
            //Author: Ronnie Overby
            //Link:https://stackoverflow.com/questions/66893/tree-data-structure-in-c-sharp
            foreach (var item in CSV("MultiLevel"))
            {
                store.AddChild(item);
            }

            //getting node from tree and saving it to list for the first category modfied by Troelsen and Japikse (2017)
            //used linq statements to get data from the tree and save it to lists, code modifed by Microsoft (2022)
            lev1.AddRange(
            from item in store.Children
            select item.Value.Cat1);

            //getting node from tree and saving it to list for the second category modfied by Troelsen and Japikse (2017)
            //used linq statements to get data from the tree and save it to lists, code modifed by Microsoft (2022)
            lev2.AddRange(
            from item in store.Children
            select item.Value.Cat2);

            //getting node from tree and saving it to list for the third category modfied by Troelsen and Japikse (2017)
            //used linq statements to get data from the tree and save it to lists, code modifed by Microsoft (2022)
            lev3.AddRange(  
            from item in store.Children
            select item.Value.Cat3);
        }

        public void popSortedList()
        {
            int count = 0;

            //Troelsen and Japikse (2017)
            for (int i = 0; i < lev3.Count; i++)
            {

                int callnum = Int32.Parse(lev3[i].Substring(0, 3)) / 100;
                slv31.Add(lev3[i], lev1[callnum]);
                count++;

            }

            //Troelsen and Japikse (2017)
            for (int i = 0; i < lev3.Count; i++)
            {
                for (int s = 0; s < lev2.Count; s++)
                {
                    if (lev3[i].Substring(0, 2).Equals(lev2[s].Substring(0, 2)))
                    {
                        slv32.Add(lev3[i], lev2[s]);
                        break;
                    }
                }
            }
        }

        public void gameGen1()
        {

            //random generator declared adapted by (C-sharpcorner, 2020)
            //link - https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
            Random gen = new Random();

            // store 1st level values and one third level entry modified Troelsen and Japikse (2017)
            int x = 0;
            //List<int> checkLev1 = new List<int>();
            List<int> numCheck = new List<int>();

            // for loop to select 4 random first level categories modified Troelsen and Japikse (2017)
            for (int i = 0; i < 4; ++i)
            {
                //random generator adapted by (C-sharpcorner, 2020)
                x = gen.Next(lev2.Count);

                //if elese statement to ensure no repeats and categories selected are saved into an array list
                if (numCheck.Contains(x))
                {
                    --i;
                }
                else
                {
                    toplevelval.Add(slv31.ElementAt(x).Value.ToString());
                    // Sorting ArrayList in ascending Order modified by CodeProject (2022)
                    //Link: https://www.codeproject.com/Questions/1149892/How-to-sort-the-array-list-values-in-descending-or
                    toplevelval.Sort();

                    toplevelval2.Add(slv32.ElementAt(x).Value.ToString());
                    // Sorting ArrayList in ascending Order modified by CodeProject (2022)
                    //Link: https://www.codeproject.com/Questions/1149892/How-to-sort-the-array-list-values-in-descending-or
                    toplevelval2.Sort();
                    
                    numGiven = slv31.ElementAt(x).Key;
                    //code modified to remove the first for charcters of the string by Reactgo (2022)
                    //Link: https://reactgo.com/c-sharp-remove-first-character/#:~:text=To%20remove%20the%20first%20character%20of%20a%20string%2C%20we%20can,Length%2D1.
                    string remove = numGiven;
                    result = remove.Remove(0, 4);
                    numCheck.Add(x);
                }
            }
        }

        public void boxAssign()
        {

            //3rd level entry
            RandomlySelctedCallNum.Text = result;
            disCallNum1.Text = toplevelval[0].ToString();
            disCallNum2.Text = toplevelval[1].ToString();
            disCallNum3.Text = toplevelval[2].ToString();
            disCallNum4.Text = toplevelval[3].ToString();

            LEV2CallNum1.Text = toplevelval2[0].ToString();
            LEV2CallNum2.Text = toplevelval2[1].ToString();
            LEV2CallNum3.Text = toplevelval2[2].ToString();
            LEV2CallNum4.Text = toplevelval2[3].ToString();

        }

        private void Check_butt_Click(object sender, RoutedEventArgs e)
        {
            //data from the level 1 and 3 dictionary is being called and used to compare, code modified by Tutorialspoint (2022) 
            newData1.AddRange(slv31.Select(item => item.Key + item.Value));
            ans = numGiven + callnumanswer.Text;

            if (newData1.Contains(ans))
            {
                //This code was taken by Microsoft (2021)
                //Link: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/windows/how-to-open-message-box?view=netdesktop-6.0 
                MessageBox.Show("Correct\n\nPoints: 5", "Successful", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                Level2.Visibility = Visibility.Visible;
                return;
            }

            else
            {
                //This code was taken by Microsoft (2021)
                //Link: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/windows/how-to-open-message-box?view=netdesktop-6.0 
                if (MessageBox.Show("WRONG\nOK to pursue to next Level\nCancel to try again\n\nPoints: 0", "Unsuccessful", MessageBoxButton.OKCancel, MessageBoxImage.Stop) == MessageBoxResult.OK)
                {
                    Level2.Visibility = Visibility.Visible;
                }

                else
                {
                    slv31.Clear();
                    slv32.Clear();
                    toplevelval.Clear();

                    FindCallNum callnum = new FindCallNum();
                    this.Close();
                    callnum.Show();
                    return;
                }
            }
        }

        private void EXIT_button_Click(object sender, RoutedEventArgs e)
        {
            slv31.Clear();
            slv32.Clear();
            toplevelval.Clear();

            DashBoard dash = new DashBoard();
            this.Close();
            dash.Show();
        }

        private void again_button_Click(object sender, RoutedEventArgs e)
        {
            slv31.Clear();
            slv32.Clear();
            toplevelval.Clear();

            FindCallNum callnum = new FindCallNum();
            this.Close();
            callnum.Show();
        }

        private void Check2_butt_Click(object sender, RoutedEventArgs e)
        {
            //data from the level 1 and 3 dictionary is being called and used to compare, code modified by Tutorialspoint (2022) 
            newData2.AddRange(slv32.Select(item => item.Key + item.Value));
            ans1 = numGiven + callnumanswer2.Text;

            if (newData1.Contains(ans) && newData2.Contains(ans1))
            {
                //This code was taken by Microsoft (2021)
                //Link: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/windows/how-to-open-message-box?view=netdesktop-6.0 
                MessageBox.Show("Correct\n\nPoints: 10", "Successful", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                Level2.Visibility = Visibility.Visible;
                return;
            }

            else if (newData2.Contains(ans1))
            {
                //This code was taken by Microsoft (2021)
                //Link: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/windows/how-to-open-message-box?view=netdesktop-6.0 
                MessageBox.Show("Correct\n\nPoints: 5", "Successful", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                Level2.Visibility = Visibility.Visible;
                return;
            }

            else
            {
                //This code was taken by Microsoft (2021)
                //Link: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/windows/how-to-open-message-box?view=netdesktop-6.0 
                MessageBox.Show("WRONG \n\nPoints: 0", "Unsuccessful", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;

            }
        }






    }
}
