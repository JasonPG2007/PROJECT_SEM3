﻿using System;
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
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public bool Visible { get; set; }
        //Person create news
        public DateTime DateSubmitted { get; set; }
        public int AccountID { get; set; }
        public int CategoryID { get; set; }
        [JsonIgnore]
        public virtual Account? Account { get; set; }
        [JsonIgnore]
        public virtual NewsCategory? NewsCategories { get; set; }
    }
}
