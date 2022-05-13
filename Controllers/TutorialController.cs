using BAL_Tutorial.Services;
using DAL_Tutorial.Interface;
using DAL_Tutorial.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Tutorials.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : Controller
    {
        private readonly TutorialService _tutorialService;
        private readonly IRepository<Tutorial> _person;

        public TutorialController(TutorialService tutorialService, IRepository<Tutorial> person)
        {
            _tutorialService = tutorialService;
            _person = person;
        }

        [HttpPost]
        public async Task<bool> AddTutorial(Tutorial tutorial)
        {
            try
            {
                await _tutorialService.AddTutorial(tutorial);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        [HttpDelete("DeleteTutorial")]
        public bool DeleteTutorial(int id)
        {
            try
            {
                return _tutorialService.DeleteTutorial(id);

            }
            catch (Exception)
            {

                return false;
            }

        }
        [HttpPut]
        public object UpdateTutorial(int id, Tutorial tutorial)
        {
            try
            {
                _tutorialService.UpdateTutorial(tutorial);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        // Get all tutorials
        [HttpGet("GetTutorials")]
        public object GetTutorials()
        {
            var data = _tutorialService.GetAllTutorials();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
            });
            return json;
        }

        // Get all tutorials
        [HttpGet]
        public object GetTutorialsById(int id)
        {
            return _tutorialService.GetByTitle(id);
        }

        [HttpGet("GetTutorialsByTitle")]
        public Tutorial GetTutorial(string title)
        {
            return _tutorialService.GetByTitle(title);

        }

    }
}
