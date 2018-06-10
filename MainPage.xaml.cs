using ObservableImageTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Attributes;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace ObservableImageTest
{
    public sealed partial class MainPage : Page
    {
        // Topic Stuff
        private List<TopicModel> TopicsList;
        private List<int> ToStudy = new List<int>(); // Contains ID's for the current study session.

        // Lesson Stuff
        private List<LessonModel> LessonsList;
        private ObservableCollection<LessonModel> LessonContent;

        // Answers Stuff
        private List<AnswerModel> AnswersList;
        private ObservableCollection<AnswerModel> AnswersContent;

        // Problems Stuff
        private List<ProblemModel> ProblemList;
        private ObservableCollection<ProblemModel> ProblemContent;

        // For communication between methods
        GlobalVariables globals = new GlobalVariables();

        public MainPage()
        {
            this.InitializeComponent();

            // Topic
            TopicsList = new List<TopicModel>();

            // Lesson
            LessonContent = new ObservableCollection<LessonModel>();
            LessonsList = new List<LessonModel>();

            // Problem
            ProblemContent = new ObservableCollection<ProblemModel>();
            ProblemList = new List<ProblemModel>();

            //Answer
            AnswersContent = new ObservableCollection<AnswerModel>();
            AnswersList = new List<AnswerModel>();

            SetDisplay();
        }

        // For the custom window title bar.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Over ride the title bar default colors
            ExtendAcrylicIntoTitleBar();
        }
        private void ExtendAcrylicIntoTitleBar()
        {
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveForegroundColor = Colors.White;
        }


        /* 
         * The logic of the commented out block of code right here might be useful for the updated version
         * of this program, which will allow the users to make their own courses out of any text book.
         */
        //private void NewContactButton_Click(object sender, RoutedEventArgs e)
        //{

        //    string avatar = ((Icon)AvatarComboBox.SelectedValue).IconPath;
        //    string avatarID = ((Icon)AvatarComboBox.SelectedValue).IconID;
        //    Contacts.Add(new Contact { FirstName = FirstNameTextBox.Text, LastName = LastNameTextBox.Text, AvatarPath = avatar, AvatarID = avatarID });


        //    FirstNameTextBox.Text = "";
        //    LastNameTextBox.Text = "";
        //    AvatarComboBox.SelectedIndex = -1;

        //    FirstNameTextBox.Focus(FocusState.Programmatic);
        //}

        private void SetDisplay()
        {
            const int ZERO = 0;

            // Topics
            TopicsList = TopicManager.GetTopics();
            LoadTopicIDs();

            // Problem
            ProblemList = ProblemManager.GetProblems();

            // Answer
            AnswersList = AnswerManager.GetAll();

            // Lesson
            LessonsList = LessonManager.GetLessons();

            // For decisions
            globals.ProblemInitializer = ZERO;
            globals.AnswerInitializer = ZERO;
            globals.LessonInitializer = ZERO;
            globals.Wait = ZERO;
            globals.WasAnswered = false;



            /* Learning Start */

            // Lesson Section

            // Problem Section
            FirstProblem();

            // Answer Section
            FirstAnswers();
            AnswerProblemCompare();
            LoadAnswers();

            // Lesson Section

        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var answer = (AnswerModel)e.ClickedItem;
            globals.CheckCorrect = answer.AnswerCorrect;
            globals.WasAnswered = true;


        }

        private void NExt_Click(object sender, RoutedEventArgs e)
        {
            const int ZERO = 0;
            const int ONE = 1;
            string reveal = globals.RevealAnswer;

            // Gives feedback after answer, or goes to next problem after feedback.
            if (globals.Wait == ZERO)
            {
                globals.Wait = globals.Wait + ONE;

                if (globals.WasAnswered == true)
                {
                    if (globals.CheckCorrect == true)
                    {
                        // I need to increment a counter of correct answers here for the topic,
                        // and zero the variable somewhere else after the topic is calculated.
                        Result.Text = "Good Job!";
                    }
                    else
                    {
                        Result.Text = ($"Sorry, the correct answer was {reveal}");
                    }
                }
                else
                {
                    Result.Text = ($"Sorry, the correct answer was {reveal}");
                }

            }
            else
            {
                globals.WasAnswered = false;
                Result.Text = ($" ");
                NextProblem();
                LoadProblem();
                NextAnswers();
                AnswerProblemCompare();
                LoadAnswers();
                globals.Wait = ZERO;
            }

        }

        // Check for DB

        // Create DB from default values

        // Load stored values to list from DB

        // ToStudy ID's Section
        private void LoadTopicIDs()
        {
            const int ZERO = 0;
            const int ONE = 1;
            int index;

            // Date section
            DateTime today = DateTime.Now;
            DateTime topicDate;
            int dateCompare;
            string dateAsString;

            // Process the list of AllTopics into:

            // Retry Studied TopicID's section
            // I plan on changing this so that it resets the values of the topic, back to how they were as new values,
            // IF the retrieval calculation is equal to, or less than, 90%. I chose that, because a grade of 'A' is what the users want to get.
            // Right now I just have it here so it hopefully gets studied at the Primacy end of the Serial-Position Effect. Unless I forget, 
            // then it shouldn't even be like this long enough to be used.
            index = ZERO;
            while (index < TopicsList.Count)
            {
                if (TopicsList.ElementAt(index).Top_Studied == true)
                {
                    dateAsString = TopicsList.ElementAt(index).Next_Date;
                    topicDate = DateTime.Parse(dateAsString);
                    dateCompare = DateTime.Compare(topicDate, today);

                    if (dateCompare < ZERO)
                    {
                        // Lessons and problems both depend on the ID of the topic, but answers depend on the problem ID.
                        ToStudy.Add(index);
                    }
                }

                index = index + ONE;
            }


            // Studied TopicID's scheduled for today section
            index = ZERO;
            while (index < TopicsList.Count)
            {
                if (TopicsList.ElementAt(index).Top_Studied == true)
                {
                    dateAsString = TopicsList.ElementAt(index).Next_Date;
                    topicDate = DateTime.Parse(dateAsString);
                    dateCompare = DateTime.Compare(topicDate, today);

                    if (dateCompare == ZERO)
                    {
                        // Lessons and problems both depend on the ID of the topic, but answers depend on the problem ID.
                        ToStudy.Add(index);
                    }
                }

                index = index + ONE;
            }


            // New Topic ID's section
            index = ZERO;
            while (index < TopicsList.Count)
            {
                if (TopicsList.ElementAt(index).Top_Studied == false)
                {
                    // Lessons and problems both depend on the ID of the topic, but answers depend on the problem ID.
                    ToStudy.Add(index);
                }

                index = index + ONE;
            }

            globals.TopicID = ToStudy.ElementAt(ZERO);
            globals.TopicIndex = ZERO;
        }

        // Problems Section
        private void FirstProblem()
        {
            const int ZERO = 0;
            const int ONE = 1;
            int topicID = ToStudy.ElementAt(globals.TopicIndex);
            globals.ProblemIndex = ZERO;
            int problemTopic = ProblemList.ElementAt(globals.ProblemIndex).TopicID;
            
            while (problemTopic != topicID)
            {
                if (globals.ProblemIndex < ProblemList.Count)
                {
                    globals.ProblemIndex = globals.ProblemIndex + ONE;
                }
                if (globals.ProblemIndex >= ProblemList.Count)
                {
                    globals.ProblemIndex = ZERO; // Only for testing. Needs to set a check variable for program to show "Nothing to study."
                }
                problemTopic = ProblemList.ElementAt(globals.ProblemIndex).TopicID;
            }

            LoadProblem();
        }
        private void NextProblem()
        {
            // globals.ProblemIndex++;

            const int ZERO = 0;
            const int ONE = 1;
            int topicID = ToStudy.ElementAt(globals.TopicIndex);
            globals.ProblemIndex = ZERO;
            int problemTopic = ProblemList.ElementAt(globals.ProblemIndex).TopicID;

            if (globals.TopicIndex < ToStudy.Count)
            {
                globals.TopicIndex = globals.TopicIndex + ONE;
                topicID = ToStudy.ElementAt(globals.TopicIndex);
            }
            if (globals.TopicIndex >= ToStudy.Count)
            {
                globals.TopicIndex = ZERO; // Only for testing. Needs to set a check variable for program to show "Nothing to study."
                topicID = ToStudy.ElementAt(globals.TopicIndex);
            }

            while (problemTopic != topicID)
            {
                if (globals.ProblemIndex < ProblemList.Count)
                {
                    globals.ProblemIndex = globals.ProblemIndex + ONE;
                }
                if (globals.ProblemIndex >= ProblemList.Count)
                {
                    globals.ProblemIndex = ZERO; // Only for testing. Needs to set a check variable for program to show "Nothing to study."
                }
                problemTopic = ProblemList.ElementAt(globals.ProblemIndex).TopicID;
            }

            globals.TopicID = problemTopic;
        }
        private void LoadProblem()
        {
            const int ZERO = 0;
            const int ONE = 1;
            int problemIndex = globals.ProblemIndex;

            // Keep index within range
            if (problemIndex < ZERO)
            {
                globals.ProblemIndex = ZERO;
                problemIndex = globals.ProblemIndex;
            }
            if (problemIndex >= ProblemList.Count)
            {
                globals.ProblemIndex = ZERO;
                problemIndex = globals.ProblemIndex;
            }

            // Get the problem ID into the global variable for the check when loading the answers later.
            //globals.ProblemID 

            // Copy the problem values so I can use them
            string problemPath = ProblemList.ElementAt(globals.ProblemIndex).ProblemPath;
            int problemID = ProblemList.ElementAt(globals.ProblemIndex).ProblemID;
            globals.ProblemID = problemID;


            if (globals.ProblemInitializer == ZERO)
            {
                ProblemContent.Add(new ProblemModel { ProblemPath = problemPath });

                globals.ProblemInitializer = ONE;
            }
            else
            {
                ProblemContent.RemoveAt(0);
                ProblemContent.Add(new ProblemModel { ProblemPath = problemPath });
            }


        }

        // Answers Section
        private void FirstAnswers()
        {
            const int ZERO = 0;
            const int ONE = 1;
            const int TWO = 2;

            globals.AnswerIndexOne = ZERO;
            globals.AnswerIndexTwo = ONE;
            globals.AnswerIndexThree = TWO;

        }
        private void NextAnswers()
        {
            const int ONE = 1;

            // Every problem has three answer choices. All answer choices are in a single list.
            // When the problem is incremented to the next problem, then the current three answer choices need to
            // increment to the next three answer choices. Therefore; the value of the index for the first answer choice, 
            // of the next three problems, is one greater than the value of the index for the previous THIRD answer choice,
            // before that third answer choice was randomly shuffled into the observable collection.
            globals.AnswerIndexOne = globals.AnswerIndexThree + ONE;

            // Now that "AnswerIndexOne" is greater by a value of 1 than what "AnswerIndexThree" was for
            // the previous problem, AnswerIndexTwo needs to be greater by a value of 1, than the new value
            // of "AnswerIndexOne."
            globals.AnswerIndexTwo = globals.AnswerIndexOne + ONE;

            // Just like "AnswerIndexTwo" must be greater than "AnswerIndexOne," by a value of 1; "AnswerIndexThree" should
            // be greater than "AnswerIndexTwo," by a value of 1. 
            globals.AnswerIndexThree = globals.AnswerIndexTwo + ONE;



            // Move these to be called from the button instead.
            
        }
        private void AnswerProblemCompare()
        {
            const int ZERO = 0;
            const int ONE = 1;
            const int TWO = 2;

            // Index
            int indexOne = globals.AnswerIndexOne;
            int indexTwo = globals.AnswerIndexTwo;
            int indexThree = globals.AnswerIndexThree;

            // Problem
            int problemID = globals.ProblemID;

            // Answer
            int answerOneID = AnswersList.ElementAt(indexOne).AnswerID;
            int answerThreeID = AnswersList.ElementAt(indexThree).AnswerID;

            while (answerOneID != problemID)
            {
                // Increment answer index
                globals.AnswerIndexOne = globals.AnswerIndexThree + ONE;
                globals.AnswerIndexTwo = globals.AnswerIndexOne + ONE;
                globals.AnswerIndexThree = globals.AnswerIndexTwo + ONE;

                indexOne = globals.AnswerIndexOne;
                indexThree = globals.AnswerIndexThree;

                // If indexThree greater than last index value of the answer list, reset answer index to zero. 
                indexThree = globals.AnswerIndexThree;
                if (indexThree >= AnswersList.Count)
                {
                    globals.AnswerIndexOne = ZERO;
                    globals.AnswerIndexTwo = ONE;
                    globals.AnswerIndexThree = TWO;
                }

                // Get the new answer ID to check
                indexOne = globals.AnswerIndexOne;
                answerOneID = AnswersList.ElementAt(indexOne).AnswerID;
            }
        }
        private void LoadAnswers()
        {
            const int ZERO = 0;
            const int ONE = 1;
            const int TWO = 2;


            int indexOne = globals.AnswerIndexOne;
            int indexTwo = globals.AnswerIndexTwo;
            int indexThree = globals.AnswerIndexThree;

            // Shuffle the copied index values of the answers to use.
            var indexArray = new int[] { indexOne, indexTwo, indexThree };
            new Random().Shuffle(indexArray);

            int valueOne = indexArray[ZERO];
            int valueTwo = indexArray[ONE];
            int valueThree = indexArray[TWO];

            /* Assigning letters to the randomized answers that display. "a)", "b)", and "c)", 
             * need to display in alphabetic order 
             * The number of the labels for "valueNumber" and "letterNumber" should match, because they are used for the same answer for each of the labels.
             */
            string letterOne = "a) ";
            string letterTwo = "b) ";
            string letterThree = "c) ";

            // This is used to display which answer choice is correct, if the user selects the incorrect answer.
            if (indexOne == valueOne)
            {
                globals.RevealAnswer = letterOne;
            }
            if (indexOne == valueTwo)
            {
                globals.RevealAnswer = letterTwo;
            }
            if (indexOne == valueThree)
            {
                globals.RevealAnswer = letterThree;
            }

            // Copy the answer values so I can use them
            string answerImageOne = AnswersList.ElementAt(valueOne).AnswerPath;
            bool correctIncorrectOne = AnswersList.ElementAt(valueOne).AnswerCorrect;

            string answerImageTwo = AnswersList.ElementAt(valueTwo).AnswerPath;
            bool correctIncorrectTwo = AnswersList.ElementAt(valueTwo).AnswerCorrect;

            string answerImageThree = AnswersList.ElementAt(valueThree).AnswerPath;
            bool correctIncorrectThree = AnswersList.ElementAt(valueThree).AnswerCorrect;


            if (globals.AnswerInitializer == ZERO)
            {
                AnswersContent.Add(new AnswerModel { AnswerPath = answerImageOne, DisplayLetter = letterOne, AnswerCorrect = correctIncorrectOne });
                AnswersContent.Add(new AnswerModel { AnswerPath = answerImageTwo, DisplayLetter = letterTwo, AnswerCorrect = correctIncorrectTwo });
                AnswersContent.Add(new AnswerModel { AnswerPath = answerImageThree, DisplayLetter = letterThree, AnswerCorrect = correctIncorrectThree });

                globals.AnswerInitializer = ONE;
            }
            else
            {

                AnswersContent.RemoveAt(0);
                AnswersContent.Add(new AnswerModel { AnswerPath = answerImageOne, DisplayLetter = letterOne, AnswerCorrect = correctIncorrectOne });

                AnswersContent.RemoveAt(0);
                AnswersContent.Add(new AnswerModel { AnswerPath = answerImageTwo, DisplayLetter = letterTwo, AnswerCorrect = correctIncorrectTwo });

                AnswersContent.RemoveAt(0);
                AnswersContent.Add(new AnswerModel { AnswerPath = answerImageThree, DisplayLetter = letterThree, AnswerCorrect = correctIncorrectThree });
            }
        }

        // Lesson Section
        private void LessonProblemCompare()
        {
            const int ZERO = 0;
            const int ONE = 1;
            globals.LessonIndex = ZERO;
            int index = globals.LessonIndex;
            int problemTopicID = globals.TopicID;
            int LessonID = LessonsList.ElementAt(index).LessonID;

            // Will cause infinite loop if topic ID for a problem does not match any lesson ID.
            while (LessonID != problemTopicID)
            {
                // Increment answer index
                globals.LessonIndex = globals.LessonIndex + ONE;
                
                index = globals.LessonIndex;

                // If index greater than or equal to last index value of the lesson list, reset answer index to zero.
                if (index >= LessonsList.Count)
                {
                    globals.LessonIndex = ZERO; 
                }

                // Get the new lesson ID to check
                index = globals.LessonIndex;
                LessonID = LessonsList.ElementAt(index).LessonID;
            }
        }
        private void LoadLesson()
        {
            const int ZERO = 0;
            const int ONE = 1;
            int index = globals.LessonIndex;
            string lessonImage = LessonsList.ElementAt(index).LessonPath;


            if (globals.LessonInitializer == ZERO)
            {
                LessonContent.Add(new LessonModel { LessonPath = lessonImage });
                
                globals.LessonInitializer = ONE;
            }
            else
            {

                AnswersContent.RemoveAt(0);
                LessonContent.Add(new LessonModel { LessonPath = lessonImage });
            }

        }
    }
}
