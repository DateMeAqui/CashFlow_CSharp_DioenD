namespace CashFlow.Communication.Responses
{
    public class ResponseErrorJson
    {
        public List<string> ErrorMessage { get; set; }

        public ResponseErrorJson(string errorMessage)
        {
            ErrorMessage = new List<string> { errorMessage };

            //simplificação do codigo a cima
            //ErrorMessage = [errorMessage];
        }

        public ResponseErrorJson(List<string> errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
