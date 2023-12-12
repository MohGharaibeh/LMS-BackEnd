using Dapper;
using LMS.Core.Common;
using LMS.Core.Repository;
using LMS.Data.Data;
using LMS.Data.DTOs;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using static System.Collections.Specialized.BitVector32;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Section = LMS.Data.Data.Section;

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
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            
            IEnumerable<Assignment> result = _context.Connection.Query<Assignment>
                ("AssignmentPackage.GetAllAssignment",
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task<List<Attendance>> Attendances()
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

    public async Task<List<SectionForInstructor>> SectionForInstructor(int userId)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_userid", userId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            IEnumerable<SectionForInstructor> result = _context.Connection
                .Query<SectionForInstructor>
                ("SectionPackage.GetSectionForInstructor", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }


    public async Task<User> SectionForTrainee(int traineeId)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();
            p.Add("p_userId", traineeId, DbType.Int32, ParameterDirection.Input);

            var result = await connection.QueryAsync<User>(
                "UsersPackage.GetUsersByID",
                p,
                commandType: CommandType.StoredProcedure
            );

            var user = result.FirstOrDefault();

            if (user != null && user.Roleid == 3)
            {
                var enrollments = await connection.QueryAsync<Enrollment, Section, Plancourse, Plan, Course, User, Enrollment>(
                    @"SELECT e.*, s.*, pc.*, p.*, c.*, u.*
                FROM Enrollment e
                INNER JOIN Section s ON e.SectionId = s.SectionId
                INNER JOIN PlanCourse pc ON s.PlanCourseId = pc.PlanCourseId
                INNER JOIN Plan p ON pc.PlanId = p.PlanId
                INNER JOIN Course c ON pc.CourseId = c.CourseId
                INNER JOIN Users u ON s.UserId = u.UserId
                WHERE e.UserId = :userId",
                    (enrollment, section, plancourse, plan, course, user) =>
                    {
                        enrollment.Section = section;
                        section.Plancourse = plancourse;
                        plancourse.Plan = plan;
                        plancourse.Course = course;
                        section.User = user;

                        return enrollment;
                    },
                    new { userId = traineeId },
                    splitOn: "SectionId,PlanCourseId,PlanId,CourseId,UserId"
                );

                user.Enrollments = enrollments.ToList();
                if (user.Enrollments.Count == 0)
                {
                    await RegisterUserInFirstSection(user);
                    // Refresh user data after new enrollment
                    user = await SectionForTrainee(traineeId);
                }
                else if (user.Enrollments.Count >0)
                {
                   decimal CurrentSectionId = await GetCurrentSectionId(user);

                    if (await RegisterUserInNextSection(user, CurrentSectionId))
                    {
                        user = await SectionForTrainee(traineeId);
                    }

                }

            }

            connection.Close();

            return user;
        }
    }

    public async Task<bool> RegisterUserInFirstSection(User user)
    {
        try
        {
            using (var connection = new OracleConnection(connectionString))
            {
                await connection.OpenAsync();

                var p = new DynamicParameters();
                string isPassed = "false";
                p.Add("p_ispassed", isPassed, DbType.String, ParameterDirection.Input);
                decimal mark = 0;
                p.Add("p_totalmark", mark, DbType.Decimal, ParameterDirection.Input);

                decimal sectionId = await GetFirstSection(user);

                p.Add("p_sectionid", sectionId, DbType.Decimal, ParameterDirection.Input);
                p.Add("p_userid", user.Userid, DbType.Decimal, ParameterDirection.Input);

                var result = await _context.Connection.ExecuteAsync(
                    "EnrollmentPackage.createEnrollment",
                    p,
                    commandType: CommandType.StoredProcedure
                );

                connection.Close();
                return true; // If the execution completes without errors
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception here
            Console.WriteLine($"Error: {ex.Message}");
            return false; // Return false indicating an error occurred
        }
    }


    public async Task<bool>CheckUserPassed(User user, decimal CurrentSectionId)
    {
        try {

            var CurrentEnrollmentId = await _context.Connection.QueryFirstOrDefaultAsync<int>(
                              @"select max(enrollmentid) from enrollment 
                              WHERE userid = :userId",
                              new { userId = user.Userid }
                          );
            var attendanceCount = await _context.Connection.QueryFirstOrDefaultAsync<int>(
                              @"SELECT COUNT(ABSENTE)
                              FROM attendance
                              WHERE userid = :userId
                              AND enrollmentid = :enrollmentId
                              AND absente = 'true'",
                              new { userId = user.Userid, enrollmentId = CurrentEnrollmentId }
                          );

            var totalMark = await _context.Connection.QueryFirstOrDefaultAsync<decimal>(
                            @"SELECT totalmark 
                              FROM enrollment
                              WHERE UserId = :userId
                              AND sectionid = :sectionId",
                            new { userId = user.Userid, sectionId = CurrentSectionId }
                        );

            bool passed = totalMark >= 80 && attendanceCount <= 2;
            return passed;


        }
        catch {
        
         return false;

        }
    }

    public async Task<bool> RegisterUserInNextSection(User user,decimal CurrentSectionId)
    {
        if (await CheckUserPassed( user,  CurrentSectionId))
        {
            try
            {
                using (var connection = new OracleConnection(connectionString))
                {
                    await connection.OpenAsync();




                    var p = new DynamicParameters();
                    string isPassed = "false";
                    p.Add("p_ispassed", isPassed, DbType.String, ParameterDirection.Input);
                    decimal mark = 0;
                    p.Add("p_totalmark", mark, DbType.Decimal, ParameterDirection.Input);

                    decimal sectionId = await GetNextSection(user, CurrentSectionId);

                    if (sectionId > 0)
                    {
                        p.Add("p_sectionid", sectionId, DbType.Decimal, ParameterDirection.Input);
                    }
                    else
                        return false;
                    p.Add("p_userid", user.Userid, DbType.Decimal, ParameterDirection.Input);

                    var result = await _context.Connection.ExecuteAsync(
                        "EnrollmentPackage.createEnrollment",
                        p,
                        commandType: CommandType.StoredProcedure
                    );

                    connection.Close();
                    return true; // If the execution completes without errors
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception here
                Console.WriteLine($"Error: {ex.Message}");
                return false; // Return false indicating an error occurred
            }
        }
        else
        {
            return false;
        }
    }

    public async Task<int> GetFirstSection(User user)
    {
        int firstSectionId = 0;

        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

                        var sectionIds = await connection.QueryAsync<int>(
                            @"SELECT s.sectionid
                        FROM Users u
                        INNER JOIN Plan p ON u.PlanId = p.PlanId
                        INNER JOIN PlanCourse pc ON p.PlanId = pc.PlanId
                        INNER JOIN Section s ON s.PlancourseId = pc.PlancourseId
                        WHERE u.UserId = :userId
                        AND pc.ordernumber = 1",
                            new { userId = user.Userid }
                        );

            if (sectionIds.Any())
            {
                firstSectionId = sectionIds.First();
            }
        }

        return firstSectionId;
    }
        public async Task<int> GetNextSection(User user , decimal CurrentSectionId)
    {
        var NextSectionId = CurrentSectionId;
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
                        var ordernumber = await connection.QueryAsync<int>(
                            @"select ordernumber from plancourse inner join
                                section on plancourse.plancourseid =section.plancourseid
                                where section.sectionid = :sectionId and planid =  :planId",
                            new { sectionId = CurrentSectionId, planId =user.Planid }
                        );

                                var lastCourse = await connection.QueryFirstOrDefaultAsync<int>(
                                @"SELECT MAX(pc.ordernumber) AS max_ordernumber
                          FROM plancourse pc
                          WHERE pc.planid = :planId ",
                                new {  planId = user.Planid }
                            );

            if (ordernumber.FirstOrDefault() != lastCourse) {
                var sectionIds = await connection.QueryAsync<int>(
                                @"SELECT s.sectionid
                        FROM Users u
                        INNER JOIN Plan p ON u.PlanId = p.PlanId
                        INNER JOIN PlanCourse pc ON p.PlanId = pc.PlanId
                        INNER JOIN Section s ON s.PlancourseId = pc.PlancourseId
                        WHERE u.UserId = :userId
                        AND pc.ordernumber = :orderNumber + 1",
                                new { userId = user.Userid, orderNumber = ordernumber }
                            );

                if (sectionIds.Any())
                {
                    NextSectionId = sectionIds.First();
                }
            }
            else return 0;
        }

        return (int) NextSectionId;
    }


    public async Task<int> GetCurrentSectionId(User user)
    {
        int CurrentSectionId = 0;

        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var sectionIds = await connection.QueryAsync<int>(
       @"SELECT sectionid 
      FROM (
        SELECT sectionid 
        FROM enrollment 
        WHERE UserId = :userId
        ORDER BY ENROLLMENTID DESC
      ) 
      WHERE ROWNUM = 1",
       new { userId = user.Userid }
   );


            if (sectionIds.Any())
            {
                CurrentSectionId = sectionIds.First();
            }
        }

        return CurrentSectionId;
    }

}

