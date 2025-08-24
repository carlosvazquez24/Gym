using GymManager.ApplicationServices.Cities;
using GymManager.ApplicationServices.Members;
using GymManager.Core.Members;
using GymManager.DataAccess.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.NETCore;
using Wkhtmltopdf.NetCore;
using Warning = Microsoft.Reporting.NETCore.Warning;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly IGeneratePdf _generatePdf;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMembersAppServices _membersAppServices;

        public ReportsController(IWebHostEnvironment webHostEnvironment, IGeneratePdf generatePdf, IMembersAppServices membersAppServices)
        {
            _generatePdf = generatePdf;
            _webHostEnvironment = webHostEnvironment;
            _membersAppServices = membersAppServices;
        }

        public async Task<IActionResult> Attendance()
        {
            string path = System.IO.Path.Combine(_webHostEnvironment.ContentRootPath, "Reports\\ReportAttendance.rdlc");

            Stream reportDefinition = System.IO.File.OpenRead(path);

            LocalReport report = new LocalReport();
            report.EnableExternalImages = true;
            report.LoadReportDefinition(reportDefinition);

            AttendanceDataSet attendanceDataSet = new AttendanceDataSet();

            //Crear una lista de miembros
            List<Member> members = new List<Member>();

            //Obtener la lista de miembros de la base de datos
            members = await _membersAppServices.getMembersAsync();

            Random random = new Random();

            int indexMember = 0;
            int days = 0;
            int longitud = 0;

            //Desordenar lista de miembros
            List<Member> listaDesordenada = members.OrderBy(_ => random.Next()).ToList();

            //Si la lista de miembros es mayor a 20 se estabelecerá la longitud de 20 y se recortará la lista
            if (members.Count >= 20)
            {
                longitud = 20;
                listaDesordenada = listaDesordenada.GetRange(0, 20);
            }
            else
            {
                longitud = members.Count; //Si la lista de miembros es menor a 20, se queda como está el arreglo
                                          // y solo la longitud cambiará 
            }

            //Listado de miembros
            for (int i = 0; i < longitud; i++)
            {

                //Crear la fila
                AttendanceDataSet.AttendanceRow row = attendanceDataSet.Attendance.NewAttendanceRow();

                //Asignarle el nombre al campo de la fila
                row.Name = listaDesordenada.ToArray()[i].Name + " " + listaDesordenada.ToArray()[i].LastName;

                //Obtener el número aleatorio de dias asistidos por el miembro
                days = random.Next(1, 31);

                //Asignarle los dias a la fila
                row.Days = days;

                //Agregar los miembros a la tabla
                attendanceDataSet.Attendance.Rows.Add(row);
            }
            byte[] streambytes = null;
            string mimetype = "";
            string encoding = "";
            string filenameExtension = "pdf";
            string reportName = "Attendance";
            string[] streamids = null;
            Warning[] warnings = null;

            //Enviar parametros de fecha 
            report.SetParameters(new ReportParameter[] { new ReportParameter("DateFrom", DateTime.Today.AddDays(-30).ToString()),
            new ReportParameter("DateTo", DateTime.Today.ToString())
            });

            report.DataSources.Add(new ReportDataSource("Attendances", (System.Data.DataTable)attendanceDataSet.Attendance));

            streambytes = report.Render("PDF", null, out mimetype, out encoding, out filenameExtension, out streamids, out warnings);

            //Devolver el contenido del archivo PDF
            return File(streambytes, mimetype, $"{reportName}.{filenameExtension}");
        }

        public IActionResult NewMembers()
        {

            string path = System.IO.Path.Combine(_webHostEnvironment.ContentRootPath, "Reports\\NewMembers.rdlc");

            Stream reportDefinition = System.IO.File.OpenRead(path);

            LocalReport report = new LocalReport();
            report.EnableExternalImages = true;
            report.LoadReportDefinition(reportDefinition);

            MembersDataSet dataSet = new MembersDataSet();
            Random random = new Random();
            string[] membershipTypes = new string[] { "Basic", "Family", "Gold" };

            for (int i = 0; i < 28; i++)
            {
                MembersDataSet.MemberRow row = dataSet.Member.NewMemberRow();
                row.Name = $"Member Pérez {i}";
                int day = random.Next(1, 10) * -1;
                int membershipIndex = random.Next(0, 2);
                row.RegisteredOn = DateTime.Today.AddDays(day);

                row.MembershipType = membershipTypes[membershipIndex];
                dataSet.Member.Rows.Add(row);
            }
            byte[] streambytes = null;
            string mimetype = "";
            string encoding = "";
            string filenameExtension = "pdf";
            string reportName = "NewMembers";
            string[] streamids = null;
            Warning[] warnings = null;

            report.SetParameters(new ReportParameter[] { new ReportParameter("DateFrom", DateTime.Today.AddDays(-10).ToString()),
            new ReportParameter("DateTo", DateTime.Today.ToString())
            });

            report.DataSources.Add(new ReportDataSource("Members", (System.Data.DataTable)dataSet.Member));

            streambytes = report.Render("PDF", null, out mimetype, out encoding, out filenameExtension, out streamids, out warnings);

            return File(streambytes, mimetype, $"{reportName}.{filenameExtension}");
        }

    }
}

