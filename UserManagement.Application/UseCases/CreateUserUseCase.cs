using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.UseCases;

public interface ICreateUserUseCase
{
    Task<UserResponse> ExecuteAsync(CreateUserRequest request);
}

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public CreateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> ExecuteAsync(CreateUserRequest request)
    {
        var user = new User(request.FirstName, request.LastName, request.Email);
        var createdUser = await _userRepository.AddAsync(user);
        
        return new UserResponse
        {
            Id = createdUser.Id,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName,
            Email = createdUser.Email,
            CreatedAt = createdUser.CreatedAt
        };
    }
}
