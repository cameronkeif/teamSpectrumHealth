//-----------------------------------------------------------------------
// <copyright file="AttachMemoController.cs" company="Spectrum Health">
//      Spectrum Health
// </copyright>
//-----------------------------------------------------------------------

namespace MedicationsShortagesDashboard.Controllers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    using MedicationsShortagesDashboard.Services;

    /// <summary>
    /// API Controller that handles file upload for memos
    /// </summary>
    public class AttachMemoController : ApiController
    {
        /// <summary>
        /// Performs the interaction with the SHORTAGE table
        /// </summary>
        private ShortageRepository shortageRepository = new ShortageRepository();

        /// <summary>
        /// Processes a file upload. Stores the file as memo_{shortage id}.{extension} in the Memos/ folder.
        /// Updates database to reflect filename.
        /// </summary>
        /// <param name="id">Shortage ID to attach this memo to</param>
        /// <returns>HTTP Response</returns>
        public async Task<HttpResponseMessage> PostFormData(int id)
        {
            string root = HttpContext.Current.Server.MapPath("~/Memos/");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (MultipartFileData file in provider.FileData)
                {
                    // Find the file extension
                    string filename = file.Headers.ContentDisposition.FileName;
                    string[] filename_split = filename.Split(new string[] { "." }, StringSplitOptions.None);
                    string extension = filename_split[filename_split.Length - 1];
                    extension = extension.Replace("\"", string.Empty);
                    extension = "." + extension;

                    // Find the local filename as it was currently uploaded (The BodyPart thing)
                    string local = file.LocalFileName;
                    string[] local_split = local.Split(new string[] { "\\" }, StringSplitOptions.None);
                    string local_filename = local_split[local_split.Length - 1];
                    
                    string currentPath = root + local_filename;
                    string desiredPath = root + "memo_" + id + extension; // memo_{shortage_id}.{extension}
                    
                    // If somehow someone is trying to upload an existing file, overwrite it
                    if (File.Exists(desiredPath))
                    {
                        File.Delete(desiredPath);
                    }

                    // Only attach if its a valid file
                    if (!string.IsNullOrWhiteSpace(extension))
                    {
                        // Rename to an easily accessible filename
                        File.Move(currentPath, desiredPath);
                        this.shortageRepository.AttachMemoToShortage(id, "memo_" + id + extension);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
