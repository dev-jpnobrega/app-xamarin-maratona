using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyHubApp.Views
{

    public class MainDetailPageMenuItem
    {
        public MainDetailPageMenuItem()
        {
            TargetType = typeof(MainDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}