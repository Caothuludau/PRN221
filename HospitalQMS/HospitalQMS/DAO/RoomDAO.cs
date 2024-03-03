using HospitalQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQMS.DAO
{
    internal class RoomDAO
    {
        public ICollection<Room> GetRoomListOfDepartment(Department de)
        {
            var rooms = new List<Room>();
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                rooms = _context.Rooms
                                .Where(x => x.DepartmentId == de.DepartmentId)
                                .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rooms;
        }

    }
}
