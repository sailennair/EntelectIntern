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

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(appUserService.GetAll());
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

        [HttpPut]
        public IHttpActionResult updateUser(AppUserTable appUser)
        {
            appUserService.Update(appUser);
            return Ok();
        }

        [HttpGet]
        [Route ("{ID}")]
        public IHttpActionResult GetUserByID(int ID)
        {
            AppUserTable item = appUserService.GetByID(ID);
            return Ok(new AppUserDto { username = item.Username, password = item.Password, ID = item.UserID});
        }



    }
}
