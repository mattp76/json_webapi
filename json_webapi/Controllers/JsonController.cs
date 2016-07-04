using json_webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;

namespace json_webapi.Controllers
{
    [RoutePrefix("api")]
    public class JsonController : ApiController
    {
        // POST api/json
        //The webApiConfig (app_start) was modified to send the root URL directly to this method
        //I was using fiddler to help me complete this task
        //The JSON will serialise into the 'req' requestModel.Request object on post
        [HttpPost]
        public HttpResponseMessage ProcessJson(RequestModel.Request req)
        {
            //Add code into the try / catch to grab any parsing errors or exceptions
            try
            {
                if (req != null)
                {
                    ResponseModel res = new ResponseModel();
                    res.response = new List<ResponseSet>();

                    //check the request has some payload items
                    if (req.Payload.Length > 0)
                    {
                        foreach (var p in req.Payload)
                        {
                            //check drm is true and episode count is greater than 0
                            if (p.Drm && p.EpisodeCount > 0)
                            {
                                //build our response object
                                res.response.Add(new ResponseSet
                                {
                                    image = p.Image.ShowImage,
                                    slug = p.Slug,
                                    title = p.Title
                                });
                            }
                        }
                        //return a valid response
                        return ValidResponse(res);
                    }
                }
            }
            catch (Exception ex)
            {
                //Might like also to log / capture exceptions here 'ex'
                //Return error, likely a parsing issue - Bad request
                return ErrorResponse();
            }

            //No request object - return bad request (although this could be changed, as it wasnt stricly a bad request but an empty request body)
            return ErrorResponse();
        }


        public HttpResponseMessage ValidResponse(ResponseModel res)
        {
            string json = JsonConvert.SerializeObject(res);
            HttpResponseMessage response = new HttpResponseMessage();

            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.Unicode);
            return response;
        }


        public HttpResponseMessage ErrorResponse()
        {
            var myError = new { Error = "Could not decode request: JSON parsing failed" };
            return Request.CreateResponse(HttpStatusCode.BadRequest, myError);
        }
    }
}
