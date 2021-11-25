using System;

namespace PMT.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class Erreur
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
