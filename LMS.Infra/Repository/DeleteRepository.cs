using Dapper;
using LMS.Core.Common;
using LMS.Core.Repository;
using LMS.Data.Data;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infra.Repository;

public class DeleteRepository : IDeleteRepository
{
    private readonly IDbContext _context;
    private readonly string connectionString;
    public DeleteRepository(IDbContext context, IConfiguration configuration)
    {
        _context = context;
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<int> Assignments(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_assignmentid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("AssignmentPackage.DeleteAssignment",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }

    public async Task<int> Attendances(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_attendenceid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("AttendancePackage.DeleteAttendence",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }


    public async Task<int> Courses(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_courseid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("CoursePackage.DeleteCourse",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }

    public async Task<int> Enrollments(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_enrollmentid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("EnrollmentPackage.DeleteEnrollment",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }

    public async Task<int> Periods(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_periodid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("PeriodPackage.DeletePeriod",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }

    public async Task<int> Plancourses(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_PlanCourseid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("PlanCoursePackage.DeletePlanCourse",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }

    public async Task<int> Plans(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_planid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("PlanPackage.DeletePlan",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }

    public async Task<int> Programs(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_programid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("ProgramPackage.DeleteProgram",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }

    public async Task<int> Sections(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_sectionid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("SectionPackage.DeleteSection",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }

    public async Task<int> Userassignments(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_userassignmentid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("UserAssignmentPackage.DeleteUserAssignment",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }

    public async Task<int> Users(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            var p = new DynamicParameters();
            p.Add("p_userassignmentid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("UsersPackage.DeleteUsers",
                p, commandType: CommandType.StoredProcedure);
            connection.Close();
            return result;
        }
    }
}
