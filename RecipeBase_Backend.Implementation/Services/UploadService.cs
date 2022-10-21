
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using RecipeBase_Backend.Application.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.Implementation.Services
{
    public class UploadService : IUploadService
    {
        private readonly string _storageConnectionString;

        public UploadService(IConfiguration configuration)
        {
            _storageConnectionString = configuration.GetSection("AzureStorageString").Value;
        }

        public string Upload(Stream fileStream, string fileName, string contentType)
        {
            var container = new BlobContainerClient(_storageConnectionString, "marijanatest");
            var createResponse = container.CreateIfNotExists();

            if(createResponse != null && createResponse.GetRawResponse().Status == 201)
                container.SetAccessPolicy(PublicAccessType.Blob);

            var blob = container.GetBlobClient($"recipebase/{fileName}");
            blob.DeleteIfExists(DeleteSnapshotsOption.IncludeSnapshots);

            blob.Upload(fileStream, new BlobHttpHeaders { ContentType = contentType });

            return blob.Uri.ToString();
        }
    }
}
