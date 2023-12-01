using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectBussiness
{
    public class Exam
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Exam ID")]
        public int ExamID { get; set; }
        public DateTime DateCreateTest { get; set; }
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime? TimeDelay { get; set; }
        public string Status { get; set; } // Start or End
        [JsonIgnore]
        public virtual ICollection<ResultCandidate>? ResultCandidate { get; set; }
        [JsonIgnore]
        public virtual ICollection<Round>? Round { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account>? Account { get; set; }
        [JsonIgnore]
        public virtual ICollection<Question>? Question { get; set; }
    }
}
