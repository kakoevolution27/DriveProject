// contem as regras de serviços
public class GenericService
{
    private readonly GenericRepository _GenericRepository;

    public GenericService(GenericRepository genericRepository)
    {
        _GenericRepository = genericRepository;
    }
}