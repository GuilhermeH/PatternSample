namespace Specification.SampleDomain;
public class Order
{
    public string Branch { get; }            // Filial
    public string Manager { get; }           // Gerente responsável
    public OrderOperation? Operation { get; }               // Informações adicionais da operação
    public string Seller { get; }       // Vendedor que registrou o pedido
    public string? ApprovedOrderId { get; }                 // Pedido aprovado (se já virou venda)
    public string? CustomerId { get; }                      // Cliente
    public EOrderType? OrderType { get; }                    // Tipo de pedido
}
