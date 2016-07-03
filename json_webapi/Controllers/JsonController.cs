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
        [HttpPost]
        public HttpResponseMessage ProcessJson(RequestModel.Request req)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ResponseModel res = new ResponseModel();

            try
            {
                if (req != null)
                {
                    res.response = new List<ResponseSet>();
  
                    if (req.Payload.Length > 0)
                    {
                        foreach (var p in req.Payload)
                        {
                            if (p.Drm && p.EpisodeCount > 0)
                            {
                                res.response.Add(new ResponseSet
                                {
                                    image = p.Image.ShowImage,
                                    slug = p.Slug,
                                    title = p.Title
                                });
                            }
                        }

                        string json = JsonConvert.SerializeObject(res);
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent(json, Encoding.Unicode);                   
                    }
                }
                else
                {
                    return ErrorResponse();

                }
            }
            catch (Exception ex)
            {
                return ErrorResponse();
            }

            return response;
        }

        public HttpResponseMessage ErrorResponse()
        {
            var myError = new { Error = "Could not decode request: JSON parsing failed" };
            return Request.CreateResponse(HttpStatusCode.BadRequest, myError);
        }
    }
}
