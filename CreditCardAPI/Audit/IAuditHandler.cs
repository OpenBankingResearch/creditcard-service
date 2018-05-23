namespace CreditCardAPI.Audit
{
    public interface IAuditHandler
    {
        void Post(Audit audit);
    }
}
