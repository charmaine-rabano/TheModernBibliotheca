using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheModernBibliotheca._Code.Model;
using Azure.Storage.Blobs;

namespace TheModernBibliotheca._Code.App.Librarian.Books
{
    public class BookRepository
    {
        public static BookInformation GetBook(string ISBN)
        {
            using (var context = new TheModernDatabaseEntities())
                return context.BookInformations.FirstOrDefault(e => e.ISBN == ISBN);
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

        public static void ModifyBook(string ISBN, BookInformation modifiedBook)
        {
            using (var context = new TheModernDatabaseEntities())
            {
                var book = context.BookInformations.FirstOrDefault(e => e.ISBN == ISBN);

                if (book == null) throw new InvalidOperationException("Invalid ISBN");

                book.Title = modifiedBook.Title;
                book.Genre = modifiedBook.Genre;
                book.Author = modifiedBook.Author;
                book.Summary = modifiedBook.Summary;
                book.BookCover = modifiedBook.BookCover;
                
                context.SaveChanges();
            }
        }

    }
}