using GymManager.Core.Members;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Core.Attendances
{
    public class Attendance
    {
        public int Id { get; set; }


        public DateTime Date { get; set; }

        public Member Member { get; set; }


        public string MovementType { get; set; }

    }
}
