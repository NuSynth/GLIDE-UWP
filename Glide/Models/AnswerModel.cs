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
            var answers = new List<AnswerModel>();

            /* I am using the Problem images here because I need to test functionality, and I havent made any Answer images to test with.
             *
             * Just copy and paste the image paths from here into the problem section when it comes time to test that section.
             * 
             * 
             * When I use actual answer images, group the images into sections of 3 answer choices, similar to how I grouped these problem images
             * into sections that apply to specific topics.
             */
            // Division
            answers.Add(new AnswerModel { AnswerID = 0, ProblemID = 0, AnswerCorrect = true, IdString = "0", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Division/0.png" });
            answers.Add(new AnswerModel { AnswerID = 1, ProblemID = 0, AnswerCorrect = false, IdString = "1", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Division/1.png" });
            answers.Add(new AnswerModel { AnswerID = 2, ProblemID = 0, AnswerCorrect = false, IdString = "2", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Division/2.png" });
            answers.Add(new AnswerModel { AnswerID = 3, ProblemID = 1, AnswerCorrect = true, IdString = "3", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Division/3.png" });
            answers.Add(new AnswerModel { AnswerID = 4, ProblemID = 1, AnswerCorrect = false, IdString = "4", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Division/4.png" });

            // Division with Negative Exponents
            answers.Add(new AnswerModel { AnswerID = 5, ProblemID = 1, AnswerCorrect = false, IdString = "5", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/DivNegExp/0.png" });
            answers.Add(new AnswerModel { AnswerID = 6, ProblemID = 2, AnswerCorrect = true, IdString = "6", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/DivNegExp/1.png" });
            answers.Add(new AnswerModel { AnswerID = 7, ProblemID = 2, AnswerCorrect = false, IdString = "7", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/DivNegExp/2.png" });
            answers.Add(new AnswerModel { AnswerID = 8, ProblemID = 2, AnswerCorrect = false, IdString = "8", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/DivNegExp/3.png" });

            // Sets
            answers.Add(new AnswerModel { AnswerID = 9, ProblemID = 3, AnswerCorrect = true, IdString = "9", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Sets/0.png" });
            answers.Add(new AnswerModel { AnswerID = 10, ProblemID = 3, AnswerCorrect = false, IdString = "10", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Sets/1.png" });
            answers.Add(new AnswerModel { AnswerID = 11, ProblemID = 3, AnswerCorrect = false, IdString = "11", DisplayLetter = "n", AnswerPath = "Assets/ProblemImages/Sets/2.png" });

            return answers;
        }

        public static List<AnswerModel> GetDefault()
        {
            var answers = new List<AnswerModel>();

            answers.Add(new AnswerModel { AnswerID = 0, ProblemID = 0, AnswerCorrect = true, IdString = "blank0", DisplayLetter = "n", AnswerPath = "Assets/1.png" });
            answers.Add(new AnswerModel { AnswerID = 1, ProblemID = 0, AnswerCorrect = true, IdString = "blank1", DisplayLetter = "n", AnswerPath = "Assets/2.png" });
            answers.Add(new AnswerModel { AnswerID = 2, ProblemID = 0, AnswerCorrect = true, IdString = "blank2", DisplayLetter = "n", AnswerPath = "Assets/3.png" });


            return answers;
        }
    }
}
