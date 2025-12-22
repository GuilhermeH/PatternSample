namespace StatePattern.Sample.Problem
{
    public class Document
    {
        private EnumStatus _status;
        public EnumStatus Status => _status;

        public Document()
        {
            _status = EnumStatus.Draft;
        }

        public void Edit()
        {
            if (_status == EnumStatus.Draft || _status == EnumStatus.Rejected)
            {
                Console.WriteLine("Document be in draft status.");
            }
            else
            {
                Console.WriteLine("It's not possible edit document in current status.");
            }
        }

        public void SendToReview()
        {
            if (_status == EnumStatus.Draft || _status == EnumStatus.Rejected)
            {
                _status = EnumStatus.Reviewed;
                Console.WriteLine("Document send to review");
            }
            else
            {
                Console.WriteLine("It's not possible send document to review in current status.");
            }
        }

        public void Approve()
        {
            if (_status == EnumStatus.Reviewed)
            {
                _status = EnumStatus.Approved;
                Console.WriteLine("Approved document");
            }
            else
            {
                Console.WriteLine("It's not possible approved document in current status.");
            }
        }

        public void Reject()
        {
            if (_status == EnumStatus.Reviewed)
            {
                _status = EnumStatus.Rejected;
                Console.WriteLine("Rejected document");
            }
            else
            {
                Console.WriteLine("It's not possible reject document in current status.");
            }
        }

        public void Cancel()
        {
            if (_status == EnumStatus.Draft || _status == EnumStatus.Reviewed || _status == EnumStatus.Rejected)
            {
                _status = EnumStatus.Canceled;
                Console.WriteLine("Canceled document");
            }
            else
            {
                Console.WriteLine("It's not possible cancel document in current status.");
            }
        }
    }
}
