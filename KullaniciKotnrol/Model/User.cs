using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KullaniciKotnrol.Model
{
   public class User
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public  string SurName { get; set; }
        public int Age { get; set; }
        public DateTime FirstEntry { get; set; }
        public DateTime LastEntry { get; set; }
        public bool IsAcvtive { get; set; }
    }
}
