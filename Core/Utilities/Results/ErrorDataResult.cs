namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T Data , string message):base(Data,false,message)
        {
        }
        public ErrorDataResult(T Data):base(Data,true)
        {
        }
        public ErrorDataResult():base(default,false)
        {
        }
        public ErrorDataResult(string message):base(default,false,message)
        {

        }
    }
}
