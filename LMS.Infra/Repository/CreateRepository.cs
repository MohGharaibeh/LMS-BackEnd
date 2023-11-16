using Dapper;
using LMS.Core.Common;
using LMS.Core.Repository;
using LMS.Data.Data;
using LMS.Infra.Common;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace LMS.Infra.Repository;

public class CreateRepository : ICreateRepository
{
    private readonly string connectionString;
    private readonly IDbContext _dbContext;

    public CreateRepository(IConfiguration configuration, IDbContext dbContext)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
        _dbContext = dbContext;
    }

    public async Task Assignments(Assignment assignment)
    {
        using(var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_name", assignment.Name, 
                dbType: DbType.String, 
                direction: ParameterDirection.Input);

            p.Add("p_content", assignment.Content, 
                dbType: DbType.String, 
                direction: ParameterDirection.Input);

            p.Add("p_Deadline", assignment.Deadline, 
                dbType: DbType.DateTime, 
                direction: ParameterDirection.Input);

            p.Add("p_grade", assignment.Grade, 
                dbType: DbType.Decimal, 
                direction: ParameterDirection.Input);

            p.Add("p_sectionid", assignment.Sectionid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("AssignmentPackage.createAssignment", 
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task Attendances(Attendance attendance)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_attendancedate", attendance.Attendancedate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            p.Add("p_absente", attendance.Absente,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_sectionid", attendance.Sectionid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            p.Add("p_userid", attendance.Userid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("AttendancePackage.createAttendence",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task Courses(Course course)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_name", course.Name,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_imagepath", course.Imagepath,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CoursePackage.createCourse",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task Enrollments(Enrollment enrollment)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_ispassed", enrollment.Ispassed,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_totalmark", enrollment.Totalmark,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            p.Add("p_sectionid", enrollment.Sectionid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            p.Add("p_userid", enrollment.Userid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("EnrollmentPackage.createEnrollment",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task Periods(Period period)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_name", period.Name,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_startdate", period.Startdate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            p.Add("p_enddate", period.Enddate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("PeriodPackage.createPeriod",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task Plans(Plan plan)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_description", plan.Description,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_programid", plan.Programid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("PlanPackage.createPlan",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task Plancourses(Plancourse plancourse)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_ordernumber", plancourse.Ordernumber,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            p.Add("p_prerequest", plancourse.Prerequest,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_enddate", plancourse.Enddate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            p.Add("p_startdate", plancourse.Startdate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            p.Add("p_planid", plancourse.Planid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            p.Add("p_courseid", plancourse.Courseid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("PlanCoursePackage.createPlanCourse",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task Programs(Program program)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_name", program.Name,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_description", program.Description,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_periodid", program.Periodid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("ProgramPackage.createProgram",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task Sections(LMS.Data.Data.Section section)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_name", section.Name,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_time", section.Time,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            p.Add("p_courseid", section.Courseid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            p.Add("p_userid", section.Userid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("SectionPackage.createSection",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task Userassignments(Userassignment userassignment)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_mark", userassignment.Mark,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            p.Add("p_submitcontent", userassignment.Submitcontent,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_assignmentid", userassignment.Assignmentid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            p.Add("p_userid", userassignment.Userid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("UserAssignmentPackage.createUserAssignment",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task Users(User user)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_fullname", user.Fullname,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_email", user.Email,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_password", user.Password,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_phonenumber", user.Phonenumber,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_image", user.Imagepath,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_gender", user.Gender,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_roleID", user.Roleid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            p.Add("p_PlanId", user.Planid,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("UsersPackage.createUsers",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();
        }
    }

    public async Task<User> LoginUsers(User user)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_email", user.Email,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            p.Add("p_password", user.Password,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<User>("UsersPackage.LoginUser",
                p, commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.SingleOrDefault();
        }
    }
}
