using Contract.Dtos;
using Core.Contract;
using Core.Enums;
using Core.Utility;
using log4net;
using NetworkDataAccess;
using System;
using System.Linq;
using System.Web.Http;
using WebService.DataProvider;
using WebService.DataValidator;

namespace WebService.Controllers
{
    [RoutePrefix("webservice")]
    public class PostController : ApiController
    {
        protected static readonly ILog Logger = log4net.LogManager.GetLogger(typeof(UserController));
        private static readonly ValidatorHelper Validator = new ValidatorHelper();
        private readonly PostProvider _postProvider = new PostProvider();

        [HttpGet]
        [Route("users/{UserId}/post")]
        public IHttpActionResult GetPostByUser(int UserId)
        {
            try
            {
                var result = _postProvider.GetPostByUser(UserId);
                return Ok(result);
            } catch(Exception e)
            {
                return Ok(new Response<string>
                {
                    Dto = null,
                    ResponseCode = NResponseStatus.NoData,
                    Message = NResponseStatus.NoData.GetDescription()
                });
            }
            
        }
    
        [HttpPost]
        [Route("posts/create")]
        public IHttpActionResult CreatePostByUser(CreatePostDto request)
        {
            try
            {
                var result = _postProvider.CreatePostByUser(request);
                return Ok(result);
            } catch(Exception e)
            {
                return Ok(new Response<string>
                {
                    Dto = null,
                    ResponseCode = NResponseStatus.NoData,
                    Message = NResponseStatus.NoData.GetDescription()
                });
            }
        }
    }
}
