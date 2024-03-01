namespace ARAINV.Infrastructure.DTOs.Products
{
    public class FilterProductDTO
    {
        public int? Id { get; set; }
        public string? NameProduct { get; set; } = null!;
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public DateTime? Created { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
        public Boolean? Deleted { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string? orderBy { get; set; }
    }
}
