namespace PayXpertLibrary.Responses
{
    public class Response3DSCheckObject : BaseTransactionResponseObject
    {
        public string ACSUrl { get; set; }
        public string PaReq { get; set; }
    }

    public class Response3DSParseObject : BaseResponseObject
    {
        public string ECI { get; set; }
        public string XID { get; set; }
        public string CAVV { get; set; }
        public string CAVVAlgorithm { get; set; }
    }
}
