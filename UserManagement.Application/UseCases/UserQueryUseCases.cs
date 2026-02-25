using UserManagement.Domain.Repositories;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.UseCases;

public interface IGetAllUsersUseCase
{
    Task<IEnumerable<UserResponse>> ExecuteAsync();
}

public class GetAllUsersUseCase : IGetAllUsersUseCase
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserResponse>> ExecuteAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(user => new UserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        });
    }
}

public interface IGetUserByIdUseCase
{
    Task<UserResponse?> ExecuteAsync(Guid id);
}

public class GetUserByIdUseCase : IGetUserByIdUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse?> ExecuteAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        return new UserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }
}

public interface IDeleteUserUseCase
{
    Task<bool> ExecuteAsync(Guid id);
}

public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly IUserRepository _userRepository;

    public DeleteUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}
