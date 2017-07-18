using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediaTrackerTest1;
using SimpleInjector;
using MediaTrackerWebAPI.Models.DTO_s;

namespace MediaTrackerWebAPI.Controllers
{
    [RoutePrefix("api/AppUser")]
    public class AppUserController : ApiController
    {

        private readonly IAppUser appUserService;
        public AppUserController(IAppUser appUserService)
        {
            this.appUserService = appUserService;
        }

        [HttpPost]
        public IHttpActionResult addNewUser(AppUserTable appUser)
        {
            appUserService.Create(appUser);
            return Ok();
        }


        [HttpDelete]
        [Route ("{ID}")]
        public IHttpActionResult deleteUser(int ID)
        {
            appUserService.Delete(ID);
            return Ok();
        }



    }
}
