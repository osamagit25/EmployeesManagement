using Microsoft.AspNetCore.Http.HttpResults;

namespace EMS.Web.Helpers
{
    public  static class  DocumentSettings
    {
       public static string UploadFile(IFormFile file,string FolderName)
        {
            string fileName = $"{Guid.NewGuid()}_{file.FileName}";

            // تحديد مسار الحفظ: wwwroot/Images/filename.jpg
            string directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FolderName);

            // التأكد إن الفولدر موجود، ولو مش موجود نعمله
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string filePath = Path.Combine(directory, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            // هنرجّع المسار النسبي عشان نعرض الصورة على الموقع
            return Path.Combine(FolderName, fileName).Replace("\\", "/");

        }

        public static void DeleteFile(string FileName, string FolderName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwroot", FolderName,FileName);
            
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }
    }
}
