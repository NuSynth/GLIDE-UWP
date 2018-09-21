using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Program Title: Glide
// Class File: AnswerModel.cs
// Author: Herbert Smith


/* If a Topic ID in the TopicModel class file exists, then the 3 answers for that Topic ID needs to exist here, or the program will crash when it reaches that topic. */

namespace Glide.Models
{
    public class AnswerModel
    {
        public int AnswerID { get; set; }
        public int ProblemID { get; set; }
        public bool AnswerCorrect { get; set; }                
        public string IdString { get; set; }
        public string DisplayLetter { get; set; }
        public string AnswerPath { get; set; }
    }

    public class AnswerManager
    {
        public static List<AnswerModel> GetAll()
        {
            /* I am using the Problem images here because I need to test functionality, and I havent made any Answer images to test with.
             * Just copy and paste the image paths from here into the problem section when it comes time to test that section.
             */
            var answers = new List<AnswerModel>();
            answers.Add(new AnswerModel { AnswerID = 0, ProblemID = 0, AnswerCorrect = true, IdString = "0", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Division/0.png" });            
            answers.Add(new AnswerModel { AnswerID = 4, ProblemID = 1, AnswerCorrect = false, IdString = "4", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Division/4.png" });
            answers.Add(new AnswerModel { AnswerID = 8, ProblemID = 2, AnswerCorrect = false, IdString = "8", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/DivNegExp/3.png" });
            answers.Add(new AnswerModel { AnswerID = 11, ProblemID = 3, AnswerCorrect = false, IdString = "11", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Sets/2.png" });

            return answers;
        }

        public static List<AnswerModel> GetDefault()
        {
            var answers = new List<AnswerModel>();
            answers.Add(new AnswerModel { AnswerID = 0, ProblemID = 0, AnswerCorrect = true, IdString = "blank0", DisplayLetter = "n", AnswerPath = "Assets/1.png" });
            return answers;
        }
    }
}
