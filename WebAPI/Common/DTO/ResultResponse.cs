using System.Linq;
using System.Collections;
using System.Text.Json.Serialization;
using WebAPI.Constants;

namespace WebAPI.Common.DTO
{
    public sealed class ResultResponse<T>
    {
        public int? ItemCount { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PageNumber { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PageSize { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TotalItems { get; set; }
        public string Status { get; set; }
        public string ServiceName { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ResultResponse() { }

        public ResultResponse(T data, string status = ResponseStatusConstant.Success, string message = "", string serviceName = AppConstant.App)
        {
            ServiceName = serviceName;
            Status = status;
            Message = message;
            Data = data;
            ItemCount = (data is IEnumerable enumerable && data is not string) ? GetItemCount(enumerable) : 0;
        }

        public ResultResponse(T data, int? pageNumber, int? pageSize, int? totalItems, string status = ResponseStatusConstant.Success, string message = "", string serviceName = AppConstant.App)
            : this(data, status, message)
        {
            ServiceName = serviceName;
            Status = status;
            Message = message;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            Data = data;
            ItemCount = (data is IEnumerable enumerable && data is not string) ? GetItemCount(enumerable) : 0;
        }

        private static int GetItemCount(IEnumerable enumerable)
        {
            if (enumerable is ICollection collection)
            {
                return collection.Count;
            }

            int count = 0;
            foreach (var item in enumerable)
            {
                count++;
            }
            return count;
        }
    }
}
