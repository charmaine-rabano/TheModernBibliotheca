using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;
using Azure.Storage.Blobs;

namespace TheModernBibliotheca._Code.App.Librarian.Books
{
    public class AddBookRepository
    {
        public static void AddBook(BookInformation book)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                context.BookInformations.Add(book);
                context.SaveChanges();
            }
        }

        public static string UploadFile(string filename, string containerName, HttpPostedFile file, bool overwrite = true)
        {
            if (file == null) { throw new ArgumentException("File must not be null"); }

            file.InputStream.Position = 0;
            BlobClient blobClient = GetBlobContainerClient(containerName).GetBlobClient(filename);
            using (var inputStream = file.InputStream)
            {
                blobClient.Upload(inputStream, overwrite: overwrite);
            }
            return blobClient.Uri.AbsoluteUri;
        }

        private static BlobContainerClient GetBlobContainerClient(string containerName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=bookcover;AccountKey=ia3YjLBqu0jYBCyiSot38jNZUgprUHKC3yTxvUxXpeFItY6FMkFqgs5Bmobv/pvtJowiULBk/wn79uXcovkYDA==;EndpointSuffix=core.windows.net");
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            return containerClient;
        }

        public static void AddBookInstance(int qty, BookInstance instance)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                for (int i = 0; i < qty; i++)
                {
                    context.BookInstances.Add(instance);
                    context.SaveChanges();
                }
            }
        }
        internal static bool IsISBNUnique(string ISBN)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations.Any(e => e.ISBN == ISBN);
        }
        
        
    }
}