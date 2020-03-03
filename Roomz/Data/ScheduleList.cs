using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roomz.Data
{
    public class ScheduleList
    {
        [Key]
        public int Id { get; set; }        

        public DateTime AppointmentDateStart { get; set; }

        public DateTime AppointmentDateEnd { get; set; }

        public string AppointmentHeading { get; set; }

        public bool IsConfirmed { get; set; }

        public int BookerId { get; set; }

        public String BookerEmail { get; set; }

        public int RoomId { get; set; }

        public String RoomName { get; set; }
    }
}
