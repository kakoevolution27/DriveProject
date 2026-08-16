using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly GenericService _GenericService;
    public UserController(GenericService genericService)
    {
        _GenericService = genericService;
    }
}