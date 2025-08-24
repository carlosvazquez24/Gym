using GymManager.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymManager.Core.Attendances;

namespace GymManager.ApplicationServices.Attendances
{
    public class AttendancesAppServices : IAttendancesAppServices
    {

        private readonly IRepository<int, Attendance> _repository;

        public AttendancesAppServices(IRepository<int, Attendance> repository)
        {

            _repository = repository;

        }


        public async Task<int> addAttendanceAsync(Attendance attendance)
        {
            await _repository.AddAsync(attendance);
            return attendance.Id;
        }

        public async Task deleteAttendanceAsync(int attendanceId)
        {
            await _repository.DeleteAsync(attendanceId);
        }

        public async Task editAttendanceAsync(Attendance attendance)
        {
            await _repository.UpdateAsync(attendance);

        }

        public async Task<Attendance> getAttendanceAsync(int attendanceId)
        {
            return await _repository.GetAsync(attendanceId);
        }

        public async Task<List<Attendance>> getAttendancesAsync()
        {

            return await _repository.GetAllAsync().ToListAsync();
        }
    }
}
