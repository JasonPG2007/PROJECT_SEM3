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
    public class News
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewsID { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string Picture { get; set; }
        //Person create news
        public int AccountID { get; set; }
        public DateTime DateSubmitted { get; set; }
        [JsonIgnore]
        public virtual Account? Account { get; set; }
    }
}
