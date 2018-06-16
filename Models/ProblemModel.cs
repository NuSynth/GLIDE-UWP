using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableImageTest.Models
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

            // The two problems are commented out to test that answers match with problems.
            Problems.Add(new ProblemModel { ProblemID = 0, TopicID = 0, ProblemPath = "Assets/male-01.png" });
            Problems.Add(new ProblemModel { ProblemID = 1, TopicID = 0, ProblemPath = "Assets/male-02.png" });
            Problems.Add(new ProblemModel { ProblemID = 2, TopicID = 1, ProblemPath = "Assets/male-03.png" });
            Problems.Add(new ProblemModel { ProblemID = 3, TopicID = 2, ProblemPath = "Assets/female-01.png" });

            return Problems;
        }
    }
}
