using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomz.Services
{
    public class NotifierService
    {
        public async Task UpdateHeader(int id, string name)
        {
            if (Notify != null)
            {
                await Notify.Invoke(id, name);
            }
        }

        public event Func<int, string, Task> Notify;

        //room = Service.GetRoom(RoomId);
        //thisRoomId = room.Id;
        //thisRoomName = room.Name;
    }
}
