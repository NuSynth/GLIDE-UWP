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

            Problems.Add(new ProblemModel { ProblemID = 0, ProblemPath = "Assets/male-01.png" });
            Problems.Add(new ProblemModel { ProblemID = 1, ProblemPath = "Assets/male-02.png" });
            Problems.Add(new ProblemModel { ProblemID = 2, ProblemPath = "Assets/male-03.png" });
            Problems.Add(new ProblemModel { ProblemID = 3, ProblemPath = "Assets/female-01.png" });

            return Problems;
        }


        // Not sure if I'll use this yet.
        //public static List<Icon> GetDefault()
        //{
        //    var Problems = new List<ProblemModel>();

        //    Problems.Add(new Problems { ProblemID = "0", IconPath = "Assets/male-01.png" });

        //    return Problems;
        //}
    }
}
