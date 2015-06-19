namespace Labrador
{
    public interface IBackyard
    {
        // Backyard é quem tem o papel de criar a connection (PlayTime)
        // Então ele deve conhecer um componente poliglota que crie a conexão correta.

        IRetriever PlayTime();

        ILeash<IRetriever> PlayTimeOnLeash();
    }
}
