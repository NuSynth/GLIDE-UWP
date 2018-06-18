using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glide.Models
{
    public class ProblemModel
    {
        // public int ProblemID { get; set; }
        public int TopicID { get; set; }
        public int ProblemID { get; set; }
        public string ProblemPath { get; set; }

        // This will be for problems (or questions) that only need characters available on the keyboard.
        public string QuestionText { get; set; }
    }

    public class ProblemManager
    {
        public static List<ProblemModel> GetProblems()
        {
            var Problems = new List<ProblemModel>();

            Problems.Add(new ProblemModel { ProblemID = 0, TopicID = 0, ProblemPath = "Assets/ProblemImages/Sets/0.png" });
            Problems.Add(new ProblemModel { ProblemID = 1, TopicID = 0, ProblemPath = "Assets/ProblemImages/Sets/1.png" });
            Problems.Add(new ProblemModel { ProblemID = 2, TopicID = 1, ProblemPath = "Assets/ProblemImages/Sets/0.png" });

            return Problems;
        }
    }
}
