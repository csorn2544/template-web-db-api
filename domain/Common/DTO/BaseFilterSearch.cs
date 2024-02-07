using System.ComponentModel;

namespace domain.Common.DTO
{
    public abstract class BaseFilterSearch : BasePagination
    {
        [DefaultValue(0)]
        public int FilterType { get; set; } = 0;
        [DefaultValue("")]
        public string FilterValue { get; set; } = string.Empty;
    }
}
