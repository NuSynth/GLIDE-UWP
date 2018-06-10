using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableImageTest.Models
{
    public class LessonModel
    {
        public int CourseID { get; set; }
        // The lesson ID is the same as the topic ID, since there is one lesson per-topic.
        public int LessonID { get; set; }
        public string LessonPath { get; set; }
    }

    public class LessonManager
    {

        public static List<LessonModel> GetLessons()
        {
            var Lessons = new List<LessonModel>();

            // The two problems are commented out to test that answers match with problems.

            Lessons.Add(new LessonModel { CourseID = 0, LessonID = 0, LessonPath = "Assets/male-01.png" });
            Lessons.Add(new LessonModel { CourseID = 0, LessonID = 1, LessonPath = "Assets/male-01.png" });
            Lessons.Add(new LessonModel { CourseID = 0, LessonID = 2, LessonPath = "Assets/female-01.png" });

            return Lessons;
        }
    }
}
