namespace Lab32_Gym_Database_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exercises")]
    public partial class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        [StringLength(50)]
        public string ExerciseName { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
