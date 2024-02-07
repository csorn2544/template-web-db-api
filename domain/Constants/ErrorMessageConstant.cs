namespace domain.Constants
{
    public static class ErrorMessageConstant
    {
        public const string NoHttpContent = "Cannot get http response";
        public const string NotFoundContent = "Not found content";
        public const string EmptyBody = "Empty body";
        public const string InvalidPageNumber = "Page number must be more or equal to 1";
        public const string InvalidPageSize = "Page size must be more or equal to 1";
        public const string MissingCustomerId = "Missing customer Id";
        public const string FailtToUpdateDatabase = "Fail to update data";
        public const string NotFoundTitle = "Not Found";
        public const string MissingProjectId = "Missing project id";
        public const string MissingHouseNumber = "Missing house number";
        public const string UnexpectedMessage = "Something went wrong";
        public const string UnableToUpdate = "Cannot update record";
        public const string HttpUnexpectedError = "External service has unexpected error";
    }
}
