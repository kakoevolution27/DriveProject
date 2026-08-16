
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FileController: ControllerBase
{
    private readonly GenericService _GenericService;
    public FileController(GenericService genericService)
    {
        _GenericService = genericService;
    }
}

