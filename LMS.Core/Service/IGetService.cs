﻿using LMS.Data.Data;
using LMS.Data.DTOs;

namespace LMS.Core.Service;

public interface IGetService
{
    Task<List<Assignment>> Assignments();
    Task<List<Attendance>> Attendances();
    Task<List<Course>> Courses();
    Task<List<Enrollment>> Enrollments();
    Task<List<Period>> Periods();
    Task<List<Plancourse>> Plancourses();
    Task<List<Plan>> Plans();
    Task<List<Program>> Programs();
    Task<List<Section>> Sections();
    Task<List<Userassignment>> Userassignments();

    Task<List<User>> Users();
    Task<List<SectionForInstructor>> SectionForInstructor(int userId);
    Task<User> SectionForTrainee(int traineeId);
}
