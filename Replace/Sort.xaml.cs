using PROG7312_POE_ST10119385_ChloeMoodley.Sign_In;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Xml;
using Points = PROG7312_POE_ST10119385_ChloeMoodley.Status.Points;
using System.Windows.Threading;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Net;
using System.Windows.Documents;
using System.Linq;
using System.Xml.Linq;

namespace PROG7312_POE_ST10119385_ChloeMoodley.Replace
{
    /// <summary>
    /// Interaction logic for Sort.xaml
    /// </summary>
    public partial class Sort : Window
    {

/*        //boxes floating aspect of the game
        bool goLeft, goRight, goUp, goDown;
        int boxSpeed = 12;

        //shooting aspect of the game variables
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool moveLeft, moveRight;
        List<Rectangle> itemRemover = new List<Rectangle>();

        Random random = new Random();
        int enemySpriteCounter = 0;
        int enemyCounter = 100;
        int playerSpeed = 10;
        int limit = 50;
        int score = 0;
        int damage = 0;
        int enemySpeed = 10;

        Rect playerHitBox;*/

        //List to store random generated call numbers (Troelsen and Japikse, 2017).
        List<string> listGen = new List<string>();

        //List to store sorted generated call numbers in ascending order (Troelsen and Japikse, 2017).
        List<string> listSort = new List<string>();


        //List to store sorted generated call numbers the player added (Troelsen and Japikse, 2017).
        List<string> listCompare = new List<string>();


        public double[] num = new double[11];   //array to store the numbers of the call number (Troelsen and Japikse, 2017).
        public string[] letters = new string[11];   //array to store the letters of the call number (Troelsen and Japikse, 2017).
        public string [] storeVal = new string[11]; //array to store the sorted the call numbers (Troelsen and Japikse, 2017).
        public string[] storeGenVal = new string[11]; //array to store the sorted the call numbers (Troelsen and Japikse, 2017).

        public static List<string> pointsList = new List<string>();

        public static string username;
        public static string points;
        public static string storeUserandPoints;

/*        public static int[] points;
        public static string[] username;
        public static string[] storeUserandPoints;*/

        bool hint = false;

        public Sort()
        {
            InitializeComponent();

            pop();

        }

        //The method to have 3 whole numbers and two decimal numbers for the call number taken from Liangshunet (2020)
        //Link: http://www.liangshunet.com/en/202001/141912284.htm ‌
        public double callNumbersDecimal(Random rand, double minValue, double maxValue, int decimalPlaces)
        {
            double ran = rand.NextDouble() * (maxValue - minValue) + minValue;
            return Convert.ToDouble(ran.ToString("f" + decimalPlaces));
        }


        public List<string> Generate_and_Sort()
        {
            //character array
            //Code provided by (C# Beginners Tutorial - 55 - Generating Random String, 2011)
            //Author: thenewboston
            //Link:https://www.youtube.com/watch?v=U9RdDVstjM8

            char[] Alp1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] Alp2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] Alp3 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            num = new double[11];
            letters = new string[11];

            //generate 10 random strings and numbers (Troelsen and Japikse, 2017).
            for (int i = 0; i < 10; ++i)
            {

                //generating random strings (Tutorialsteacher, 2021)
                //Link:https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp 

                //Code provided by C# Beginners Tutorial - 55 - Generating Random String (2011)
                //Author: thenewboston
                //Link:https://www.youtube.com/watch?v=U9RdDVstjM8

                Random GenString = new Random();
                string genRanString = "";
                genRanString = Alp1[GenString.Next(0, 25)].ToString() + Alp2[GenString.Next(0, 25)].ToString() + Alp3[GenString.Next(0, 25)].ToString();

                //generating random numbers (Tutorialsteacher, 2021)
                //Link:https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp 

                Random genNum = new Random();
                double genRanNum = callNumbersDecimal(genNum, 100.99, 900.99, 2); // 2 decimal places round off

                //storing generated numbers and strings in an array (Troelsen and Japikse, 2017).
                num[i] = genRanNum;
                letters[i] = genRanString;

                //adding the random numbers and letters combined to make the call number in a list (Troelsen and Japikse, 2017).
                listGen.Add(genRanNum + genRanString);

            }

            //list returned
            return listGen;
        }

        public void pop()
        {
            Generate_and_Sort();

            dis1.Text = listGen.ElementAt(0);
            dis2.Text = listGen.ElementAt(1);
            dis3.Text = listGen.ElementAt(2);
            dis4.Text = listGen.ElementAt(3);
            dis5.Text = listGen.ElementAt(4);
            dis6.Text = listGen.ElementAt(5);
            dis7.Text = listGen.ElementAt(6);
            dis8.Text = listGen.ElementAt(7);
            dis9.Text = listGen.ElementAt(8);
            dis10.Text = listGen.ElementAt(9);
        }

        //Method that sorts the call number in ascending order
        public string[] Ascending(double[] array1, string[] array2)
        {

            double val;
            string val1;

            //bubble sort code was used to arrange the call numbers in ascending order adapted by Tutorialspoint (2020)
            //Link: https://www.tutorialspoint.com/Bubble-Sort-program-in-Chash 
            for (int i = 0; i < array1.Length - 1; i++)
            {
                for (int k = 0; k < array1.Length - 1 - i; k++)
                {
                    if (array1[k] > array1[k + 1])
                    {
                        //sorting the call number in ascending 
                        val = array1[k];
                        array1[k] = array1[k + 1];
                        array1[k + 1] = val;

                        //sorting the string number to corrrespond with the call number
                        val1 = array2[k];
                        array2[k] = array2[k + 1];
                        array2[k + 1] = val1;

                        //storing the sorted call number in an array (Troelsen and Japikse, 2017).
                        storeVal[k] = array1[k + 1].ToString() + array2[k + 1];
                    }
                }
            }

            //returned the array
            return storeVal;
        }

        //a method to store the sorted storage array in a list (Troelsen and Japikse, 2017).
        public void populateSortedList()
        {
            foreach (var item in storeVal)
            {
                listSort.Add(item);

            }
        }

        //storing the text box data into a list
        public void saveTextData()
        {
            listCompare.Clear();

            listCompare.Add(enteredNum1.Text);
            listCompare.Add(enteredNum2.Text);
            listCompare.Add(enteredNum3.Text);
            listCompare.Add(enteredNum4.Text);
            listCompare.Add(enteredNum5.Text);
            listCompare.Add(enteredNum6.Text);
            listCompare.Add(enteredNum7.Text);
            listCompare.Add(enteredNum8.Text);
            listCompare.Add(enteredNum9.Text);
            listCompare.Add(enteredNum10.Text);

        }


/*        private void generate1_Loaded(object sender, RoutedEventArgs e)
        {
            //random call number method called (Troelsen and Japikse, 2017).
            Generate_and_Sort();

            //foreach to display all call numbers generated adapted by Load Listview C# with list of objects (2018)
            //YouTube video, by IntCoder.
            //Link: https://www.youtube.com/watch?v=8pDBfDsqvQw 
            foreach (var genList in listGen)
            {
                generate1.Items.Add(genList);
            }
        }*/

        private void hintBox_Loaded(object sender, RoutedEventArgs e)
        {
            //method called to sort call numbers in ascending order
            Ascending(num, letters);

            //method called to add the storage array into a list
            populateSortedList();

            //foreach to display the sorted call numbers if hint is pressed
            //YouTube video, by IntCoder.
            //Link: https://www.youtube.com/watch?v=8pDBfDsqvQw 
            foreach (var item in listSort)
            {

                hintBox.Items.Add(item);

            }

        }

        private void again_butt_Click(object sender, RoutedEventArgs e)
        {

            Sort sort = new Sort();
            this.Close();
            sort.Show();

        }

        private void exit_butt_Click(object sender, RoutedEventArgs e)
        {
            DashBoard dash = new DashBoard();
            this.Close();
            dash.Show();
        }

        private void submit_butt_Click(object sender, RoutedEventArgs e)
        {
            saveTextData();


            //This nested foreach compares both the list that stores the textbox data to the list with the sorted call numbers
            //The nested foreach loop concept was adpated by Kodify(2019) 
            //Link: https://kodify.net/csharp/loop/nested-loop/ 
            foreach (var listsort in listSort)
            {
                foreach (var listcompare in listCompare)
                {
                    if (listcompare.Contains(listsort))
                    {
                        //This code was taken by Microsoft (2021)
                        //Link: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/windows/how-to-open-message-box?view=netdesktop-6.0 
                        MessageBox.Show("You have successfully sorted the call numbers! \n\nPoints: 10", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }


                    else
                    {
                        MessageBox.Show("Sadly, your sorting was incorrect. Try Again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    listCompare.Clear();
                }
            }
        }

        private void hint_butt_Click(object sender, RoutedEventArgs e)
        {
            hint = true;

            //if ther user clicks hint, the list view will display with the correct ordered call numbers (Stack Overflow, 2011)
            //Link: https://stackoverflow.com/questions/5224918/changing-visibility-in-a-stackpanel
            hintBox.Visibility = Visibility.Visible;

        }

        private void points_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void pointsNew_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
