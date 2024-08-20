using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using UserManagementComponentApplication.Commands.Users.CreateUser;
using UserManagementComponentApplication.Commands.Users.DeleteUser;
using UserManagementComponentApplication.Commands.Users.UpdateUser;
using UserManagementComponentApplication.DTOs;
using UserManagementComponentApplication.Queries.Users;


namespace UserManagementPresentation.Controllers;

public class UserEndpoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        // Endpoint tanımlamaları burada yapılır
        app.MapGet("/users", GetUsers);
        app.MapGet("/users/{id:Guid}", GetUserById);
        app.MapPost("/users", CreateUser);
        app.MapPut("/users/{id:Guid}", UpdateUser);
        app.MapDelete("/users/{id:Guid}", DeleteUser);
    }

    public static async Task<IResult> GetUsers([FromServices] ISender sender)
    {
        var query = new GetUsersQuery();
        var users = await sender.Send(query);

        return Results.Json(users);
    }
    public static async Task<IResult> GetUserById(Guid id, [FromServices] ISender sender)
    {
        var query = new GetUserByIdQuery(id);
        var user = await sender.Send(query);

        return user is not null ? Results.Json(user) : Results.NotFound();
    }
    public static async Task<IResult> CreateUser([FromBody] UserDto user, [FromServices] ISender sender)
    {
        var command = new CreateUserCommand(user);
        var createdUser = await sender.Send(command);

        return Results.Created($"/users/{createdUser.Id}", createdUser);
    }
    public static async Task<IResult> UpdateUser(Guid id, [FromBody] UserDto user, [FromServices] ISender sender)
    {
        var command = new UpdateUserCommand(id, user);
        var updated = await sender.Send(command);

        return updated ? Results.NoContent() : Results.NotFound();
    }
    public static async Task<IResult> DeleteUser(Guid id, [FromServices] ISender sender)
    {
        var command = new DeleteUserCommand(id);
        var deleted = await sender.Send(command);

        return deleted ? Results.NoContent() : Results.NotFound();
    }
}