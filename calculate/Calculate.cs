using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_No_GUI
{
    class Program
    {

        ////	/* 
        ////	   ln(K) is used in the calculatations of Retrievability and Stability 
        ////	   of engrams to 95% accuracy, where K is equal to 0.95 . The value which 
        ////	   is input to the natural logarithm never differs for the equations from 
        ////	   the research that this software is based upon. The result of ln(K) is
        ////	   stored within the constant labeled KNOWLEDGE_LINK.
        ////	*/           

        static void Main(string[] args)
        {

            /* Call method here to fill 2 lists with:
             * New Topic ID's, and Rehearsal Topic ID's. */

            // initializeComponent(); <-- or whatever it's called, I don't remember
        }
        public const double KNOWLEDGE_LINK = -0.0512932943875506;
        public const double ONE = 1;
        public const double NEGATIVE_ONE = -1;
        public const double SINGLE_DAY = 1440; // 1440 is the quatity in minutes of a day. It's global because future updates will also need access to it.

        MyGlobals globalStorage = new MyGlobals();

        private void Button_Click()
        {
            Practice_This_Topic();
        }

        //private static void Process_Learning_Software()
        //{
        //    Perform_Topic_Review();
        //    Introduce_New_Topic();
        //}

        //private static void Perform_Topic_Review()
        //{
        //    ////	Read system date
        //    var dateAndTime = DateTime.Now;
        //    var today = dateAndTime.Date;




        //    ////	Open student record file:
        //    ////    FillDB_Or_UseDB(); <--- Might do this @ program entry point instead




        //    ////	DOWHILE student record file Date column <= today AND {t.Previous_Session} != today
        //    Practice_this_topic();

        //    ////	ENDDO
        //}

        //private static void Introduce_New_Topic()
        //{

        //    ////	DOWHILE student record file Date column == NEW_TOPIC AND NOT= EOF
        //    ////		Practice_this_topic
        //    ////		set student record file linecount to zero
        //    ////		Open student record file
        //    ////	ENDDO
        //    ////END
        //}

        public void Practice_This_Topic()
        {
            ////	//Initialize variables
            ////	set missedAnswers to zero
            Process_Course_Materials();// Process_Course_Materials(reference to missedAnswers)            
                                       ////	Calculating_forgetting_curve(value of missedAnswers);


            Process_New_Date();

            ////END
        }

        public void Process_Course_Materials()//reference to missedAnswers)
        {
            ////	set totalProblems to student record totalProblems column
            ////	set correctProblems to zero
            ////	set problemsValue= (2.5 * totalProblems)
            ////	set singleProblem = (2.5 * ( totalProblems / one))
            ////	set missedAnswers = (2.5 * totalProblems)
            ////	Open directory with name == student record ID column
            ////	Open answers record file
            ////	set answers record linecount to zero
            ////	Read answers row
            ////	set answer to answers record row
            ////	set problem image ID to zero
            ////	set punisher image ID to zero
            ////	set reinforcer image ID to zero
            ////	Display instructions text file in left side of window
            ////	DOWHILE correctProblems < totalProblems
            ////		Display problem image in right side of window
            ////		Prompt user for input
            ////		Get input
            ////		IF input NOT= to answer
            ////			missedAnswers = missedAnswers + one
            ////			Hide problem image
            ////			Display punisher image in right side of window
            ////			wait for user to go back to problem
            ////			Close punisher image
            ////			missedAnswers = missedAnswers - one
            ////		ENDIF
            ////		IF input == to answer THEN			
            ////			Close problem image
            ////			Display reinforcer image in right side of window
            ////			wait for user to go to next problem
            ////			Close reinforcer image
            ////			IF correctProblems < totalProblems THEN
            ////				increment answers record linecount
            ////				Read answers record row
            ////				set answer to answers record row
            ////				increment problem image ID
            ////				increment punishment image ID
            ////				increment reinforcer image ID
            ////			ENDIF
            ////// Add Retrievability to display in Review_past_topics course work
            ////// before topic is finished, to show low, then when
            ////// answered correctly, to show high.
            /////* Example: 
            ////		IF student record file Date column == today
            ////	IF date != new THEN
            ////		Display Retrievability at input prompts
            ////	ENDIF

            ////	// Always display retrievability when topic is is finished
            ////	IF correctAnswers == totalAnswers THEN
            ////		Display new Retrievability after reinforcer display
            ////	ENDIF
            ////*/
            ////		ENDIF
            ////	ENDDO
            ////	Go to previous directory
        }

        ////// All values, except for the the natural logarithm of 0.95, are initially set at zero in the student record
        ////Calculate_forgetting_curve(value of missedAnswers)
        public void Calculate_Forgetting_Curve()
        {
            double ithRepetition = _TopicInfo.ElementAt(globalStorage.Index).Top_Repetition;

            ithRepetition += ONE;
            if (ithRepetition == ONE)
            {
                Colculate_Topic_Difficulty();
            }

            _TopicInfo.ElementAt(globalStorage.Index).Top_Repetition = ithRepetition;
            Colculate_Interval_Time();
            Calculat_Engram_Stability();
            Calculate_Engram_Retrievability();
        }

        //Calculate_topic_difficulty(value of missed, reference to difficulty, value of totalProblems)
        public void Colculate_Topic_Difficulty()
        {
            // Since intervalTime multiplies against difficulty, and difficulty is set only once
            // then a topic could be scheduled every day for a long time if too close to 1.0, and too 
            // far apart if above 2.5

            //int index = globalStorage.Index + globalStorage.One; Not sure why I wrote the stuff to the left of this message.

            const double LOW_DIFFICULTY = 2.5;
            const double HIGH_DIFFICULTY = 1.3;
            double rise = LOW_DIFFICULTY - HIGH_DIFFICULTY;
            double totalProblems = _TopicInfo.ElementAt(globalStorage.Index).Num_Problems;
            double correctProblems = _TopicInfo.ElementAt(globalStorage.Index).Num_Correct;
            double run = totalProblems;
            double slope = rise / run;

            // Slope-Intercept formula y = mx + b
            double difficulty = (slope * correctProblems) + HIGH_DIFFICULTY;

            //  Write difficulty to student record file Difficulty column
            _TopicInfo.ElementAt(globalStorage.Index).Top_Difficulty = difficulty;
        }

        ////Calculate_interval_time(value of ithRepetition)
        public void Colculate_Interval_Time()
        {
            double difficulty = _TopicInfo.ElementAt(globalStorage.Index).Top_Difficulty;
            double ithRepetition = _TopicInfo.ElementAt(globalStorage.Index).Top_Repetition;
            double intervalRemaining = _TopicInfo.ElementAt(globalStorage.Index).Interval_Remaining;
            double intervalLength = _TopicInfo.ElementAt(globalStorage.Index).Interval_Length;
            //     Second repetition will occur the next day. 
            //	   Although, the research document does not precisely
            //	   state a time frame until the second repetition. The 
            //	   values of the two variables may need to be changed, 
            //	   if the spacing is too far apart.

            if (ithRepetition == ONE)
            {
                // The researech document says that s == r @ 1st repetition
                intervalRemaining = SINGLE_DAY;
                intervalLength = SINGLE_DAY;
            }
            else
            {
                intervalLength = intervalLength * difficulty;
            }

            intervalRemaining = intervalLength;

            //    Write intervalLength to student record file Interval column
            _TopicInfo.ElementAt(globalStorage.Index).Interval_Length = intervalLength;

            //    Write remainingTime to student record file RTime column
            _TopicInfo.ElementAt(globalStorage.Index).Interval_Remaining = intervalRemaining;
        }

        public void Calculat_Engram_Stability()
        {
            // remainingTime and intervalLength represent the variables r and s of the research document, respectively.
            // The values of remainingTime, and intervalLength, represent a quantity of hours.

            double intervalRemaining = _TopicInfo.ElementAt(globalStorage.Index).Interval_Remaining;
            double intervalLength = _TopicInfo.ElementAt(globalStorage.Index).Interval_Length;

            // LOOK AT STUDY'S FORMULA TO DOUBLE CHECK THIS CALCULATION.
            double stabilityOfEngram = (NEGATIVE_ONE * intervalLength) / KNOWLEDGE_LINK;

            // Write Stability to student record file Stability column
            _TopicInfo.ElementAt(globalStorage.Index).Engram_Stability = stabilityOfEngram;
        }

        public void Calculate_Engram_Retrievability()
        {
            double intervalLength = _TopicInfo.ElementAt(globalStorage.Index).Interval_Length;
            double intervalRemaining = _TopicInfo.ElementAt(globalStorage.Index).Interval_Remaining;
            double stabilityOfEngram = _TopicInfo.ElementAt(globalStorage.Index).Engram_Stability;
            double power = NEGATIVE_ONE * (intervalLength - intervalRemaining) / stabilityOfEngram;
            double retrievability = Math.Exp(power);

            ////	Write retrievability to student record file Retrievability column
            _TopicInfo.ElementAt(globalStorage.Index).Interval_Length = retrievability;
        }


        public void Process_New_Date()
        {
            int index = globalStorage.Index;
            double intervalLength = _TopicInfo.ElementAt(globalStorage.Index).Interval_Length;
            double intervalRemaining = _TopicInfo.ElementAt(globalStorage.Index).Interval_Remaining;

            double days = Convert.ToInt32(intervalLength / intervalRemaining);
            DateTime today = DateTime.Now;
            DateTime daysAway = today.AddDays(days);
            _TopicInfo.ElementAt(globalStorage.Index).Study_Date = Convert.ToString(daysAway);
            // Increment the array I will use as the index of IEnumerable
        }

        /* Might be a good part to write code that updates the database. */


        /* Need to store index values for:
         * 
         * ElementAt(globalStorage.Index) 
         *  
         * into two arrays, or lists. One array, or list, for 
         * indexes of dates <= todays date, another array for 
         * blank dates (new dates).
         * 
         * This will make:
         * 
         *      globalStorage.Index
         *  
         *  become:
         *  
         *      reviewArray(index) 
         *      
         *      and
         *      newArray(index)
         *      
         *  Those arrays will copy into another list:
         *      
         *      index = 0;
         *      If ( reviewArray(index)  != null ) // reviewArray is null, if there is nothing to review up to the current date.
         *      {
         *          currentIndexList = reviewArray(index);
         *          Perform_Study; // or whatever it's called. The indexes will run out, 
         *          // and the next phase needs to begin, which is to make index = 0; currentIndexList = newArray(index);
         *      }
         *      index = 0;
         *      currentIndexList = newArray(index);
         *      Perform_Study;
         *      
         *      // No else selection needed.
         *      
         *      
         * /
       

        /* New method that decides to make or use DB */
        public async void FillDB_Or_UseDB()
        {
            var dataFile = "courses.sqlite";
            var folder = ApplicationData.Current.LocalFolder;

            // This returns null if it doesn't exist
            var file = await folder.TryGetItemAsync(dataFile);

            // Create new DB if one does not exist.
            if (file == null)
            {
                // This check may need to be carried out in a different method
                Fill_Empty_DB();
            }

            // Displays Database Contents       
            Implement_Existing_File();

        }

        // Fills db from default values if file just made
        public async void Fill_Empty_DB()
        {
            _TopicInfo = _DefaultTopicInfo;

            // Almost the same as original
            using (SQLiteConnection connection = await Initialize_Db_Connection())
            {
                connection.CreateTable<TopicInfo>();

                // Creates the database, or fills it. Not sure yet.
                foreach (var info in _TopicInfo)
                {
                    connection.InsertOrReplace(info);
                }

            }
        }

        // This reads data values from existing db
        public async void Implement_Existing_File()
        {
            using (var conn = await Initialize_Db_Connection())
            {
                var infos = from p in conn.Table<TopicInfo>() select p;

                // Table values
                var names = string.Join("\n", infos.Select(t =>
                $"\nTopic ID: {t.Top_ID} " +
                $"\nTopic Name: {t.Top_Name} " +
                $"\nCourse ID Number: {t.Course_ID}" +

                $"\nTopic Studied: {t.Top_Studied} " +
                $"\nPrevious Study Date: {t.Previous_Session}" +
                $"\nDate Studied: {t.Study_Date} " +

                $"\nNumber of Problems: {t.Num_Problems} " +
                $"\nCorrect 1st Answers: {t.Num_Correct} " +
                $"\nTopic Difficulty: {t.Top_Difficulty} " +
                $"\nithRepetition: {t.Top_Repetition} " +
                $"\nRemaining interval: {t.Interval_Remaining} " +
                $"\nInterval Length: {t.Interval_Length} " +
                $"\nEngram Stability: {t.Engram_Stability} " +
                $"\nEngram Retrievability: {t.Engram_Retrievability} "));

                //var id = string.Join("\n", infos.Select(t => t.Top_ID));
                //Result.Text = names;
                textHolder.HoldText = names;
            }
        }

        // This array is made because I want to store data, 
        //and this array is the current data
        TopicInfo[] _TopicInfo = Array.Empty<TopicInfo>();

        // This database needs some initial topic data to save into it, so that is what this is for.
        /* topic data initial values */
        private static TopicInfo[] _DefaultTopicInfo = new TopicInfo[]
        {
           new TopicInfo()
            {
                Top_ID = 0001,
                Top_Name = "Sets",
                Top_Studied = false,

                First_Date = null,
                Study_Date = null,
                Num_Problems = 5,
                Num_Correct = 0,

                Top_Difficulty = 0,
                Top_Repetition = 0,
                Interval_Remaining = 0,

                Interval_Length = 0,
                Engram_Stability = 0,
                Engram_Retrievability = 0,

                Course_ID = 0001,
            },
           new TopicInfo()
            {
                Top_ID = 0002,
                Top_Name = "Sub Sets",
                Top_Studied = false,

                First_Date = null,
                Study_Date = null,
                Num_Problems = 4,
                Num_Correct = 0,

                Top_Difficulty = 0,
                Top_Repetition = 0,
                Interval_Remaining = 0,

                Interval_Length = 0,
                Engram_Stability = 0,
                Engram_Retrievability = 0,

                Course_ID = 0001,
            },
           new TopicInfo()
            {
                Top_ID = 0003,
                Top_Name = "Union and Intersection",
                Top_Studied = false,

                First_Date = null,
                Study_Date = null,
                Num_Problems = 2,
                Num_Correct = 0,

                Top_Difficulty = 0,
                Top_Repetition = 0,
                Interval_Remaining = 0,

                Interval_Length = 0,
                Engram_Stability = 0,
                Engram_Retrievability = 0,

                Course_ID = 0001,
            },
        };

        /* Create database if file does not exist */
        private async Task<SQLiteConnection> Initialize_Db_Connection()
        {

            // This group of code will essentially do what the first button does 
            // in the database program I copied, except it only makes the db if 
            // the file does not exist.

            var dataFile = "courses.sqlite";
            var folder = ApplicationData.Current.LocalFolder;

            // This returns null if it doesn't exist
            var file = await folder.TryGetItemAsync(dataFile);

            // SQLite wants an actual path to create the database in.
            var sqlpath = Path.Combine(folder.Path, dataFile);

            // Now the database is created, by creating the connection. SQLitePlatformWinRT is needed here, so 
            // that SQLite knows what it's dealing with. 13:18 in video 19
            return new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath);

        }



    }
    // This is needed to save topic information.
    /* topic info class */
    public class TopicInfo
    {
        [PrimaryKey]
        public int Top_ID { get; set; }
        public string Top_Name { get; set; }
        public bool Top_Studied { get; set; }

        public string First_Date { get; set; }

        public string Study_Date { get; set; }
        public double Num_Problems { get; set; }
        public double Num_Correct { get; set; }

        public double Top_Difficulty { get; set; }
        public double Top_Repetition { get; set; }
        public double Interval_Remaining { get; set; }

        public double Interval_Length { get; set; }
        public double Engram_Stability { get; set; }
        public double Engram_Retrievability { get; set; }

        public int Course_ID { get; set; }

    }

    public class MyGlobals
    {
        public int Index { get; set; }
        public string HoldText { get; set; }
    }
}


/* This works to iterate through the database, when the name "_Settings" is changed to the IEnumerable array looking things name. */
// _TopicInfo.ElementAt(globalIndex).AttributeName = "Name2";
