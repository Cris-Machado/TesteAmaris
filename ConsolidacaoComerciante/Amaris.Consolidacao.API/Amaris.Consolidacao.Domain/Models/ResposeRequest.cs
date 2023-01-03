namespace Amaris.Consolidacao.Domain.Models
{
    public class ResposeRequest<T>
    {
        public T? Data { get; set; }
        public bool Sucesso { get; set; } = true;
        public string ErrorDescription { get; set; } = string.Empty;
    }
}
