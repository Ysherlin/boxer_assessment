using boxer_assessment.Dtos;
using boxer_assessment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace boxer_assessment.Controllers
{
    /// <summary>
    /// API controller for job title lookups.
    /// </summary>
    [ApiController]
    [Route("api/jobtitles")]
    public class JobTitlesController : ControllerBase
    {
        private readonly IJobTitleService _service;

        /// <summary>
        /// Creates a new controller instance.
        /// </summary>
        /// <param name="service">Job title service.</param>
        public JobTitlesController(IJobTitleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all job titles.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<JobTitleReadDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
