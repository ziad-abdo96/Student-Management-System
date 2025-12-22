namespace FirstProject.Infrastructure
{
	public class FileService : IFileService
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly ILogger<FileService> _logger;

		public FileService(IWebHostEnvironment webHostEnvironment, ILogger<FileService> logger)
		{
			_webHostEnvironment = webHostEnvironment;
			_logger = logger;
		}

		public async Task<string?> SaveFileAsync(IFormFile? file, string folderPath)
		{
			if (file == null || file.Length == 0)
				return null;

			try
			{	
				string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

				if (!Directory.Exists(uploadPath))
				{
					Directory.CreateDirectory(uploadPath);
				}

				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
				string filePath = Path.Combine(uploadPath, fileName);

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(fileStream);
				}

				return Path.Combine(folderPath, fileName).Replace("\\", "/");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error saving file");
				return null;
			}
		}

		public bool DeleteFile(string? filePath)
		{
			if (string.IsNullOrEmpty(filePath))
				return false;

			try
			{
				string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

				if (File.Exists(fullPath))
				{
					File.Delete(fullPath);
					return true;
				}

				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error deleting file: {FilePath}", filePath);
				return false;
			}
		}

		public async Task<string?> UpdateFileAsync(IFormFile? newFile, string? oldFilePath, string folderPath)
		{
			if (newFile == null)
				return oldFilePath;

			DeleteFile(oldFilePath);

			return await SaveFileAsync(newFile, folderPath);
		}
	} 
}
