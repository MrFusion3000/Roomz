using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roomz.Data
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }        

        public DateTime AppointmentDateStart { get; set; }

        public DateTime AppointmentDateEnd { get; set; }

        public string AppointmentHeading { get; set; }

        public bool IsConfirmed { get; set; }

        public int BookerId { get; set; }

        [ForeignKey("BookerId")]
        public virtual Booker Booker { get; set; }

        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

        public string BookerEmail { get; internal set; }

        public string RoomName { get; internal set; }

    }
}
