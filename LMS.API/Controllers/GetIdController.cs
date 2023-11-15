using LMS.Core.Service;
using LMS.Data.Data;
using LMS.Infra.Service;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetIdController : ControllerBase
    {
        private readonly IGetIdService _getIdService;

        public GetIdController(IGetIdService getIdService)
        {
            _getIdService = getIdService;
        }

        [Route("Assignments/{id}")]
        public async Task<Assignment> Assignments(int id)
        {
            return await _getIdService.Assignments(id);
        }

        [HttpGet]
        [Route("Attendances")]
        public async Task<Attendance> Attendances(int id)
        {
            return await _getIdService.Attendances(id);
        }

        [HttpGet]
        [Route("Courses")]
        public async Task<Course> Courses(int id)
        {
            return await _getIdService.Courses(id);
        }

        [HttpGet]
        [Route("Enrollments/{id}")]
        public async Task<Enrollment> Enrollments(int id)
        {
            return await _getIdService.Enrollments(id);
        }

        [HttpGet]
        [Route("Periods/{id}")]
        public async Task<Period> Periods(int id)
        {
            return await _getIdService.Periods(id);
        }

        [HttpGet]
        [Route("Plancourses/{id}")]
        public async Task<Plancourse> Plancourses(int id)
        {
            return await _getIdService.Plancourses(id);
        }

        [HttpGet]
        [Route("Plans/{id}")]
        public async Task<Plan> Plans(int id)
        {
            return await _getIdService.Plans(id);
        }

        [HttpGet]
        [Route("Programs/{id}")]
        public async Task<LMS.Data.Data.Program> Programs(int id)
        {
            return await _getIdService.Programs(id);
        }

        [HttpGet]
        [Route("Sections/{id}")]
        public async Task<Section> Sections(int id)
        {
            return await _getIdService.Sections(id);
        }

        [HttpGet]
        [Route("Userassignments/{id}")]
        public async Task<Userassignment> Userassignments(int id)
        {
            return await _getIdService.Userassignments(id);
        }

        [HttpGet]
        [Route("Users/{id}")]
        public async Task<User> Users(int id)
        {
            return await _getIdService.Users(id);
        }

    }
}
