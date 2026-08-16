public interface IStorageService
{
    // Gera uma URL pré-assinada para upload (PUT) de um objeto
    Task<string> GenerateUploadUrlAsync(string bucket, string key, string contentType, TimeSpan? expiry = null);

    // Gera uma URL pré-assinada para download (GET) de um objeto
    Task<string> GenerateDownloadUrlAsync(string bucket, string key, TimeSpan? expiry = null);

    // Deleta
    Task DeleteAsync(string bucket, string key);

    // Verifica se um objeto existe
    Task<bool> ExistsAsync(string bucket, string key);
}