using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Models
{
    class DagEnMaand
    {
        [Range(1, 31, ErrorMessage = "Dag moet tussen 1 en 31 liggen.")]
        public int Dag { get; set; }
        [Range(1, 12, ErrorMessage = "Maand moet tussen 1 en 12 liggen.")]
        public int Maand { get; set; }
    }
}
