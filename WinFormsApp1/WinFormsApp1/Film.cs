using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rejisser { get; set; }
        public int Year { get; set; }

        public Genre Filmgenre {  get; set; }
    }
}
