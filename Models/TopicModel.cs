using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This class file is used to save TO the database, and restore FROM the database.

// Observable image test is not the actual namespace. I just left it there in some files
// from a test application for the observable objects that implemented images. It worked,
// and I have been growing the application from that final thing that I had to figure out
// how to do, in order for everything to work.
namespace ObservableImageTest.Models
{
    public class TopicModel
    {
        [PrimaryKey]
        public int Top_ID { get; set; }
        public int Course_ID { get; set; }
        public string Top_Name { get; set; } // This is only used to make things easier for building a course. Not implemented in program itself at the moment.
        public bool Top_Studied { get; set; }
        public string Next_Date { get; set; }
        
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

    public class TopicManager
    {
        // The database needs some initial topic data to save into it, so that is what this is for.
        /* topic data initial values */
        public static List<TopicModel> GetTopics()
        {
            var Topics = new List<TopicModel>();            

            Topics.Add(new TopicModel 
            { 
                Top_ID = 0000,
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
                Top_ID = 0001,
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
                Top_ID = 0002,
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

    
}
