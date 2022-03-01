namespace UniAdmissionsAssesment
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public int StatusCode { get; protected set; }

        public BaseResponse(bool success, string message, int statusCode)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }
    }

    public class Response<T> : BaseResponse where T : class
    {
        public T Result { get; private set; }

        private Response(bool success, string message, int statusCode, T result) : base(success, message, statusCode)
        {
            Result = result;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="response">response.</param>
        /// <returns>Response.</returns>
        public Response(T response) : this(true, string.Empty, 200, response)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public Response(int statusCode, string message) : this(false, message, statusCode, null)
        { }
    }
}
