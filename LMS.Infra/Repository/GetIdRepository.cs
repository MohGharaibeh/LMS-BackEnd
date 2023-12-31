﻿using Dapper;
using LMS.Core.Common;
using LMS.Core.Repository;
using LMS.Data.Data;
using LMS.Data.DTOs;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Collections.Specialized.BitVector32;
using Section = LMS.Data.Data.Section;

namespace LMS.Infra.Repository;

public class GetIdRepository : IGetIdRepository
{
    private readonly IDbContext _dbContext;
    private readonly string connectionString;

    public GetIdRepository(IDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<Assignment>> Assignments(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            
            var p = new DynamicParameters();
            p.Add("p_assignmentid", id, 
                dbType:DbType.Int32, 
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Assignment>
                ("AssignmentPackage.GetAssignmentByID", p, 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }


    public async Task<List<Enrollment>> EnrollmentsBySection(int id)
    {

        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();
            p.Add("p_sectionid", id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Enrollment>
                ("EnrollmentPackage.GetEnrollmentBySectionID", p,
                commandType: CommandType.StoredProcedure);

            foreach (var enrollment in result)
            {
                 p = new DynamicParameters();

                p.Add("p_userId", enrollment.Userid,
                    dbType: DbType.Int32,
                    direction: ParameterDirection.Input);

                var user = _dbContext.Connection.Query<User>
                    ("UsersPackage.GetUsersByID", p,
                    commandType: CommandType.StoredProcedure);
                enrollment.User = user.FirstOrDefault();
            }

            connection.Close();

            return result.ToList();
        }

    }


    public async Task<List<DateTime>> GetDistinctAttendanceDatesForSection(int sectionId)
    {
        using (var connection = new OracleConnection(connectionString))

        {

            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_sectionId", sectionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<DateTime>
                ("AttendancePackage.GetDistinctAttendanceDatesForSection", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }

    }


    public async Task<Attendance> Attendances(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_attendenceid", id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Attendance>
                ("AttendancePackage.GetAttendenceByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }

    public async Task<Course> Courses(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_courseid", id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Course>
                ("CoursePackage.GetCourseByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }

    public async Task<Enrollment> Enrollments(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_enrollmentid", id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Enrollment>
                ("EnrollmentPackage.GetEnrollmentByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }

    public async Task<Period> Periods(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_periodid", id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Period>
                ("PeriodPackage.GetPeriodByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }

    public async Task<Plancourse> Plancourses(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();
            p.Add("p_PlanCourseid", id, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Plancourse>(
                "PlanCoursePackage.GetPlanCourseByID", p, commandType: CommandType.StoredProcedure);

            var plancourse = result.FirstOrDefault();

            if (plancourse != null)
            {
                var sections = await connection.QueryAsync<Section>(
                    "SELECT * FROM Section WHERE Plancourseid = :p_PlanCourseid",
                    p);

                foreach (var section in sections)
                {
                     p = new DynamicParameters();

                    p.Add("p_userId", section.Userid,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input);

                   section.User = _dbContext.Connection.Query<User>
                        ("UsersPackage.GetUsersByID", p,
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                }

                plancourse.Sections = sections.ToList();
            }

            connection.Close();

            return plancourse;
        }
    }

    public async Task<Plan> Plans(int id)
    {
        //using (var connection = new OracleConnection(connectionString))
        //{
        //    await connection.OpenAsync();

        //    var p = new DynamicParameters();

        //    p.Add("p_Planid", id, 
        //        dbType: DbType.Int32, 
        //        direction: ParameterDirection.Input);

        //    var result = _dbContext.Connection.Query<Plan>
        //        ("PlanPackage.GetPlanByID", p,
        //        commandType: CommandType.StoredProcedure);

        //    connection.Close();

        //    return result.FirstOrDefault();
        //}

        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();
            p.Add("p_Planid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var plan = (await connection.QueryAsync<Plan>("PlanPackage.GetPlanByID", p, commandType: CommandType.StoredProcedure)).FirstOrDefault();

            if (plan != null)
            {
                var courses = await connection.QueryAsync<Plancourse>(
                    "SELECT * FROM Plancourse WHERE Planid = :PlanId",
                    new { PlanId = plan.Planid });
                foreach (var course in courses)
                {
                     p = new DynamicParameters();

                    p.Add("p_courseid", course.Courseid,
                        dbType: DbType.Int32,
                        direction: ParameterDirection.Input);

                    var result = _dbContext.Connection.Query<Course>
                        ("CoursePackage.GetCourseByID", p,
                        commandType: CommandType.StoredProcedure);
                    course.Course = result.FirstOrDefault();

                }
                plan.Plancourses = courses.ToList();
            }

            connection.Close();

            return plan;
        }
    }

    public async Task<Program> Programs(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_Programid", id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Program>
                ("ProgramPackage.GetProgramByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }

    public async Task<Section> Sections(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_Sectionid", id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Section>
                ("SectionPackage.GetSectionByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }

    public async Task<Userassignment> Userassignments(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_userassignmentid", id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Userassignment>
                ("UserAssignmentPackage.GetUserAssignmentByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }

    public async Task<User> Users(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();

            p.Add("p_userId", id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<User>
                ("UsersPackage.GetUsersByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }


    public async Task<List<StudentAssingmentsDTO>> GetUserGrades(int SectionId, int UserId)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();
            p.Add("p_sectionid", SectionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            
            p.Add("p_userid", UserId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<StudentAssingmentsDTO>
                ("UserAssignmentPackage.GetUserGetUserGradesForSection", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.ToList();
        }
    }

    public async Task <IEnumerable<StudentAssingmentsDTO>>GetUserAssignmentsBySectionId(int sectionId, int userId)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();
            p.Add("p_sectionid", sectionId, DbType.Int32, ParameterDirection.Input);
            p.Add("p_userid", userId, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<StudentAssingmentsDTO>(
                "UserAssignmentPackage.GetUserAssignmentsBySectionId",
                p,
                commandType: CommandType.StoredProcedure
            );

            connection.Close();

            return result;
        }
    }

    public async Task<IEnumerable<StudentAssingmentsDTO>> GetUserAssignmentsByAssignmentId(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();
            p.Add("p_assignmentid", id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<StudentAssingmentsDTO>
                ("UserAssignmentPackage.GetUserAssignmentsByAssignmentId", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result;
        }

    }
}
