using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class Levels : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LevelID { get; set; }
        public string AccLevels { get; set; }
        public string DisplayLevelName { get; set; }
        public int COAIDStart { get; set; }

        public string COAOwnCodeDigit { get; set; }
        public string COAFullCodeDigit { get; set; }


    }
}
