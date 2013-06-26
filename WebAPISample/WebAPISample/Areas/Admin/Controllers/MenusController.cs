using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;
using WebAPISample.DTO;
using AutoMapper;
using SpringSupport.NHibernate;

namespace WebAPISample.Areas.Admin.Controllers
{
    public class MenusController : ApiController
    {

        private INHibernateDao<Menu> MenuDao { get; set; }

        // GET api/menus
        public IEnumerable<MenuDTO> Get()
        {
            IEnumerable<Menu> menus = MenuDao.Load(10, 0);
            Mapper.CreateMap<Menu, MenuDTO>();
            IEnumerable<MenuDTO> menuDTOs = Mapper.Map<IEnumerable<MenuDTO>>(menus);
            return menuDTOs;
        }

        // GET api/menus/5
        public MenuDTO Get(long id)
        {
            Menu menu = MenuDao.Get(id);
            Mapper.CreateMap<Menu, MenuDTO>();

            MenuDTO menuDTO = Mapper.Map<MenuDTO>(menu);
            return menuDTO;
        }

        // POST api/menus
        public void Post([FromBody]string value)
        {
        }

        // PUT api/menus/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/menus/5
        public void Delete(int id)
        {
        }
    }
}
