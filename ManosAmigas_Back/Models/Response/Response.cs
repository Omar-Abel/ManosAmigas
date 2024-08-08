namespace ManosAmigas_Back.Models.Response
{
    public class Response
    {
        public int success { get; set; }
        public string message { get; set; }
        public object Data { get; set; }

        public Response()
        {
            this.success = 0;
        }
    }
}
