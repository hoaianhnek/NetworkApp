using Contract.Dtos;
using Core.Contract;
using Core.Enums;
using Core.Utility;
using NetworkDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.DataProvider
{
    public class PostProvider
    {
        public ResponseList<PostDto> GetPostByUser(int UserId)
        {

            var result = new ResponseList<PostDto>();
            using(DBNetworkEntities entities = new DBNetworkEntities())
            {
                var postRepo = entities.PostUsers;

                var posts = postRepo.Where(p => p.UserId == UserId);
                if(posts.Any())
                {
                    var test = posts.Select(p => new PostDto
                    {
                        Id = p.Id,
                        UserId = p.UserId,
                        Description = p.Description,
                        UploadDate = p.UploadDate,
                        ImagePath = p.Photos.Where(ph => ph.PostId == p.Id).Select(ph=>ph.ImagePath).ToList()
                    }).ToList(); ;
                    result.Dtos = test;
                    result.ResponseCode = NResponseStatus.Ok;;
                    result.Message = NResponseStatus.Ok.GetDescription();
                } else
                {
                    result.Dtos = null;
                    result.ResponseCode = NResponseStatus.NoData;
                    result.Message = NResponseStatus.NoData.GetDescription();
                }
            }
            return result;
        }
    
        public Response<PostDto> CreatePostByUser(CreatePostDto request)
        {
            var result = new Response<PostDto>();
            using (DBNetworkEntities entities = new DBNetworkEntities())
            {
                var postRepo = entities.PostUsers;
                var photoRepo = entities.Photos;
                //tạo post
                postRepo.Add(new PostUser()
                {
                    UserId = request.UserId,
                    Description = request.Description,
                    UploadDate = DateTime.Now
                });
                entities.SaveChanges();
                var post = entities.PostUsers.OrderByDescending(p => p.Id).FirstOrDefault();
                //upload ảnh lên folder
                foreach(var image in request.ImagePaths)
                {
                    var imagePath = ImageUploader.UploadImage(Base64ImageUploader.GenerateImageFileName(post.Id.ToString()),
                    image, NImageType.Post.GetDescription());
                    var imageLink = imagePath.OrginalImage;
                    //tạo photo thuộc ablum có sẵn
                    photoRepo.Add(new Photo()
                    {
                        PostId = post.Id,
                        ImagePath = imageLink,
                        IdAlbum = 1
                    });
                }
                entities.SaveChanges();
                result.Dto = null;
                result.ResponseCode = NResponseStatus.Ok;
                result.Message = NResponseStatus.Ok.GetDescription();
            };
            return result;
        }
    }
}