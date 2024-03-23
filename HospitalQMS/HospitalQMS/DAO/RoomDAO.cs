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

        private static RoomDAO? instance = null;
        private static readonly object instanceLock = new object();
        private RoomDAO() { }
        public static RoomDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new RoomDAO();
                }
                return instance;
            }
        }
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
