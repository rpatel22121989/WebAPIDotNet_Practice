using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Linq;
using WebAPI_Practice.Filters;
using WebAPI_Practice.Models;

namespace WebAPI_Practice.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [CustomActionFilter]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "Your Id is:: " + id;
        }

        // GET api/values/5/abcd
        // throws bad request error for the below api method: 400, Message: The request is invalid.
        // MessageDetail: The parameters dictionary contains a null entry for parameter 'userName' of non-nullable type 'System.Int32' for method 'System.String Get(Int32, System.String)' in 'WebAPI_Practice.Controllers.ValuesController'. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.
        // public string Get(int userName, string id)
        // To solve this error: type of parameters should be the same as in request.
        // public string Get(string userName, int Id) // This also works case-insensitive
        public string Get(string userName, int id)
        {
            return "Hii Your Id: " + id + " & UserName is: " + userName;
        }

        // POST api/values
        [CustomActionFilter]
        public string Post([FromBody] string value)
        {
            return "Hii..." + value;
        }

        // POST api/values
        //// throws compile time error: Type: 'ValuesController' already defines a member called 'Post' with the same parameter type. 
        // public void Post([FromBody] string details)
        // To solve this error, type of parameter should be changed as shown as below.
        // public void Post([FromBody] UserDetails details)
        // Now when this api method is called, it throws an exception as shown as below
        //"Message": "An error has occurred.".
        //"ExceptionMessage": "Multiple actions were found that match the request".
        //"ExceptionType": "System.InvalidOperationException"
        // To solve this exception, we have registed one more route template: api/{controller}/{action}/{id}
        // public void PostDetails([FromBody] string value)
        [CustomActionFilter]
        public UserDetails PostDetails([FromBody] UserDetails userDetails)
        {
            return userDetails;
        }

        //[HttpPut]
        //[HttpGet]
        [ActionName("SubmitUserDetails")] // set alias name for web API action method.
        //public void SaveDetails([FromUri] UserDetails userDetails) // [FromUri] is used to read Data from Uri
        public void SaveDetails([FromBody] UserDetails userDetails) // [FromBody] is used to read Data from body.
        {
           
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // PUT api/values/5
        [Route("")]
        public void PutDetails(int id, [FromBody] UserDetails userDetails)
        {

        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}
