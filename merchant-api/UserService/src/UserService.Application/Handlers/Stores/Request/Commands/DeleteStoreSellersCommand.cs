using Commons.ResponseHandler.Responses.Bases;
using MediatR;

namespace UserService.Application.Handlers.Stores.Request.Commands;

public class DeleteStoreSellersCommand : IRequest<BaseResponse>
{
    public Guid StoreId { get; set; }
    public Guid SellerId { get; set; } = new();

    public DeleteStoreSellersCommand(Guid storeId, Guid sellerId)
    {
        StoreId = storeId;
        SellerId = sellerId;
    }
}