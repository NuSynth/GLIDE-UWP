using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableImageTest.Models
{
    public class GlobalVariables
    {
        /* Course Section */
        public int CourseID { get; set; }

        /* Increment Topic */
        public bool IncrementTopic { get; set; }

        /* Topic Section */
        public int TopicID { get; set; } // This probably needs to change when I incorporate the other code I've written.
        public int TopicIndex { get; set; }

        /* Problem Section */
        // I need this global index, in order to progress through the list of images.
        public int ProblemID { get; set; }
        public int ProblemIndex { get; set; }

        /* Answer Section. */
        public int AnswerID { get; set; }

        /* Lesson Section */
        public int LessonID { get; set; }

        // I need these three global indexes in order to progress through the list of images, until ID matching is implemented.
        public int AnswerIndexOne { get; set; }
        public int AnswerIndexTwo { get; set; }
        public int AnswerIndexThree { get; set; }

        // If the user selected an answer to the previous problem, and not the current problem, 
        // but clicks submit, the global variable that checks if it was correct will still hold 
        // the previous value. Therefore, "WasAnswered" needs to be true so that the problem can't 
        // be marked as correct if this value is false.
        public bool WasAnswered { get; set; }  

        public string RevealAnswer { get; set; } // The letter value of the correct answer is stored here, to display which value was correct, if the user chooses the incorrect answer.

        public int Wait { get; set; } // This is used to allow the user to see the answer, and press the button again without throwing the calculation off once the user is ready to do the next problem.
        public bool CheckCorrect { get; set; }

        public bool TopicInitializerIndex { get; set; }
        public int InitializerIndex { get; set; }
    }
}
