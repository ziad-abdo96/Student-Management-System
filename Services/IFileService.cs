namespace FirstProject.Services
{
	public interface IFileService
	{
		Task<string?> SaveFileAsync(IFormFile? file, string folderPath);
		bool DeleteFile(string? filePath);

		Task<string?> UpdateFileAsync(IFormFile? newFile, string? oldFilePath,string folderPath);
	}
}
