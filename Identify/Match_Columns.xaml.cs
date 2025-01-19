using PROG7312_POE_ST10119385_ChloeMoodley.Replace;
using PROG7312_POE_ST10119385_ChloeMoodley.Sign_In;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace PROG7312_POE_ST10119385_ChloeMoodley.Identify
{
    /// <summary>
    /// Interaction logic for Match_Columns.xaml
    /// </summary>
    public partial class Match_Columns : Window
    {

        //list to store the call numbers textbox data (Troelsen & Japikse, 2017)
        List<string> ListCallNumbersTxtBox = new List<string>();

        //list to store the descriptions textbox data (Troelsen & Japikse, 2017)
        List<string> ListDescriptionsTxtBox = new List<string>();

        bool hint = false;

        bool compare = true;

        int callnumberordescriptionoption;

        //Arrays to store the four keys and values from the dictionary (Troelsen & Japikse, 2017)
        public static string[] orderedKeys = new string[4];
        //stores the 4 descriptions generated (Troelsen & Japikse, 2017)
        public static string[] orderedValues = new string[4];
        //stores the extra 3 descriptions (Troelsen & Japikse, 2017)
        public static string[] other3Values = new string[4];


        //dictionary to store the 5 potenial sets of descriptions for each call number (Troelsen & Japikse, 2017)
        public static Dictionary<string, string> store1 = new Dictionary<string, string>();
        public static Dictionary<string, string> store2 = new Dictionary<string, string>();
        public static Dictionary<string, string> store3 = new Dictionary<string, string>();
        public static Dictionary<string, string> store4 = new Dictionary<string, string>();
        public static Dictionary<string, string> store5 = new Dictionary<string, string>();

        //dictionary to store the generated 4 call numbers and descriptions (Troelsen & Japikse, 2017)
        public static Dictionary<string, string> newOrderedNums = new Dictionary<string, string>();

        //dictionary to store what the users enter through the textboxes (Troelsen & Japikse, 2017)
        public static Dictionary<string, string> newComparedDic = new Dictionary<string, string>();



        public Match_Columns()
        {
            InitializeComponent();
        }

        //method to assign all 5 call numbers and descriptions together (Troelsen & Japikse, 2017)
        public void assignCallNumbersandDescriptions()
        {
            //store set 1 of descriptions, code modified from (Microsoft, 2022)
            //Link: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.add?view=net-7.0 
            store1.Add("000 General Knowledge", "Overall information that has been gathered from different sources throughout a period of time");
            store1.Add("100 Psychology and Philosophy", "Deals with both epistemological and ontological issues and shares interests with other fields");
            store1.Add("200 Religions and Mythology", "A system organized beliefs and practices based on worshipping supernatural forces or beings");
            store1.Add("300 Social Sciences and Folklore", "A compilation of the beliefs, customs, mores, and practices of distinct cultural groups");
            store1.Add("400 Languages and Grammar", "What can be considered as the rules of langauge");
            store1.Add("500 Math and Science", "The science and study of quality, structure, space, and change");
            store1.Add("600 Medicine and Technology", "Technologies that diagnose, treat and/or improve a person's health and wellbeing");
            store1.Add("700 Arts and Recreation", "Tasks that people choose to do to refresh their bodies and minds");
            store1.Add("800 Literature", "A collection of written work");
            store1.Add("900 Geography and History", "A study of a place or region at a specific time");

            //store set 2 of descriptions, code modified from (Microsoft, 2022)
            //Link: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.add?view=net-7.0 
            store2.Add("000 General Knowledge", "Can be considered as crucial aspect of crystallized intelligence");
            store2.Add("100 Psychology and Philosophy", "The study of the human mind and its behaviour in a given social context");
            store2.Add("200 Religions and Mythology", "The use of myths in particular religious/cultural tradition collection to explain a belief/practice");
            store2.Add("300 Social Sciences and Folklore", "Unrecorded traditions of a people consisting of customs and stories passed through the generations through word of mouth");
            store2.Add("400 Languages and Grammar", "Assits with a readers comprehension");
            store2.Add("500 Math and Science", "Education that provides a framework on how to assist people/scholars in finding answers");
            store2.Add("600 Medicine and Technology", "Enable the early and accurate diagnosis of health problems");
            store2.Add("700 Arts and Recreation", "Live music, singing, painting, drawing, making collages, and using textiles");
            store2.Add("800 Literature", "Imaginative works of poetry, drama and prose");
            store2.Add("900 Geography and History", "Enables us to question why, when, and how something happened in the past");

            //store set 3 of descriptions, code modified from (Microsoft, 2022)
            //Link: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.add?view=net-7.0 
            store3.Add("000 General Knowledge", "A broad range of facts on serveral subjects, such as important events, history, etc");
            store3.Add("100 Psychology and Philosophy", "The fundamental nature of knowledge, reality, and existence");
            store3.Add("200 Religions and Mythology", "Concepts of high regard in certain community, that make statements on supernatural or sacred");
            store3.Add("300 Social Sciences and Folklore", "General spectrum of social expression, examining the forms of living");
            store3.Add("400 Languages and Grammar", "The structure of words, phrases, clauses, sentences, and whole texts");
            store3.Add("500 Math and Science", "What is an intrinsic component of science");
            store3.Add("600 Medicine and Technology", "The medical field will be able to make discoveries regarding treatments using AI's");
            store3.Add("700 Arts and Recreation", "Something which holds the interest and attention amoung people");
            store3.Add("800 Literature", "Enables humans to display and feel a wide range of emotions");
            store3.Add("900 Geography and History", "What is Eratosthenes considered the father of");

            //store set 4 of descriptions, code modified from (Microsoft, 2022)
            //Link: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.add?view=net-7.0 
            store4.Add("000 General Knowledge", "Culturally accepted and valued information on numerous topics");
            store4.Add("100 Psychology and Philosophy", "Attempting to understand the existence of the human life while intergrating it with human behaviour");
            store4.Add("200 Religions and Mythology", "What answers timeless questions and serve as a compass to each generation");
            store4.Add("300 Social Sciences and Folklore", "Traditional customs, tales, sayings, dances, or art forms preserved among a people");
            store4.Add("400 Languages and Grammar", "The structural foundation of our abiity to express ourselve through verbal and non-verbal means of communication");
            store4.Add("500 Math and Science", "Assits with people having curiosity, imagination, flexibility, inventiveness, and persistence");
            store4.Add("600 Medicine and Technology", "What topic can closely be related to pacemakers and medical imaging technologies");
            store4.Add("700 Arts and Recreation", "Things that could lowers feelings of depression and increases feelings of confidence");
            store4.Add("800 Literature", "A language model for those who hear and read it is provided");
            store4.Add("900 Geography and History", "The relationships between people and their environments");

            //store set 5 of descriptions, code modified from (Microsoft, 2022)
            //Link: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.add?view=net-7.0 
            store5.Add("000 General Knowledge", "Topics that assist us to grow both on personal as well as academic level by absorbing knowledge by many means");
            store5.Add("100 Psychology and Philosophy", "The systematic study of the interplay between philosophical concerns in the study of cognition");
            store5.Add("200 Religions and Mythology", "Something that gives context into our world, our literature, and our own beliefs");
            store5.Add("300 Social Sciences and Folklore", "Something that gives the wisdom to understand these moments from different points of view");
            store5.Add("400 Languages and Grammar", "Enables us to be clearly understood by others");
            store5.Add("500 Math and Science", "Fundamental to national prosperity in providing tools for understanding science");
            store5.Add("600 Medicine and Technology", "What category does robotic surgery fall under");
            store5.Add("700 Arts and Recreation", "Enables conditions for being physically active on a regular basis");
            store5.Add("800 Literature", "A portal into other people thar allows us to experience our culture, identity, and personal past");
            store5.Add("900 Geography and History", "Shows humans how events in the past made things the way they are today");
        }

        //method that randomly chooses for calls numbers and descriptions for the user to use in match the columns
        public void generate4callnums()
        {
            //method with the assigned values is called
            assignCallNumbersandDescriptions();

            //storing non repeated values adabpted by (W3schools, 2022)
            //Link - https://www.w3schools.com/java/java_arraylist.asp
            ArrayList storeList = new ArrayList();

            //storing non repeated values adabpted by (W3schools, 2022)
            //Link - https://www.w3schools.com/java/java_arraylist.asp
            ArrayList newstoreList = new ArrayList();


            //storing non repeated values adapted by (Tutorialspoint, 2022)
            //Link  - https://www.tutorialspoint.com/csharp/csharp_arrays.htm
            string[] extra3 = new string[4];

            //random generator declared adapted by (C-sharpcorner, 2020)
            //link - https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
            Random gen = new Random();

            //generator to choose between the 5 sets of decriptions in the dictionaries adapted by (C-sharpcorner, 2020)
            //link - https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
            int generate4 = gen.Next(1, 5);
            int randSel;
            int another;

            //switch statement used to choose between the 5 dictionaries randomly 
            //code adapted by (Microsoft, 2022)
            //link - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements 
            switch (generate4)
            {
                case 1:
                    //this for statement chooses 4 description and call number pairs from the 10 and stores the called pairs into 2 arrays then both are stored in a list array
                    for (int i = 0; i < 4; i++)
                    {
                        //randomly picking the call numbers and descriptions from the 10 options in the dictionary
                        randSel = gen.Next(0, 9);

                        //if contents in the array list repeat then it will decrease again to another option within the 10 while still ensuring only 4 call numbers and descriptions are generated
                        if (storeList.Contains(randSel))
                        {
                            --i;
                        }

                        //if all call numbers and descriptions are different, then the call numbers and descriptions will be assigned to arrays and stored in an array list (Troelsen & Japikse, 2017)
                        else
                        {
                            //storing the key and value into the declared array, code inspired by (Troelsen & Japikse, 2017)
                            orderedKeys[i] = store1.ElementAt(randSel).Key;
                            orderedValues[i] = store1.ElementAt(randSel).Value;

                            //adding the chosen 4 call numbers and descriptions, code inspired by (Troelsen & Japikse, 2017)
                            newOrderedNums.Add(orderedKeys[i], orderedValues[i]);
                            storeList.Add(randSel);

                            //to display the 4 descriptions in the descriptions column
                            disDescription4.Text = orderedValues[3];
                            disDescription5.Text = orderedValues[2];
                            disDescription6.Text = orderedValues[1];
                            disDescription7.Text = orderedValues[0];

                            //for loop to generate 3 extra random descriptions
                            for (int k = 0; k < 4; k++)
                            {
                                another = gen.Next(0, 9);

                                if (!storeList.Contains(another))
                                {
                                    other3Values[k] = store1.ElementAt(another).Value;
                                    newstoreList.Add(another);
                                    //Extra 3 other decriptions
                                    disDescription1.Text = other3Values[0];
                                    disDescription2.Text = other3Values[1];
                                    disDescription3.Text = other3Values[2];
                                }

                                else
                                {
                                    --k;
                                }
                            }
                        }

                    }
                    break;

                case 2:
                    //this for statement chooses 4 description and call number pairs from the 10 and stores the called pairs into 2 arrays then both are stored in a list array
                    for (int i = 0; i < 4; i++)
                    { //randomly picking the call numbers and descriptions from the 10 options in the dictionary
                        randSel = gen.Next(0, 9);

                        //if contents in the array list repeat then it will decrease again to another option within the 10 while still ensuring only 4 call numbers and descriptions are generated
                        if (storeList.Contains(randSel))
                        {
                            --i;
                        }

                        //if all call numbers and descriptions are different, then the call numbers and descriptions will be assigned to arrays and stored in an array list
                        else
                        {
                            orderedKeys[i] = store2.ElementAt(randSel).Key;
                            orderedValues[i] = store2.ElementAt(randSel).Value;
                            newOrderedNums.Add(orderedKeys[i], orderedValues[i]);
                            storeList.Add(randSel);
                            //to copy and paste in table A
                            disDescription4.Text = orderedValues[0];
                            disDescription5.Text = orderedValues[3];
                            disDescription6.Text = orderedValues[1];
                            disDescription7.Text = orderedValues[2];


                            for (int k = 0; k < 4; k++)
                            {
                                another = gen.Next(0, 9);

                                if (!storeList.Contains(another))
                                {
                                    other3Values[k] = store2.ElementAt(another).Value;
                                    newstoreList.Add(another);
                                    //Extra 3 other decriptions
                                    disDescription1.Text = other3Values[0];
                                    disDescription2.Text = other3Values[1];
                                    disDescription3.Text = other3Values[2];
                                }

                                else
                                {
                                    --k;
                                }
                            }
                        }
                    }
                    break;

                case 3:
                    //this for statement chooses 4 description and call number pairs from the 10 and stores the called pairs into 2 arrays then both are stored in a list array
                    for (int i = 0; i < 4; i++)
                    {
                        //randomly picking the call numbers and descriptions from the 10 options in the dictionary
                        randSel = gen.Next(0, 9);

                        //if contents in the array list repeat then it will decrease again to another option within the 10 while still ensuring only 4 call numbers and descriptions are generated
                        if (storeList.Contains(randSel))
                        {
                            --i;
                        }

                        //if all call numbers and descriptions are different, then the call numbers and descriptions will be assigned to arrays and stored in an array list
                        else
                        {
                            orderedKeys[i] = store3.ElementAt(randSel).Key;
                            orderedValues[i] = store3.ElementAt(randSel).Value;
                            newOrderedNums.Add(orderedKeys[i], orderedValues[i]);
                            storeList.Add(randSel);
                            //to copy and paste in table A
                            disDescription4.Text = orderedValues[2];
                            disDescription5.Text = orderedValues[0];
                            disDescription6.Text = orderedValues[1];
                            disDescription7.Text = orderedValues[3];

                        }

                        for (int k = 0; k < 4; k++)
                        {
                            another = gen.Next(0, 9);

                            if (!storeList.Contains(another))
                            {
                                other3Values[k] = store3.ElementAt(another).Value;
                                newstoreList.Add(another);
                                //Extra 3 other decriptions
                                disDescription1.Text = other3Values[0];
                                disDescription2.Text = other3Values[1];
                                disDescription3.Text = other3Values[2];
                            }

                            else
                            {
                                --k;
                            }
                        }
                    }
                    break;

                case 4:
                    //this for statement chooses 4 description and call number pairs from the 10 and stores the called pairs into 2 arrays then both are stored in a list array
                    for (int i = 0; i < 4; i++)
                    {
                        //randomly picking the call numbers and descriptions from the 10 options in the dictionary
                        randSel = gen.Next(0, 9);

                        //if contents in the array list repeat then it will decrease again to another option within the 10 while still ensuring only 4 call numbers and descriptions are generated
                        if (storeList.Contains(randSel))
                        {
                            --i;
                        }

                        //if all call numbers and descriptions are different, then the call numbers and descriptions will be assigned to arrays and stored in an array list
                        else
                        {
                            orderedKeys[i] = store4.ElementAt(randSel).Key;
                            orderedValues[i] = store4.ElementAt(randSel).Value;
                            newOrderedNums.Add(orderedKeys[i], orderedValues[i]);
                            storeList.Add(randSel);
                            //to copy and paste in table A
                            disDescription4.Text = orderedValues[3];
                            disDescription5.Text = orderedValues[0];
                            disDescription6.Text = orderedValues[1];
                            disDescription7.Text = orderedValues[2];

                            for (int k = 0; k < 4; k++)
                            {
                                another = gen.Next(0, 9);

                                if (!storeList.Contains(another))
                                {
                                    other3Values[k] = store4.ElementAt(another).Value;
                                    newstoreList.Add(another);
                                    //Extra 3 other decriptions
                                    disDescription1.Text = other3Values[0];
                                    disDescription2.Text = other3Values[1];
                                    disDescription3.Text = other3Values[2];
                                }

                                else
                                {
                                    --k;
                                }
                            }
                        }
                    }
                    break;

                case 5:
                    //this for statement chooses 4 description and call number pairs from the 10 and stores the called pairs into 2 arrays then both are stored in a list array
                    for (int i = 0; i < 4; i++)
                    {
                        //randomly picking the call numbers and descriptions from the 10 options in the dictionary
                        randSel = gen.Next(0, 9);

                        //if contents in the array list repeat then it will decrease again to another option within the 10 while still ensuring only 4 call numbers and descriptions are generated
                        if (storeList.Contains(randSel))
                        {
                            --i;
                        }

                        //if all call numbers and descriptions are different, then the call numbers and descriptions will be assigned to arrays and stored in an array list
                        else
                        {
                            orderedKeys[i] = store5.ElementAt(randSel).Key;
                            orderedValues[i] = store5.ElementAt(randSel).Value;
                            newOrderedNums.Add(orderedKeys[i], orderedValues[i]);
                            storeList.Add(randSel);
                            //to copy and paste in table A
                            disDescription4.Text = orderedValues[2];
                            disDescription5.Text = orderedValues[3];
                            disDescription6.Text = orderedValues[1];
                            disDescription7.Text = orderedValues[0];

                            for (int k = 0; k < 4; k++)
                            {
                                another = gen.Next(0, 9);

                                if (!storeList.Contains(another))
                                {
                                    other3Values[k] = store5.ElementAt(another).Value;
                                    newstoreList.Add(another);
                                    //Extra 3 other decriptions
                                    disDescription1.Text = other3Values[0];
                                    disDescription2.Text = other3Values[1];
                                    disDescription3.Text = other3Values[2];

                                }

                                else
                                {
                                    --k;
                                }
                            }
                        }
                    }
                    break;
            }


            Random choice = new Random();
            //generator to choose between what column the user has to fill in
            int leftright = choice.Next(1, 3);

            //swtich statement to determine randomly if the user must assign the call number to description, or description to call number
            //code adapted by (Microsoft, 2022)
            //link - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements 
            switch (leftright)
            {
                //this column populates the call numbers column
                case 1:
                    col2box1.Text = orderedKeys[0];
                    col2box2.Text = orderedKeys[1];
                    col2box3.Text = orderedKeys[2];
                    col2box4.Text = orderedKeys[3];

                    callnumberordescriptionoption = 1;
                    break;

                //this column populates the description column
                case 2:
                    col1box1.Text = orderedValues[0];
                    col1box2.Text = orderedValues[1];
                    col1box3.Text = orderedValues[2];
                    col1box4.Text = orderedValues[3];

                    callnumberordescriptionoption = 2;
                    break;

            }

            //displayed the random call numbers in column A
            disCallNum1.Text = orderedKeys[1];
            disCallNum2.Text = orderedKeys[3];
            disCallNum3.Text = orderedKeys[0];
            disCallNum4.Text = orderedKeys[2];
        }

        public void addkeystextboxes()
        {
            newComparedDic.Add(col2box1.Text, col1box1.Text);
            newComparedDic.Add(col2box2.Text, col1box2.Text);
            newComparedDic.Add(col2box3.Text, col1box3.Text);
            newComparedDic.Add(col2box4.Text, col1box4.Text);

            //code below reorders dictionaries, code adapted an modified (Stack Overflow, 2022)
            //Author: Thabo (2012)
            //Link: https://stackoverflow.com/questions/9547351/how-to-compare-two-dictionaries-in-c-sharp
            newComparedDic.OrderBy(kvp => kvp.Key);
            newOrderedNums.OrderBy(kvp => kvp.Key);

            if (newComparedDic.SequenceEqual(newOrderedNums))
            {
                //This code was taken by Microsoft (2021)
                //Link: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/windows/how-to-open-message-box?view=netdesktop-6.0 
                MessageBox.Show("You have matched everything\n\nPoints: 8", "Successful", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }

            else
            {
                MessageBox.Show("Incorrect match! Play again\n\nPoints: 0", "Unsuccessful", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void corrctMatches_Loaded(object sender, RoutedEventArgs e)
        {
            generate4callnums();
            foreach (var item in newOrderedNums)
            {
                corrctMatches.Items.Add(item);
            }

        }

        private void check_button_Click(object sender, RoutedEventArgs e)
        {
            hint = true;

            //if ther user clicks hint, the list view will display with the correct ordered call numbers (Stack Overflow, 2011)
            //Link: https://stackoverflow.com/questions/5224918/changing-visibility-in-a-stackpanel
            corrctMatches.Visibility = Visibility.Visible;
        }

        private void submit_button_Click(object sender, RoutedEventArgs e)
        {
            addkeystextboxes();
            newComparedDic.Clear(); 
        }

        private void Play_again_button_Click(object sender, RoutedEventArgs e)
        {
            store1.Clear();
            store2.Clear();
            store3.Clear();
            store4.Clear();
            store5.Clear();

            newOrderedNums.Clear();

            //open next window (Stack Overflow, 2021)
            //Author: Peter Mortensen
            //link: https://stackoverflow.com/questions/11133947/how-do-i-open-a-second-window-from-the-first-window-in-wpf 
            Match_Columns mc = new Match_Columns();
            this.Close();
            mc.Show();
        }

        private void EXIT_button_Click(object sender, RoutedEventArgs e)
        {
            store1.Clear();
            store2.Clear();
            store3.Clear();
            store4.Clear();
            store5.Clear();

            newOrderedNums.Clear();
            newComparedDic.Clear(); 

            DashBoard dash = new DashBoard();
            this.Close();
            dash.Show();
        }
    }


}