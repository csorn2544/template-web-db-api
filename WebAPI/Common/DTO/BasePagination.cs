using System.ComponentModel;

namespace WebAPI.Common.DTO
{
    public abstract class BasePagination
    {
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;
        [DefaultValue(5)]
        public int PageSize { get; set; } = 5;
    }
}
