namespace Bai13.Certificates
{
    class Certificate
    {
        public int CertificateID { get; set; }
        public string CertificateName { get; set; }
        public string CertificateRank { get; set; }
        public DateTime CertificateDate { get; set; }
        public Certificate(int certificateID, string certificateName, string certificateRank, DateTime certificateDate)
        {
            CertificateID = certificateID;
            CertificateName = certificateName;
            CertificateRank = certificateRank;
            CertificateDate = certificateDate;
        }


    }
}
