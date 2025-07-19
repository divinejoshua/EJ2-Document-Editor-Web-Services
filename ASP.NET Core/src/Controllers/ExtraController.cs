using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors; // Add this using directive
using Syncfusion.EJ2.DocumentEditor;
using WDocument = Syncfusion.DocIO.DLS.WordDocument;
using WFormatType = Syncfusion.DocIO.FormatType;
using Syncfusion.EJ2.SpellChecker;
using EJ2APIServices;
using SkiaSharp;
using BitMiracle.LibTiff.Classic;
using Newtonsoft.Json;

namespace EJ2APIServices.Controllers
{

    [Route("api/[controller]")]
    public class ExtraController : Controller
    {
        //API controller for the conversion.
        [AcceptVerbs("Post")]
        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        [Route("LoadString")]
        public string LoadString([FromBody]InputParameter data)
        {
            // You can also load HTML file/string from server side.
            Syncfusion.EJ2.DocumentEditor.WordDocument document = Syncfusion.EJ2.DocumentEditor.WordDocument.LoadString(data.content, FormatType.Html); // Convert the HTML to SFDT format.
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(document);
            document.Dispose();
            return json;
        }

        public class InputParameter
        {
            public string content {get; set; }
        }
    }
}