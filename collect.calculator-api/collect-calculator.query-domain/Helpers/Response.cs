namespace collect_calculator.domain.Helpers
{
    public class Response<T>
    {
        private bool IsSucess = false;
        public T? Data;
        public bool IsSuccess() => IsSucess;

        public static Response<T> SuccessWithData(T? data)
        {
            return new Response<T> { Data = data, IsSucess = true };
        }

        public static Response<T> SuccessWithNoData()
        {
            return new Response<T> { Data = default, IsSucess = true };
        }
    }
}
