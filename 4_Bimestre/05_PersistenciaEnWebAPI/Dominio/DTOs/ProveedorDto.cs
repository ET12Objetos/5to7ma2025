namespace Dominio.DTOs;

public class ClientePutDto
{
    public string Nombre { get; set; } = default!;
}

public class ClientePostDto : ClientePutDto
{
    public string Email { get; set; } = default!;
}

public class ClienteResponseDto : ClientePostDto
{
    public Guid Id { get; set; }
}