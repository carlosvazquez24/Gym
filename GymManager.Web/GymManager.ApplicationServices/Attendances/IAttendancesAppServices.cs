using GymManager.Core.Attendances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.Attendances
{
    public interface IAttendancesAppServices
    {
        Task<List<Attendance>> getAttendancesAsync();

        Task<int> addAttendanceAsync(Attendance attendance);

        Task deleteAttendanceAsync(int attendanceId);

        Task editAttendanceAsync(Attendance attendance);

        Task<Attendance> getAttendanceAsync(int attendanceId);

    }
}
