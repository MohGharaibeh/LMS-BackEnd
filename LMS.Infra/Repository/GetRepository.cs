using Dapper;
using LMS.Core.Common;
using LMS.Core.Repository;
using LMS.Data.Data;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace LMS.Infra.Repository;

public class GetRepository : IGetRepository
{
    private readonly IDbContext _context;
    private readonly string connectionString;
    public GetRepository(IDbContext context, IConfiguration configuration)
    {
        _context = context;
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<Assignment>> Assignments()
    {
        using(var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<Assignment> result = _context.Connection.Query<Assignment>
                ("AssignmentPackage.GetAllAssignment", 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Attendance>> Attendances ()
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<Attendance> result = _context.Connection.Query<Attendance>
                ("AttendancePackage.GetAllAttendence", 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Course>> Courses()
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<Course> result = _context.Connection.Query<Course>
                ("CoursePackage.GetAllCourse", 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Enrollment>> Enrollments()
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<Enrollment> result = _context.Connection.Query<Enrollment>
                ("EnrollmentPackage.GetAllEnrollment", 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Period>> Periods()
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<Period> result = _context.Connection.Query<Period>
                ("PeriodPackage.GetAllPeriod", 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Plancourse>> Plancourses()
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<Plancourse> result = _context.Connection.Query<Plancourse>
                ("PlanCoursePackage.GetAllPlanCourse", 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Plan>> Plans()
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<Plan> result = _context.Connection.Query<Plan>
                ("PlanPackage.GetAllPlan", 
                commandType: CommandType.StoredProcedure);

            foreach (var plan in result)
            {
                

                var p = new DynamicParameters();

                p.Add("p_Programid", plan.Programid,
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Input);

                var programs = _context.Connection.Query<Program>
                    ("ProgramPackage.GetProgramByID", p,
                    commandType: CommandType.StoredProcedure);
                plan.Program = programs.FirstOrDefault();

                 p = new DynamicParameters();
                p.Add("p_periodid", plan.Program.Periodid,
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Input);

                var period = _context.Connection.Query<Period>
                    ("PeriodPackage.GetPeriodByID", p,
                    commandType: CommandType.StoredProcedure);
                plan.Program.Period = period.FirstOrDefault();
            }

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Program>> Programs()
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<Program> result = _context.Connection.Query<Program>
                ("ProgramPackage.GetAllProgram", 
                commandType: CommandType.StoredProcedure);

            foreach (var program in result)
            {
                var p = new DynamicParameters();
                p.Add("p_periodid", program.Periodid,
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Input);

                var period = _context.Connection.Query<Period>
                    ("PeriodPackage.GetPeriodByID", p,
                    commandType: CommandType.StoredProcedure);
                program.Period = period.FirstOrDefault();

            }

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Section>> Sections()
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<Section> result = _context.Connection.Query<Section>
                ("SectionPackage.GetAllSection", 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Userassignment>> Userassignments()
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<Userassignment> result = _context.Connection.Query<Userassignment>
                ("UserAssignmentPackage.GetAllUserAssignment", 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<User>> Users()
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            IEnumerable<User> result = _context.Connection.Query<User>
                ("UsersPackage.GetAllUsers", 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Section>> SectionForInstructor(int userId)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_userid", userId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            IEnumerable<Section> result = _context.Connection.Query<Section>
                ("SectionPackage.GetSectionForInstructor", p,
                commandType: CommandType.StoredProcedure);

            foreach (var section in result)
            {
                var x = new DynamicParameters();

                x.Add("p_courseid", section.Courseid,
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Input);

                IEnumerable<Course> course = _context.Connection.Query<Course>
                ("CoursePackage.GetCourseByID", x,
                commandType: CommandType.StoredProcedure);

                section.Course = course.FirstOrDefault();
            }

            connection.Close();

            return result.ToList();
        }
    }
}
