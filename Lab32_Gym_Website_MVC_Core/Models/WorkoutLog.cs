using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab32_Gym_Website_MVC_Core
{
    public class WorkoutLog
    {
        public int WorkoutLogId { get; set; }
        public DateTime WorkoutDate { get; set; }
        public int ExerciseId { get; set; }
    }
}
