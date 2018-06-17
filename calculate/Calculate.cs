using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Calculate_Tests
{
    public class Program
    {
        public static List<TopicModel> TopicsList = new List<TopicModel>();
        public static List<int> ToStudy = new List<int>(); // Contains ID's for the current study session.
        public static List<int> ToStudyDateTest = new List<int>();
        public static GlobalVariables globals = new GlobalVariables();

        // Constants
        public const double KNOWLEDGE_LINK = -0.0512932943875506;
        public const double ONE = 1;
        public const double NEGATIVE_ONE = -1;
        public const double SINGLE_DAY = 1440; // 1440 is the quatity in minutes of a day. Probably better to just count a day as 1, instead of by 1440 minutes.





        public static void Main(string[] args)
        {
            // Get topics for the list.
            TopicsList = TopicManager.GetTopics();

            // Test Selection 
            // const int ZERO = 0;
            // Test Selection
            const int ZERO = 0;
            bool runTest = true;
            string choiceAsString;
            int choice;

            globals.TopicIndex = 0;

            while (runTest == true)
            {
                Write("\nTest choices:");
                Write("\n 0) Increment TopicIndex");
                Write("\n 1) Calculate_Forgetting_Curve: ");
                Write("\n 2) Colculate_Topic_Difficulty: ");
                Write("\n 3) Colculate_Interval_Time: ");
                Write("\n 4) Calculat_Engram_Stability: ");
                Write("\n 5) Calculate_Engram_Retrievability ");
                Write("\n 6) Process_New_Date: ");

                Write("\nEnter one of the integers to run one of the tests: ");
                choiceAsString = ReadLine();
                choice = Convert.ToInt32(choiceAsString);


                switch (choice)
                {
                    /* This top section, (as in: on top, or upper, not topic), is for me to manually do what other parts of the program do. */
                    case 0:
                        {
                            // 0
                            // Unchecked
                            Write("\nBefore method call: Topic index is == {0}. \nPress Enter.", globals.TopicIndex);
                            ReadLine();
                            Increment_TopicIndex();
                            Write("\nThe method ran. \nTopic index is now == {0}. \nPress Enter.", globals.TopicIndex);
                            ReadLine();
                            Write("\n");
                            break;
                        }
                    case 7:
                        {
                            // 7
                            // Unchecked                            
                            Write("\n");
                            ReadLine();
                            Write("\n");
                            break;
                        }



                    case 1:
                        {
                            // 1
                            // Unchecked
                            Calculate_Forgetting_Curve();
                            Write("\nCalculate forgetting curve ran.");
                            ReadLine();
                            Write("\n");
                            break;
                        }

                    case 2:
                        {
                            // 2
                            // Unchecked
                            Colculate_Topic_Difficulty();
                            Write("\nColculate_Topic_Difficulty ran.");
                            ReadLine();
                            Write("\n");
                            break;
                        }
                    case 3:
                        {
                            // 3
                            // Unchecked
                            Colculate_Interval_Time();
                            Write("\nColculate_Interval_Time ran.");
                            ReadLine();
                            Write("\n");
                            break;
                        }
                    case 4:
                        {
                            // 4
                            // Unchecked
                            Calculat_Engram_Stability();
                            Write("\nCalculat_Engram_Stability ran.");
                            ReadLine();
                            Write("\n");
                            break;
                        }

                    case 5:
                        {
                            // 5
                            // Unchecked
                            Calculate_Engram_Retrievability();
                            Write("\nCalculate_Engram_Retrievability ran.");
                            ReadLine();
                            Write("\n");
                            break;
                        }
                    case 6:
                        {
                            // 6
                            // Unchecked
                            Process_New_Date();
                            Write("\nProcess_New_Date ran.");
                            ReadLine();
                            Write("\n");
                            break;
                        }



                    default:
                        {
                            Console.WriteLine("Not an avalailable choice.");
                            ReadLine();
                            Write("\n");
                            break;
                        }
                }

            }

        }

        /* This top section is for me to manually do what other parts of the program need to do, for these tests to work. */
        // 0
        // Unchecked
        private static void Increment_TopicIndex()
        {
            const int ONE = 1;
            Write("Current TopicIndex == {0}", globals.TopicIndex);
            ReadLine();

            globals.TopicIndex = globals.TopicIndex + ONE;

            Write("New TopicIndex == {0}", globals.TopicIndex);
            ReadLine();
        }





        // 1
        // Unchecked
        // This method currently just increments ithRepetition, and calls the Calculate_Topic_Difficulty from a selection check.
        // This method can be renamed, to Increment_Repetition.
        // Calculate_Topic_Difficulty can be called from the method that calls this method, from the same selection statement that it is currently called from.
        private static void Calculate_Forgetting_Curve()
        {
            const double ONE = 1;
            double ithRepetition = TopicsList.ElementAt(globals.TopicIndex).Top_Repetition;

            ithRepetition = ithRepetition + ONE;
            if (ithRepetition == ONE)
            {
                Write("\nithRepetition == {0}", ithRepetition);
                ReadLine();
                Write("\nColculate_Topic_Difficulty can be called here, or from the method that called the current one. \nIt needs to be directly after this method. \nIt would also need to be checked from the same selection test.");
                ReadLine();
                // Colculate_Topic_Difficulty();
            }
            Write("\nIf message about difficulty does not directly preceed this message, \nthen do not call calculate_difficulty.");
            ReadLine();

            TopicsList.ElementAt(globals.TopicIndex).Top_Repetition = ithRepetition;
            Write("\n TopicsList's Top_Repetition set = {0}", ithRepetition);
            ReadLine();

            Write("\nThe follwing methods were called from this method, in the design:");
            Write("\nColculate_Interval_Time");
            Write("\nCalculat_Engram_Stability");
            Write("\nCalculate_Engram_Retrievability");
            Write("\n\n\nIt is better to call those methods, from the same one that calls this method, \nin the same intended order.");
            ReadLine();
        }

        // 2
        // Unchecked
        private static void Colculate_Topic_Difficulty()
        {
            // Since intervalTime multiplies against difficulty, and difficulty is set only once
            // then a topic could be scheduled every day for a long time if too close to 1.0, and too 
            // far apart if above 2.5

            //int TopicIndex = globals.TopicIndex + globals.One; Not sure why I wrote the stuff to the left of this message.

            Write("\nIntitalization: ");


            const double LOW_DIFFICULTY = 2.5;
            const double HIGH_DIFFICULTY = 1.3;
            double rise = LOW_DIFFICULTY - HIGH_DIFFICULTY;
            double totalProblems = TopicsList.ElementAt(globals.TopicIndex).Num_Problems;
            double correctProblems = TopicsList.ElementAt(globals.TopicIndex).Num_Correct;
            double run = totalProblems;
            double slope = rise / run;

            // Slope-Intercept formula y = mx + b
            double difficulty = (slope * correctProblems) + HIGH_DIFFICULTY;

            Write("\nLOW_DIFFICULTY = {0}", LOW_DIFFICULTY);
            Write("\nHIGH_DIFFICULTY = {0}", HIGH_DIFFICULTY);
            Write("\nrise = {0}", rise);
            Write("\ntotalProblems = {0}", totalProblems);
            Write("\ncorrectProblems = {0}", correctProblems);
            Write("\nrun = {0}", run);
            Write("\nslope = {0}", slope);
            Write("\ndifficulty = {0}", difficulty);
            Write("\nPress Enter to write the difficulty to TopicList.ElementAt(index).Top_Difficulty, and exit the method.");
            ReadLine();

            //  Write difficulty to student record file Difficulty column
            TopicsList.ElementAt(globals.TopicIndex).Top_Difficulty = difficulty;
        }

        // 3
        // Unchecked
        private static void Colculate_Interval_Time()
        {
            const double ONE = 1;

            Write("\nCalculate Interval Time, variable initialization. \nPress Enter.");
            ReadLine();
            double difficulty = TopicsList.ElementAt(globals.TopicIndex).Top_Difficulty;
            double ithRepetition = TopicsList.ElementAt(globals.TopicIndex).Top_Repetition;
            double intervalRemaining = TopicsList.ElementAt(globals.TopicIndex).Interval_Remaining;
            double intervalLength = TopicsList.ElementAt(globals.TopicIndex).Interval_Length;

            Write("\ndifficulty = {0}", difficulty);
            Write("\nithRepetition = {0}", ithRepetition);
            Write("\nintervalRemaining = {0}", intervalRemaining);
            Write("\nintervalLength = {0}", intervalLength);
            ReadLine();


            //     Second repetition will occur the next day. 
            //	   Although, the research document does not precisely
            //	   state a time frame until the second repetition. The 
            //	   values of the two variables may need to be changed, 
            //	   if the spacing is too far apart.

            Write("\nIF ithRepetition == ONE");
            ReadLine();
            if (ithRepetition == ONE)
            {
                Write("\nithRepetition is == ONE");
                ReadLine();

                // The researech document says that s == r @ 1st repetition
                intervalRemaining = SINGLE_DAY;
                intervalLength = SINGLE_DAY;
                Write("\nintervalRemaining = {0}", intervalRemaining);
                Write("\nintervalLength = {0}", intervalLength);
                ReadLine();
            }
            else
            {
                Write("\nithRepetition is NOT= ONE");
                ReadLine();
                intervalLength = intervalLength * difficulty;

                Write("\nintervalLength = {0}", intervalLength);
                ReadLine();
            }
            Write("\nSelection sequence complete.");
            ReadLine();

            intervalRemaining = intervalLength;
            Write("\nintervalRemaining = intervalLength, which is == {0}", intervalLength);
            ReadLine();


            //    Write intervalLength to student record file Interval column
            TopicsList.ElementAt(globals.TopicIndex).Interval_Length = intervalLength;
            Write("\nWrite intervalLength to student record file Interval column");
            ReadLine();

            //    Write remainingTime to student record file RTime column
            TopicsList.ElementAt(globals.TopicIndex).Interval_Remaining = intervalRemaining;
            Write("\nWrite remainingTime to student record file RTime column.");
            ReadLine();

            Write("\nCalculate Interval Time is complete \nPress Enter.");
            ReadLine();
        }

        // 4
        // Unchecked
        private static void Calculat_Engram_Stability()
        {
            Write("\nCalculat_Engram_Stability: variable initialization phase. \nPress Enter.");
            ReadLine();
            const double NEGATIVE_ONE = -1;
            // remainingTime and intervalLength represent the variables r and s of the research document, respectively.
            // The values of remainingTime, and intervalLength, represent a quantity of hours.

            double intervalRemaining = TopicsList.ElementAt(globals.TopicIndex).Interval_Remaining;
            double intervalLength = TopicsList.ElementAt(globals.TopicIndex).Interval_Length;

            // LOOK AT STUDY'S FORMULA TO DOUBLE CHECK THIS CALCULATION.
            double stabilityOfEngram = (NEGATIVE_ONE * intervalLength) / KNOWLEDGE_LINK;

            Write("\nintervalRemaining = {0}", intervalRemaining);
            Write("\nintervalLength = {0}", intervalLength);
            Write("\nstabilityOfEngram = {0}", stabilityOfEngram);
            ReadLine();

            // Write Stability to student record file Stability column
            TopicsList.ElementAt(globals.TopicIndex).Engram_Stability = stabilityOfEngram;
            Write("\nTopicsList's Engram_Stability = {0}", stabilityOfEngram);
            ReadLine();

            Write("\nCalculat_Engram_Stability is complete \nPress Enter.");
            ReadLine();
        }

        // 5
        // Unchecked
        private static void Calculate_Engram_Retrievability()
        {
            Write("\nCalculate_Engram_Retrievability: variable initialization phase. \nPress Enter.");
            ReadLine();

            double intervalLength = TopicsList.ElementAt(globals.TopicIndex).Interval_Length;
            double intervalRemaining = TopicsList.ElementAt(globals.TopicIndex).Interval_Remaining;
            double stabilityOfEngram = TopicsList.ElementAt(globals.TopicIndex).Engram_Stability;
            double power = NEGATIVE_ONE * (intervalLength - intervalRemaining) / stabilityOfEngram;
            double retrievability = Math.Exp(power);

            Write("\nintervalLength = {0}", intervalLength);
            Write("\nintervalRemaining = {0}", intervalRemaining);
            Write("\nstabilityOfEngram = {0}", stabilityOfEngram);
            Write("\npower = {0}", power);
            Write("\nretrievability = {0}", retrievability);
            ReadLine();



            ////	Write retrievability to student record file Retrievability column
            TopicsList.ElementAt(globals.TopicIndex).Engram_Retrievability = retrievability;
            Write("\nTopicsList's Engram_Retrievability = {0}", retrievability);
            ReadLine();

            Write("\nCalculate_Engram_Retrievability is complete \nPress Enter.");
            ReadLine();
        }

        // 6
        // Unchecked
        private static void Process_New_Date()
        {
            Write("\nProcess_New_Date: variable initialization phase. \nPress Enter.");
            ReadLine();

            int TopicIndex = globals.TopicIndex;
            double intervalLength = TopicsList.ElementAt(globals.TopicIndex).Interval_Length;
            double intervalRemaining = TopicsList.ElementAt(globals.TopicIndex).Interval_Remaining;
            double days = Convert.ToInt32(intervalLength / intervalRemaining);
            DateTime today = DateTime.Now;
            DateTime nextDate = today.AddDays(days);
            string nextDateString = nextDate.ToString("d");

            Write("\nTopicIndex = {0}", TopicIndex);
            Write("\nintervalLength = {0}", intervalLength);
            Write("\nintervalRemaining = {0}", intervalRemaining);
            Write("\ndays = {0}", days);
            Write("\ntoday = {0}", today);
            Write("\nnextDate = {0}", nextDate);
            Write("\nnextDateString = {0}", nextDateString);
            ReadLine();

            TopicsList.ElementAt(globals.TopicIndex).Next_Date = nextDateString;
            // Increment the array I will use as the TopicIndex of IEnumerable    

            Write("\nTopicsList's Study_Date = {0}", nextDateString);
            ReadLine();
        }
    }

    // TopicModel Class File Contents
    public class TopicModel
    {
        public int Top_ID { get; set; }
        public int Course_ID { get; set; } // If more than one course, then it may be best to not start the TopicID at ZERO for the first topic, so that less of the program needs modifying to allow multiple courses.
        public string Top_Name { get; set; } // This is only used to make things easier for building a course. I can't think of why this would be needed, other than for that purpose.
        public bool Top_Studied { get; set; }

        public string Next_Date { get; set; }
        public string First_Date { get; set; }  // I might have a feature that displays the progress of topics since their first study dates.

        // The number of correct problems, out of the total problems for a topic, 
        // is in the databse, just in case the range for the calculation of difficulty 
        // needs to be adjusted a little. The range for difficulty is not mentioned in
        // any research I could find. But, there definitely is a range. 1.3 for hardest, 
        // and 2.5 for easiest, appears to me to be correct. I will need to analyze the
        // results of research better, to see if the values need to be changed. Close is
        // good enough to me, until the program is fully functional.
        public double Num_Problems { get; set; }
        public double Num_Correct { get; set; }

        public double Top_Difficulty { get; set; }
        public double Top_Repetition { get; set; }
        public double Interval_Remaining { get; set; }

        public double Interval_Length { get; set; }
        public double Engram_Stability { get; set; }
        public double Engram_Retrievability { get; set; }
    }
    // Part of Topic Model. There can be any number of topics. I have three here just to have something at the moment.
    public class TopicManager : TopicModel
    {
        // The database needs some initial topic data to save into it, so that is what this is for.
        /* topic data initial values */
        public static List<TopicModel> GetTopics()
        {
            var Topics = new List<TopicModel>();

            Topics.Add(new TopicModel
            {
                Top_ID = 0,
                Course_ID = 0,
                Top_Name = "Sets",
                Top_Studied = false,
                Next_Date = "none",

                Num_Problems = 5,
                Num_Correct = 0,

                Top_Difficulty = 0,
                Top_Repetition = 0,
                Interval_Remaining = 0,

                Interval_Length = 0,
                Engram_Stability = 0,
                Engram_Retrievability = 0,
            }
            );
            Topics.Add(new TopicModel
            {
                Top_ID = 1,
                Course_ID = 0,
                Top_Name = "Sub Sets",
                Top_Studied = false,
                Next_Date = "none",

                Num_Problems = 4,
                Num_Correct = 0,

                Top_Difficulty = 0,
                Top_Repetition = 0,
                Interval_Remaining = 0,

                Interval_Length = 0,
                Engram_Stability = 0,
                Engram_Retrievability = 0,
            }
            );
            Topics.Add(new TopicModel
            {
                Top_ID = 2,
                Course_ID = 0,
                Top_Name = "Union and Intersection",
                Top_Studied = false,
                Next_Date = "none",

                Num_Problems = 2,
                Num_Correct = 0,

                Top_Difficulty = 0,
                Top_Repetition = 0,
                Interval_Remaining = 0,

                Interval_Length = 0,
                Engram_Stability = 0,
                Engram_Retrievability = 0,
            }
            );

            return Topics;
        }
    }

    // Global Variable Class File Contents
    public class GlobalVariables
    {
        // The variables that also exist in TopicModel, are here to reduce any confusion in the logic. These will be used as a layer between the processing, and the topic class, which is a layer between these variables, and the database.
        /* Topic Section */
        public int TopicID { get; set; } // This probably needs to change when I incorporate the other code I've written.

        /* Course Section */
        public int CourseID { get; set; }

        public bool Top_Studied { get; set; }

        public string Next_Date { get; set; }
        public string First_Date { get; set; } // I might have a feature that displays the progress of topics since their first study dates.

        public string TodayDate { get; set; } // To store as First_Date, and to compare against Next_Date.


        /* The block of code, between these same comment lines, is only for calculations that also exist in DB. */
        public double Num_Problems { get; set; }
        public double Num_Correct { get; set; }
        public double Top_Difficulty { get; set; }

        public double Top_Repetition { get; set; } // ithRepetition
        public double Interval_Remaining { get; set; } // Denoted as 's' in the study. 
        public double Interval_Length { get; set; }  // Denoted as 'r' in the study.

        public double Engram_Stability { get; set; }
        public double Engram_Retrievability { get; set; }
        /* The block of code, between these same comment lines, is only for calculations that also exist in DB. */


        // Might not use Missed_Answers, can't remember. Get rid of it if I don't.
        public double Missed_Answers { get; set; } 



        /* Increment Topic */
        public bool IncrementTopic { get; set; } // This can PROBABLY go. I believe it was going to do what TopicTopicIndex is doing, in a bad design I had that used both variables.



        public int TopicIndex { get; set; }

        /* Problem Section */
        // I need this global TopicIndex, in order to progress through the list of images.
        public int ProblemID { get; set; }
        public int ProblemTopicIndex { get; set; }

        /* Answer Section. */
        public int AnswerID { get; set; }

        /* Lesson Section */
        public int LessonID { get; set; }

        // I need these three global TopicIndexes in order to progress through the list of images, until ID matching is implemented.
        public int AnswerTopicIndexOne { get; set; }
        public int AnswerTopicIndexTwo { get; set; }
        public int AnswerTopicIndexThree { get; set; }

        // If the user selected an answer to the previous problem, and not the current problem, 
        // but clicks submit, the global variable that checks if it was correct will still hold 
        // the previous value. Therefore, "WasAnswered" needs to be true so that the problem can't 
        // be marked as correct if this value is false.
        public bool WasAnswered { get; set; }

        public string RevealAnswer { get; set; } // The letter value of the correct answer is stored here, to display which value was correct, if the user chooses the incorrect answer.

        public int Wait { get; set; } // This is used to allow the user to see the answer, and press the button again without throwing the calculation off once the user is ready to do the next problem.
        public bool CheckCorrect { get; set; }

        public bool TopicInitializerTopicIndex { get; set; }
        public int InitializerTopicIndex { get; set; }
    }
}
