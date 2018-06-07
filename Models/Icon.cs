using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableImageTest.Models
{
    public class Icon
    {
        public string IconPath { get; set; }
        public string IconID { get; set; }
    }

    public class IconManager
    {
        public static List<Icon> GetIcons()
        {
            var Icons = new List<Icon>();

            Icons.Add(new Icon { IconID = "0", IconPath = "Assets/male-01.png" });
            Icons.Add(new Icon { IconID = "1", IconPath = "Assets/male-02.png" });
            Icons.Add(new Icon { IconID = "2", IconPath = "Assets/male-03.png" });
            Icons.Add(new Icon { IconID = "3", IconPath = "Assets/female-01.png" });
            Icons.Add(new Icon { IconID = "4", IconPath = "Assets/female-02.png" });
            Icons.Add(new Icon { IconID = "5", IconPath = "Assets/female-03.png" });

            return Icons;
        }

        public static List<Icon> GetDefault()
        {
            var Icons = new List<Icon>();

            Icons.Add(new Icon { IconID = "0", IconPath = "Assets/male-01.png" });

            return Icons;
        }
    }
}
