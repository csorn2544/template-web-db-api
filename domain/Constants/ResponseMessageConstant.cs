namespace domain.Constants
{
    public static class ResponseMessageConstant
    {
        public const string GetStatusCode200 = "Data retrieval successful";
        public const string CreateStatusCode201 = "Creation successful";
        public const string UpdateStatusCode200 = "Update successful";
        public const string DeleteStatusCode200 = "Deletion successful";

        public const string GetStatusCode204 = "Data not found";
        public const string CreateStatusCode204 = "Creation without response data";
        public const string UpdateStatusCode204 = "Update without response data";
        public const string DeleteStatusCode204 = "Deletion without response data";

        public const string GetStatusCode400 = "Bad request - data retrieval failed";
        public const string CreateStatusCode400 = "Bad request - creation failed";
        public const string UpdateStatusCode400 = "Bad request - update failed";
        public const string DeleteStatusCode400 = "Bad request - deletion failed";

        public const string GetStatusCode401 = "Unauthorized - check access token";
        public const string CreateStatusCode401 = "Unauthorized - check access token";
        public const string UpdateStatusCode401 = "Unauthorized - check access token";
        public const string DeleteStatusCode401 = "Unauthorized - check access token";

        public const string GetStatusCode403 = "Forbidden - insufficient permissions";
        public const string CreateStatusCode403 = "Forbidden - insufficient permissions";
        public const string UpdateStatusCode403 = "Forbidden - insufficient permissions";
        public const string DeleteStatusCode403 = "Forbidden - insufficient permissions";

        public const string GetStatusCode404 = "Data not found - invalid request parameters";
        public const string CreateStatusCode404 = "Invalid creation parameters";
        public const string UpdateStatusCode404 = "Invalid update parameters";
        public const string DeleteStatusCode404 = "Invalid deletion parameters";

        public const string GetStatusCode409 = "Data Duplicate";

        public const string GetStatusCode500 = "Server error - data retrieval failed";
        public const string CreateStatusCode500 = "Server error - creation failed";
        public const string UpdateStatusCode500 = "Server error - update failed";
        public const string DeleteStatusCode500 = "Server error - deletion failed";

    }
}
