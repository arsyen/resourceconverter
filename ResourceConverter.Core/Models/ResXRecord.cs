using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceConverter.Core.Models
{
    public class ResXRecord
    {
        /// <summary>
        /// Key name of record
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Value of record
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Comment for record
        /// </summary>
        public string Comment { get; set; }
    }
}
