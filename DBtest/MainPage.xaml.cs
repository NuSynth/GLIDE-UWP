using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Attributes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewTestProjectOne
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {   /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */
            // Call method that stores system date into GlobalVariable's date date parameter.            
            this.InitializeComponent();
        }

        GlobalVariables globalStorage = new GlobalVariables();

        // <!-- Page 1 -->
        // <!-- Initializatiion Phase -->
        // <!-- Per Index Value --> 

        // Page 1: Step 1 
        // So Index Will Be In Range
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */


            // Need to do a method call for this
            _TruckInfo = _DefaultTruckInfo;
        }

        // Page 1: Step 2 
        // IF File Exists, or Else

        // IF
        private void Button_Two_PointOne_Click(object sender, RoutedEventArgs e)
        {
            /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */

            // Contains: var storedDateTime = _DbInfo.ElementAt(global index).Stored_Date;
            // var storedDateTime = _TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date;


            CreateDBwithFeedback();
        }

        // Else
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */


            // Need to do a method call for this
            DataBase_To_List();
        }

        // Page 1: Step 3
        // Read List Contents
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */

            // Contains: var storedDateTime = _DbInfo.ElementAt(global index).Stored_Date;
            // var storedDateTime = _TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date;

            if (_TruckInfo.Length >= 1)
            {
                // Will throw excception if DB has not been filled yet.
                if (_TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date != "false")
                {
                    var storedDateTime = _TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date;

                    // Contains ResultRight.Text = storedDateTime;
                    ResultRight.Text = storedDateTime;
                }
                else
                {
                    ResultRight.Text = "The array that the button gets the date from has been filled. But, the " +
                        "date stored is equal to \"null.\" Now press the button that stores a date without adding a day.";
                }
            }
            else
            {
                ResultRight.Text = "This button pulls values from an array, which has not been filled yet. Click the button that creates the DataBase.";
            }
        }



        // <!-- Page 2 -->
        // <!-- Updating Phase -->
        // <!-- Per Index Value -->

        // Page 2: Step 1 
        // Store Date into List
        private void Button_Click_One_PointOne(object sender, RoutedEventArgs e)
        {
            /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */

            // Contains: var storedDateTime = _DbInfo.ElementAt(global index).Stored_Date;
            // var storedDateTime = _TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date;            

            if (globalStorage.Created == true)
            {
                string dateAsString;
                string message;

                // Will throw excception if DB has not been filled yet.
                if (_TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date != null)
                {
                    var storedDateTime = _TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date;

                    // Contains ResultRight.Text = storedDateTime;
                    dateAsString = Convert.ToString(storedDateTime);
                    message = ($"A date has already been stored into the array, it is " + dateAsString + ".");

                    ResultRight.Text = message;
                }
                else
                {
                    // Commented out code does not do what I want. I have other test code to functionally decompose the problem and
                    // hopefully fix the issue underneath.

                    //_TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date = globalStorage.TodaysDate;
                    //var dateBeforeDisplay = _TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date;
                    //dateAsString = Convert.ToString(dateBeforeDisplay);

                    // Test code
                    var dateBeforeDisplay = globalStorage.TodaysDate;

                    message = dateBeforeDisplay;
                    ResultRight.Text = message;
                }
            }
            else
            {
                ResultRight.Text = "This button pulls values from an array, which has not been filled yet. Click the button that creates the DataBase.";
            }
        }

        // Page 2: Step 2 
        // Add a Day
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */

            //globalStorage.TopicIndex = 0;
            int one = 1;
            if (_TruckInfo.Length > one)
            {
                // Will throw excception if DB has not been filled yet.
                if (_TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date != "false")
                {
                    string minutesAsString = "1440";
                    int minutesAsInt = Convert.ToInt32(minutesAsString);

                    DateTime today = DateTime.Now;

                    string todayString = _TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date;

                    DateTime myDate = DateTime.ParseExact(todayString, "yyyyMMdd", null);


                    DateTime daysAway = myDate.AddMinutes(minutesAsInt);

                    DateTime studyDate = daysAway.Date; // This value is great for checing if a session is due for the day.
                    var dateToStore = studyDate.ToString("yyyyMMdd");

                    // Update _DbInfo.ElementAt(global index).Stored_Date;
                    _TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date = dateToStore;
                }
                else
                {
                    // Contains: DateTime AddMinutes(1440) to var newDateTime
                    string minutesAsString = "1440";
                    int minutesAsInt = Convert.ToInt32(minutesAsString);

                    DateTime today = DateTime.Now;

                    DateTime daysAway = today.AddMinutes(minutesAsInt);

                    DateTime studyDate = daysAway.Date; // This value is great for checing if a session is due for the day.
                    var dateToStore = studyDate.ToString("yyyyMMdd");

                    // Update _DbInfo.ElementAt(global index).Stored_Date;
                    _TruckInfo.ElementAt(globalStorage.TopicIndex).Stored_Date = dateToStore;
                }
            }
            else
            {
                ResultRight.Text = "the array was probably not filled with the database values.";
            }

        }

        // Page 2: Step 3
        // Recreate DB & Fill From List
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */

            // Call new Recreate method
            RecreateAndOpenDB();
        }




        /* These 3 buttons control the index for this test program. */
        // Increment the index by 1
        private void Negative_One_Button_Click(object sender, RoutedEventArgs e)
        {
            /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */

            // Increment global index at very last write to Ienumerable element
            globalStorage.TopicIndex++;

        }
        private void Negative_TwoNine_Click(object sender, RoutedEventArgs e)
        {
            /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */

            // Increment global index at very last write to Ienumerable element
            globalStorage.TopicIndex--;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* Erase this Once I take parts from DataBase Example 1 that I should use, 
             * after I'm finished with DataBase Example 2 Copy. */

            // Contains: var displayIndex = ("ElementAt({global index})");
            string displayIndex = ($" ElementAt({$"{ globalStorage.TopicIndex }"})");

            // Contains: ResultLeft.Text = displayIndex;
            ResultLeft.Text = displayIndex;
        }



        /* The following three methods are used for input/output of DB */
        public async void DataBase_To_List()
        {
            using (SQLiteConnection conn = await OpenOrRecreateConnection())
            {
                var infos = from p in conn.Table<TruckInfo>() select p;

                // Plan: 
                // 1) Join the elements by the newline character.
                // 2) split the attribute by the comma.
                // 3) use an if statement to check the index for entries.Length, to keep the index in boundaries.
                // 4) Fill every _TruckInfo attribute for an element at each loop run.

                var dates = string.Join(",", infos.Select(t => $"{t.Stored_Date}"));


                int index = 0;
                string[] entries = dates.Split(',');
                foreach (var attribute in dates)
                {

                    int lengthEntries = entries.Length;
                    if (index < lengthEntries)
                    {
                        _TruckInfo.ElementAt(index).Stored_Date = entries[index];
                    }

                    index++;
                }

            }

        }

        // Same as CreateDataBase, but this one prevents an exception from needing handling
        public async void CreateDBwithFeedback()
        {
            // Sets _TruckInfo to the default values, so that the new database
            // will be filled with the default values.
            // 4) Fills a list with the database valuse (same as default)

            globalStorage.Created = true;

            if (_TruckInfo.Length > 1)
            {
                // 1) Creates the database.
                // conn is an object of type SQLiteConnection, which is given the OpenOrRecreateConnection return vlaue to work with.
                // 2) Opens the database connection simply by using the method OpenOrRecreateConnection
                using (SQLiteConnection conn = await OpenOrRecreateConnection())
                {
                    // The CreateTable property of the SQLiteConnection class, creates a table out of the
                    // TruckInfo class, inside of the returned value of OpenOrRecreateConnection
                    conn.CreateTable<TruckInfo>();
                    foreach (var info in _TruckInfo)
                    {
                        // 3) Fills the Database with the dafault values, 
                        // by inserting them into the table that was just created.
                        conn.InsertOrReplace(info);
                    }

                }
            }
            else
            {
                _TruckInfo = _DefaultTruckInfo;

                // 1) Creates the database.
                // conn is an object of type SQLiteConnection, which is given the OpenOrRecreateConnection return vlaue to work with.
                // 2) Opens the database connection simply by using the method OpenOrRecreateConnection
                using (SQLiteConnection conn = await OpenOrRecreateConnection())
                {
                    // The CreateTable property of the SQLiteConnection class, creates a table out of the
                    // TruckInfo class, inside of the returned value of OpenOrRecreateConnection
                    conn.CreateTable<TruckInfo>();
                    foreach (var info in _TruckInfo)
                    {
                        // 3) Fills the Database with the dafault values, 
                        // by inserting them into the table that was just created.
                        conn.InsertOrReplace(info);
                    }

                }
            }

            // 1) Creates the database.
            // conn is an object of type SQLiteConnection, which is given the OpenOrRecreateConnection return vlaue to work with.
            // 2) Opens the database connection simply by using the method OpenOrRecreateConnection
            using (SQLiteConnection conn = await OpenOrRecreateConnection())
            {
                // The CreateTable property of the SQLiteConnection class, creates a table out of the
                // TruckInfo class, inside of the returned value of OpenOrRecreateConnection
                conn.CreateTable<TruckInfo>();
                foreach (var info in _TruckInfo)
                {
                    // 3) Fills the Database with the dafault values, 
                    // by inserting them into the table that was just created.
                    conn.InsertOrReplace(info);
                }

            }

        }

        // Copy the bare minimal until this does exactly what I want
        // P2 - #2
        public async void RecreateAndOpenDB()
        {
            /* This method almost exactly the same as "CreateDataBase()", except that it sends
             * OpenOrRecreateConnection a value of "true," and it does not set the list's values
             * equal to that of the default values. This allows the values of the updated list to 
             * be inserted into the recreated database file's table. */

            // 1) Recreate the DataBase: Creates the database by sending OpenOrRecreate a value of "true".
            // conn is an object of type SQLiteConnection, which is given the OpenOrRecreateConnection return vlaue to work with.
            // 2) Opens the database connection simply by using the method OpenOrRecreateConnection
            using (SQLiteConnection conn = await OpenOrRecreateConnection(true))
            {
                // The CreateTable property of the SQLiteConnection class, creates a table out of the
                // TruckInfo class, inside of the returned value of OpenOrRecreateConnection
                conn.CreateTable<TruckInfo>();
                foreach (var info in _TruckInfo)
                {
                    // 2) Fill the DataBase with all values from the updated list.
                    // This is different than the initial CreateDataBase method, 
                    // because _TruckInfo was not re-set with the reference to the 
                    // default list values.
                    conn.InsertOrReplace(info);
                }

            }

        }

        // Skeleton parts from DataBase Example 2 Copy

        // This array is made because I want to store data, 
        // which is different than the default values, 
        // and this array is the current data that will be updated.
        TruckInfo[] _TruckInfo = Array.Empty<TruckInfo>();

        // This database needs some truck data to save into it, so that is what this is for.
        /* truck data */
        private static TruckInfo[] _DefaultTruckInfo = new TruckInfo[]
        {


            new TruckInfo()
            {
                ID = "1",
                Name = "Burrito Boy",
                Style = "cool",
                Stored_Date = "false",
            },
            new TruckInfo()
            {
                ID = "2",
                Name = "Pasta Idol",
                Style = "Retards",
                Stored_Date = "false",
            },
            new TruckInfo()
            {
                ID = "3",
                Name = "Cake Lady",
                Style = "Old",
                Stored_Date = "false",
            },
        };


        /* Open or recreate the database */
        private async Task<SQLiteConnection> OpenOrRecreateConnection(bool ReCreate = false)
        {
            var filename = "trucks.db";
            var folder = ApplicationData.Current.LocalFolder;

            // Delete current database if it is to be recreated
            if (ReCreate)
            {
                // This returns null if it doesn't exist
                var file = await folder.TryGetItemAsync(filename);

                if (file != null)
                {
                    // File is deleted if it does exist
                    await file.DeleteAsync();
                }
            }
            // SQLite needs a path to connect with the database.
            var sqlpath = Path.Combine(folder.Path, filename);

            // Now the database is created, by creating the connection. SQLitePlatformWinRT is needed here, so 
            // that SQLite knows what platform the database is being managed within.
            return new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath);

        }

    }

    // This is needed to save some truck information.
    /* truck info class */
    public class TruckInfo
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public string Stored_Date { get; set; }

    }

    public class HoldMyShit
    {
        public string MyShit { get; set; }
    }

}
