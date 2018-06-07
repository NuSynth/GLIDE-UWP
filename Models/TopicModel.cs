using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Attributes;
using System.Text;
using System.Threading.Tasks;

namespace ObservableImageTest.Models
{
    class TopicModel
    {
            [PrimaryKey]
            public int Top_ID { get; set; }
            public string Top_Name { get; set; }
            public bool Top_Studied { get; set; }

            public string First_Date { get; set; }

            public string Study_Date { get; set; }
            public double Num_Problems { get; set; }
            public double Num_Correct { get; set; }

            public double Top_Difficulty { get; set; }
            public double Top_Repetition { get; set; }
            public double Interval_Remaining { get; set; }

            public double Interval_Length { get; set; }
            public double Engram_Stability { get; set; }
            public double Engram_Retrievability { get; set; }

            public int Course_ID { get; set; }

      
    }
}
