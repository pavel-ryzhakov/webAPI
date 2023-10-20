namespace Domain.Exceptions;

public sealed class MaxPriceRangeBadRequestException : BadRequestException
{
    public MaxPriceRangeBadRequestException() :base("Максимальная цена не может быть меньше минимальной.") { }
}