using EagleEye.BusinessLogic.Services;
using EagleEye.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;
        public ProjectsController(ProjectService projectService)
        {
           this._projectService = projectService;
        }

        [HttpGet] //api/Projects
        public ActionResult<IEnumerable<Project>> GetAllProjects()
        {
           var projects =  _projectService.GetAllProjects;
            return Ok(projects);
        }

        [HttpGet("{id}", Name ="GetProjectById")]
        public ActionResult<Project> GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project != null)
            {
                return Ok(project);
            }
            return NotFound();
        }

        [HttpPost] //api/Projects
        public ActionResult<Project> CreateProject(Project project)
        {
            try
            {
                _projectService.CreateProject(project);
                return CreatedAtRoute(nameof(GetProjectById), new { project.Id }, project);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Project> UpdateProject(int id , Project project)
        {
            var projectModel = _projectService.GetProjectById(id);
            if (projectModel != null)
            {
                _projectService.UpdateProject(project);
                return NoContent();
            }
            return NotFound();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProject(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project !=null)
            {
                _projectService.DeleteProject(project);
                return NoContent();
            }
            return NotFound();
        }
    }
}
