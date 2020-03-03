using Roomz.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Roomz.Services
{
    public class TableChangeBroadcastService : ITableChangeBroadcastService
    {
        private const string TableName = "Schedules";

        private readonly SqlTableDependency<Schedule> _notifier;
        private readonly IConfiguration _configuration;

        public event ScheduleChangeDelegate OnScheduleChanged;

        public TableChangeBroadcastService(IConfiguration configuration)
        {
            _configuration = configuration;

            // SqlTableDependency will trigger an event for any record change on monitored table  
            _notifier = new SqlTableDependency<Schedule>(_configuration["DefaultConnection"], TableName);
            _notifier.OnChanged += this.TableDependency_Changed;
            _notifier.Start();
        }

        /// <summary>
        /// This method will notify the Blazor component about the schedule change 
        /// </summary>
        private void TableDependency_Changed(object sender, RecordChangedEventArgs<Schedule> e)
        {
            this.OnScheduleChanged(this, new ScheduleChangeEventArgs(e.Entity, e.EntityOldValues));
        }

        /// <summary>
        /// This method is used to populate the HTML view when it is rendered for the firt time
        /// </summary>        
        public IList<Schedule> GetCurrentValues()
        {
            List<Schedule> result = new List<Schedule>();

            using (var sqlConnection = new SqlConnection(_configuration["DefaultConnection"]))
            {
                sqlConnection.Open();

                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "SELECT Schedules.AppointmentHeading, Schedules.AppointmentDateStart, Schedules.AppointmentDateEnd, Bookers.Id AS Expr2, Bookers.Email, Rooms.Id AS Expr3, Rooms.Name " +
                        "FROM Schedules " +
                        "INNER JOIN Rooms ON Schedules.RoomId = Rooms.Id " +
                        "INNER JOIN Bookers ON Schedules.BookerId = Bookers.Id " +
                        "ORDER BY AppointmentDateStart" ;

                    command.CommandType = CommandType.Text;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                result.Add(new Schedule
                                {
                                    AppointmentHeading = reader.GetString(reader.GetOrdinal("AppointmentHeading")),
                                    AppointmentDateStart = reader.GetDateTime(reader.GetOrdinal("AppointmentDateStart")),
                                    AppointmentDateEnd = reader.GetDateTime(reader.GetOrdinal("AppointmentDateEnd")),
                                    BookerId = reader.GetInt32(reader.GetOrdinal("Expr2")),
                                    BookerEmail = reader.GetString(reader.GetOrdinal("Email")),
                                    RoomId = reader.GetInt32(reader.GetOrdinal("Expr3")),
                                    RoomName = reader.GetString(reader.GetOrdinal("Name"))
                                });
                            }
                        }

                    }
                }
            }
            
            return result;
        }

        public void Dispose()
        {
            _notifier.Stop();
            _notifier.Dispose();
        }
    }
}