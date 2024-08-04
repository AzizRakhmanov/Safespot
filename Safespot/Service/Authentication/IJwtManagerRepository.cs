namespace Safespot.Service.Authentication
{
    public interface IJwtManagerRepository
    {
        Tokens Authenticate(Users users);
    }
}
