namespace ARAINV.Core.Interfaces.Management
{
    public interface IAddEntity<TKey>
    {
        public TKey Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
