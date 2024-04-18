namespace COMP1004_Project.Models
{
    //this model is used to check for and notify of errors

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}