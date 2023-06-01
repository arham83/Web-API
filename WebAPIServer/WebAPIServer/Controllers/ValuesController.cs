using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIServer.MessageStructure;
using WebAPIServer.Miscellaneous;
using WebAPIServer.Test;

namespace WebAPIServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public string[] _data = new string[] { "apple", "Bottom", "Jeans" };

        [HttpGet]
        public string[] Get()
        {
            return _data;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Search for the requested item in your data store
            // For example, you can use a database, a list, or any other data source
            var item = _data[id];
            // If the item was not found, return a 404 Not Found error
            if (item == null)
            {
                return NotFound();
            }
            // If the item was found, return it as a JSON response
            return Ok(item);
        }
        [HttpPost("SM")]
        public IActionResult Post([FromBody] SampleMessage SM)
        {
            // Process the byte array as needed
            var Message = "Data received successfully against the following ID: "+SM.Id.ToString();
            return Ok(Message);
        }

        [HttpPost("FM")]
        public IActionResult PostFM([FromBody] FullMessage FM)
        {
            var Message = "Data received successfully";
            return Ok(Message);
        }
        
        [HttpPost("OM")]
        public IActionResult PostOM([FromBody] OptimizedMessage OM)
        {
            var Message = "Data received successfully";
            return Ok(Message);
        }

        #region For Testing Purpose

        [HttpPost("BFM")]
        public IActionResult PostBFM([FromBody] FullMessage FM)
        {
            var RFM = Misc.JsonHandler.DeserializeJson<FullMessage>(Misc.GetPath(@"SampleMessages\bigFull.json"));
            bool areEqual = new Comparer().CompareFM(RFM, FM);
            var Message = "Test Passed" + areEqual;
            return Ok(Message);
        }

        [HttpPost("SFM")]
        public IActionResult PostSFM([FromBody] FullMessage FM)
        {
            var RFM = Misc.JsonHandler.DeserializeJson<FullMessage>(Misc.GetPath(@"SampleMessages\smallFull.json"));
            bool areEqual = new Comparer().CompareFM(RFM, FM);
            var Message = "Test Passed" + areEqual;
            return Ok(Message);
        }

        [HttpPost("SOM")]
        public IActionResult PostSOM([FromBody] OptimizedMessage OM)
        {
            var ROM = Misc.JsonHandler.DeserializeJson<OptimizedMessage>(Misc.GetPath(@"SampleMessages\smallOptimized.json"));
            bool areEqual = new Comparer().CompareOM(ROM, OM);
            var Message = "Test Passed" + areEqual;
            return Ok(Message);
        }
        [HttpPost("BOM")]
        public IActionResult PostBOM([FromBody] OptimizedMessage OM)
        {
            var ROM = Misc.JsonHandler.DeserializeJson<OptimizedMessage>(Misc.GetPath(@"SampleMessages\bigOptimized.json"));
            bool areEqual = new Comparer().CompareOM(ROM, OM);
            var Message = "Test Passed" + areEqual;
            return Ok(Message);
        }


        #endregion
    }
}
