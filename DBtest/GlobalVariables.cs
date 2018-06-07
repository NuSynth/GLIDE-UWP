using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTestProjectOne
{
    class GlobalVariables
    {
        /* Constant Section */
        public const int ZERO = 0;
        private int zero;
        public int Zero
        {
            get => zero;
            set => zero = ZERO;
        }

        public const double KNOWLEDGE_LINK = -0.0512932943875506;
        private double knowledgeLink;
        public double KnowledgeLink
        {
            get => knowledgeLink;
            set => knowledgeLink = KNOWLEDGE_LINK;

        }

        public const double ONE_DOUBLE = 1;
        private double oneDouble;
        public double OneDouble
        {
            get => oneDouble;
            set => oneDouble = ONE_DOUBLE;
        }

        public const int ONE_INT = 1;
        private int oneInt;
        public int OneInt
        {
            get => oneInt;
            set => oneInt = ONE_INT;
        }

        public const double NEGATIVE_DOUBLE = -1;
        private double negativeDouble;
        public double NegativeDouble
        {
            get => negativeDouble;
            set => negativeDouble = NEGATIVE_DOUBLE;
        }

        public const double SINGLE_DAY = 1440; // Minutes in a day.
        private double singleDay;
        public double SingleDay
        {
            get => singleDay;
            set => singleDay = SINGLE_DAY;
        }

        public const bool TRUE = true;
        public const bool FALSE = false;


        /* Index Section */
        public int TopicIndex { get; set; }
        public int ProblemIndex { get; set; }


        /* Text Display section */
        public string HoldText { get; set; }

        /* This is here ONLY for the testing version of the application. It allows me to be informed if
         * the DB has not been created, before it gets created. */
        private bool created;
         public bool Created
        {
            get => created;
            set => created = value;
        }


        /* Answer Section for Radio Buttons and Submit Button */
        public bool Answer { get; set; }
        public double CorrectAnswers { get; set; } // Make sure to reset in the method after difficulty calculation


        /* 
         * Reinforcer and punishment switch section. Their implementation is partially based on Skinner's 
         * Galvis learning machine, with the exception of punishers here. 
         */
        public bool ReinforcePunish { get; set; } // Acts as a switch to allow user to be reinforced or punished
        public bool Reinforce { get; set; }
        public bool Punish { get; set; }


        //number of words and a price
        private string todaysDate;
        public string TodaysDate
        {
            get
            {
                DateTime thePresentDateTime = DateTime.Now;
                DateTime today = thePresentDateTime.Date;
                todaysDate = today.ToString("yyyyMMdd");

                return todaysDate;
            }
        }


        /* Problem and Topic Size Section */
        public double TopicSize { get; set; }
        public double TotalProblems { get; set; }


        /* Radio Button Answer Choice Section */
        public string AnswerOneString { get; set; }
        public string AnswerTwoString { get; set; }
        public string AnswerThreeString { get; set; }

        private bool answerOneCorrect;
        public bool AnswerOneCorrect
        {
            get => answerOneCorrect;
            set => answerOneCorrect = TRUE;
        }
        private bool answerTwoCorrect;
        public bool AnswerTwoCorrect
        {
            get => answerTwoCorrect;
            set => answerTwoCorrect = FALSE;
        }
        private bool answerThreeCorrect;
        public bool AnswerThreeCorrect
        {
            get => answerThreeCorrect;
            set => answerThreeCorrect = FALSE;
        }







    }
}
