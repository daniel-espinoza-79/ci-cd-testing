using Commons.ResponseHandler.Responses.Bases;
using InventoryService.Application.Dtos.Images;
using MediatR;

namespace InventoryService.Application.QueryCommands.Images.Commands.Commands;

public class UpdateImageCommand(UpdateImageDto image) : IRequest<BaseResponse>
{
    public UpdateImageDto Image { get; } = image;
}