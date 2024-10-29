using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OefeningConfiguration.Models;

namespace OefeningConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("direct-from-appsettings")]
        public ActionResult GetApplicationSettings()
        {
            var appName = _configuration["ApplicationSettings:AppName"];
            var version = _configuration["ApplicationSettings:Version"];
            var maxUsers = _configuration["ApplicationSettings:MaxUsers"];

            return Ok(new { AppName = appName, Version = version, MaxUsers = maxUsers});
        }

        [HttpGet]
        [Route("using-binder")]
        public ActionResult GetApplicationSettingsWithBind()
        {
            var applicationSettings = new ApplicationSettings();
            _configuration.GetSection(ApplicationSettings.SectionName).Bind(applicationSettings);
            //var applicationSettings = _configuration.GetSection(ApplicationSettings.SectionName).Get<ApplicationSettings>();

            return Ok(new { applicationSettings.AppName, applicationSettings.Version, applicationSettings.MaxUsers });
        }
    }
}
