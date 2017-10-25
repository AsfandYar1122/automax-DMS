using AutoMax.Models;
using AutoMax.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AutoMax.API.Controllers
{
    public class VIRController : ApiController
    {
        private AutoMaxContext db = new AutoMaxContext();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="virPartType"></param>
        /// <returns></returns>
        [HttpGet]
        [System.Web.Http.Route("GetVIR")]
        public ResultSetViewModel GetVIR(int vehicleId, VIRPartType virPartType)
        {
            return new VIRRepository().GetVIR(vehicleId, virPartType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vir"></param>
        /// <returns></returns>
        [HttpPost]
        [System.Web.Http.Route("AddUpdateVIRPartInformation")]
        public ResultSetViewModel AddUpdateVIRPartInformation(VIR vir)
        {
            return new VIRRepository().AddUpdateVIRPartInformation(vir);
        }

        [HttpPost]
        [System.Web.Http.Route("SaveInformation")]
        public ResultSetViewModel SaveInformation(CarInfo vir)
        {
            return new VIRRepository().SaveInformation(vir);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        [HttpPost]
        [System.Web.Http.Route("UploadImage")]
        public async Task<IHttpActionResult> UploadImage(long vehicleId)
        {
            try
            {
                var fileName = "MobileUpload-";
                var extention = ".png"; // retur
                var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
                fileName = fileName + date + extention;
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/VehicleAttachments/"), fileName);
                bool isExists = Directory.Exists(path);

                if (!isExists)
                    System.IO.Directory.CreateDirectory(path);

                var rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);
                rootUrl = Request.Headers.Host;

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                if (Request.Content.IsMimeMultipartContent())
                {
                    var streamProvider = new AutoMaxMultipartFormDataStreamProvider(path, fileName);
                    var result = await Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<List<FileDesc>>(t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                        {
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }

                        var fileInfo = streamProvider.FileData.Select(i =>
                        {
                            var info = new FileInfo(i.LocalFileName);
                            return new FileDesc(info.FullName, fileName, "http://" + rootUrl + "/" + fileName, info.Length / 1024, info.Extension, 0);
                        }).ToList();
                        return fileInfo;
                    });

                    VehicleImage img = new VehicleImage();
                    img.ImagePath = fileName;
                    img.VehicleID = vehicleId;
                    img.CreatedBy = 1;
                    img.UpdatedBy = 1;
                    img.CreatedDate = DateTime.Now;
                    img.UpdatedDate = DateTime.Now;
                    db.VehicleImages.Add(img);

                    return Ok(fileName);
                }
                else
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }
    }

    
    public class FileDesc
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string Ext { get; set; }
        public int ThumbTypeId { get; set; }
        public string FullName { get; set; }
        public FileDesc(string fullName, string name, string path, long size, string ext, int type)
        {
            FullName = fullName;
            Name = name;
            Path = path;
            Size = size;
            Ext = ext;
            ThumbTypeId = type;
        }
    }

    public class AutoMaxMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        string FileName;
        public AutoMaxMultipartFormDataStreamProvider(string path, string fileName)
            : base(path)
        {
            FileName = fileName;

        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string fileName;
            if (!string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
            {
                string fname = headers.ContentDisposition.FileName;
                string[] file = fname.Split('.');
                string ext = file[1];
                fileName = @"\" + FileName + "." + ext;

                //fileName = headers.ContentDisposition.FileName;
            }
            else
            {
                fileName = FileName + ".data";


            }
            return fileName.Replace("\"", string.Empty);
        }
    }
}
