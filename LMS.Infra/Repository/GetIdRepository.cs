﻿using Dapper;
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

public class GetIdRepository : IGetIdRepository
{
    private readonly IDbContext _dbContext;
    private readonly string connectionString;

    public GetIdRepository(IDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<Assignment> Assignments(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();
            
            var p = new DynamicParameters();
            p.Add("p_assignmentid", id, dbType:DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Assignment>
                ("AssignmentPackage.GetAssignmentByID", p, 
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }

    public async Task<Attendance> Attendances(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();
            p.Add("p_attendanceid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Attendance>
                ("AttendancePackage.GetAttendanceByID", p,
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
            p.Add("p_courseid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

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
            p.Add("p_enrollmentid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

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
            p.Add("p_periodid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

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
            p.Add("p_PlanCourseid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Plancourse>
                ("PlanCoursePackage.GetPlanCourseByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }

    public async Task<Plan> Plans(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();
            p.Add("p_Planid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<Plan>
                ("PlanPackage.GetPlanByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }

    public async Task<Program> Programs(int id)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            await connection.OpenAsync();

            var p = new DynamicParameters();
            p.Add("p_Programid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

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
            p.Add("p_Sectionid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

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
            p.Add("p_userassignmentid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

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
            p.Add("p_userId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<User>
                ("UsersPackage.GetUsersByID", p,
                commandType: CommandType.StoredProcedure);

            connection.Close();

            return result.FirstOrDefault();
        }
    }
}