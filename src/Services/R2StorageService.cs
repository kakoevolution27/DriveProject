using Microsoft.Extensions.Options;
using Cloudflare.NET.R2;
using Cloudflare.NET.R2.Models;
using Amazon.S3.Model;

public class R2StorageService : IStorageService
{ 
    private readonly string? _AccessKey;
    private readonly string? _SecretKey;
    private readonly string? _AccountId;
    private readonly string? _DefaultBucket;
    private readonly IR2Client r2Client;

    public R2StorageService(IOptions<R2Options> options, IR2Client r2)
    {
        var config = options.Value;
        r2Client = r2;
    }
    public async Task DeleteAsync(string bucket, string key)
    {
        throw new NotImplementedException();
    }

    Task<bool> IStorageService.ExistsAsync(string bucket, string key)
    {
        throw new NotImplementedException();
    }

    Task<string> IStorageService.GenerateDownloadUrlAsync(string bucket, string key, TimeSpan? expiry)
    {
        throw new NotImplementedException();
    }

    public Task<string> GenerateUploadUrlAsync(string bucket, string key, string contentType, TimeSpan? expiry = null)
    {
        throw new NotImplementedException();
    }
}

public class R2Options
{
    public string? AccessKey { get; set; }
    public string? SecretKey { get; set; }
    public string? AccountId { get; set; }
    public string? DefaultBucket { get; set; }
}