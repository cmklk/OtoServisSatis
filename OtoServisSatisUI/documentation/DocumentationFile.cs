namespace OtoServisSatisUI.documentation
{
    public class DocumentationFile
    {
        public static async Task<string> FileLoaderAsync(IFormFile formfile, string filePath ="/Img/")
        {
            var file = "";
            if(formfile !=null && formfile.Length > 0)
            {
                file = formfile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/" + filePath + file;
                using var stream =new FileStream(directory,FileMode.Create);
                await formfile.CopyToAsync(stream);
            }
            return file;
        }
    }
}
