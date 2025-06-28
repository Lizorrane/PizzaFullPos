namespace Pizza.API.Exceptions
{
    public class NaoEncontradoException : Exception
    {
        public NaoEncontradoException(string msg) : base(msg) 
        {

        }
    }
}
