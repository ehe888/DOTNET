using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;
using WebAPISample.DAO;
using AutoMapper;
using WebAPISample.DTO;

namespace WebAPISample.Areas.Operation.Controllers
{
    public class StaffsController : ApiController
    {

        private INHibernateDao<Staff> StaffDao { get; set; }


        // GET api/staffs
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/staffs/5
        public StaffFlattenDTO Get(long id)
        {
            Staff staff = StaffDao.Get(id);

            Mapper.CreateMap<Staff, StaffFlattenDTO>();

            StaffFlattenDTO staffDTO = Mapper.Map<StaffFlattenDTO>(staff);

            return staffDTO;
        }

        // POST api/staffs
        public void Post([FromBody]string value)
        {
        }

        // PUT api/staffs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/staffs/5
        public void Delete(int id)
        {
        }
    }
}
